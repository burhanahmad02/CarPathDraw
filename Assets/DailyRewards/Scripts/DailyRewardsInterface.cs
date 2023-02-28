/***************************************************************************\
Project:      Daily Rewards
Copyright (c) Niobium Studios.
Author:       Guilherme Nunes Barbosa (gnunesb@gmail.com)
\***************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace NiobiumStudios
{
    /**
     * The UI Logic Representation of the Daily Rewards
     **/
    public class DailyRewardsInterface : MonoBehaviour
    {
        public Canvas canvas;
        public GameObject dailyRewardPrefab;        // Prefab containing each daily reward

        [Header("Panel Debug")]
        public GameObject panelDebug;
        public bool isDebug;

        [Header("Panel Reward Message")]
        public GameObject panelReward;              // Rewards panel
        public Text textReward;                     // Reward Text to show an explanatory message to the player
        public Button buttonCloseReward;            // The Button to close the Rewards Panel

        [Header("Panel Reward")]
        public GameObject buttonClaimGo;            // Claim Button Game Object (To enable/disable)
        public GameObject buttonCloseGo;            // Close Button Game Object (To enable/disable)
        public Button buttonClaim;                  // Claim Button
        public Button buttonClose;                  // Close Button
        public Text textTimeDue;                    // Text showing how long until the next claim
        public GridLayoutGroup dailyRewardsGroup;   // The Grid that contains the rewards
        public ScrollRect scrollRect;               // The Scroll Rect
        public Image imageReward;                   // The image of the reward

        private bool readyToClaim;                  // Update flag
        private List<DailyRewardUI> dailyRewardsUI = new List<DailyRewardUI>();
        public Text remainingtimeText;
        void Awake()
        {
            canvas.gameObject.SetActive(false);
        }

        void Start()
        {
            InitializeDailyRewardsUI();
            panelDebug.SetActive(isDebug);
            buttonCloseGo.SetActive(false);

            buttonClaim.onClick.AddListener(() =>
            {
                DailyRewards.instance.ClaimPrize();
                readyToClaim = false;
                UpdateUI();
            });

            buttonCloseReward.onClick.AddListener(() =>
            {
                var keepOpen = DailyRewards.instance.keepOpen;
                panelReward.SetActive(false);
                canvas.gameObject.SetActive(keepOpen);
            });

            buttonClose.onClick.AddListener(() =>
            {
                canvas.gameObject.SetActive(false);
            });
        }

        void OnEnable()
        {
            DailyRewards.onClaimPrize += OnClaimPrize;
            DailyRewards.onInitialize += OnInitialize;
        }

        void OnDisable()
        {
            DailyRewards.onClaimPrize -= OnClaimPrize;
            DailyRewards.onInitialize -= OnInitialize;
        }

        // Initializes the UI List based on the rewards size
        private void InitializeDailyRewardsUI()
        {
            for (int i = 0; i < DailyRewards.instance.rewards.Count; i++)
            {
                int day = i + 1;
                var reward = DailyRewards.instance.GetReward(day);

                GameObject dailyRewardGo = GameObject.Instantiate(dailyRewardPrefab) as GameObject;

                DailyRewardUI dailyRewardUI = dailyRewardGo.GetComponent<DailyRewardUI>();
                dailyRewardUI.transform.SetParent(dailyRewardsGroup.transform);
                dailyRewardGo.transform.localScale = Vector2.one;

                dailyRewardUI.day = day;
                dailyRewardUI.reward = reward;
                dailyRewardUI.Initialize();

                dailyRewardsUI.Add(dailyRewardUI);
            }
        }

        public void UpdateUI()
        {
            DailyRewards.instance.CheckRewards();

            bool isRewardAvailableNow = false;

            var lastReward = DailyRewards.instance.lastReward;
            var availableReward = DailyRewards.instance.availableReward;

            foreach (var dailyRewardUI in dailyRewardsUI)
            {
                var day = dailyRewardUI.day;

                if (day == availableReward)
                {
                    dailyRewardUI.state = DailyRewardUI.DailyRewardState.UNCLAIMED_AVAILABLE;

                    isRewardAvailableNow = true;
                }
                else if (day <= lastReward)
                {
                    dailyRewardUI.state = DailyRewardUI.DailyRewardState.CLAIMED;
                }
                else
                {
                    dailyRewardUI.state = DailyRewardUI.DailyRewardState.UNCLAIMED_UNAVAILABLE;
                }

                dailyRewardUI.Refresh();
            }

            buttonClaimGo.SetActive(isRewardAvailableNow);
            buttonCloseGo.SetActive(!isRewardAvailableNow);
            if (isRewardAvailableNow)
            {
                SnapToReward();
                textTimeDue.text = "You can claim your reward!";
                remainingtimeText.text = "Ready";
            }
            readyToClaim = isRewardAvailableNow;
        }

        // Snap to the next reward
        public void SnapToReward()
        {
            Canvas.ForceUpdateCanvases();

            var lastRewardIdx = DailyRewards.instance.lastReward;

            // Scrolls to the last reward element
            if (dailyRewardsUI.Count <= lastRewardIdx)
            {
                lastRewardIdx++;
            }
            var target = dailyRewardsUI[lastRewardIdx].GetComponent<RectTransform>();

            var content = scrollRect.content;

            //content.anchoredPosition = (Vector2)scrollRect.transform.InverseTransformPoint(content.position) - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);

            float normalizePosition = (float)target.GetSiblingIndex() / (float)content.transform.childCount;
            scrollRect.verticalNormalizedPosition = normalizePosition;
        }

        void Update()
        {
            // Updates the time due
            if (!readyToClaim)
            {
                TimeSpan difference = (DailyRewards.instance.lastRewardTime - DailyRewards.instance.now).Add(new TimeSpan(0, 24, 0, 0));

                // If the counter below 0 it means there is a new reward to claim
                if (difference.TotalSeconds <= 0)
                {
                    readyToClaim = true;
                    UpdateUI();
                    SnapToReward();
                    return;
                }

                string formattedTs = string.Format("{0:D2}:{1:D2}:{2:D2}", difference.Hours, difference.Minutes, difference.Seconds);

                textTimeDue.text = string.Format("Come back in {0} for your next reward", formattedTs);
                remainingtimeText.text = formattedTs;
            }
        }

        // Delegate
        private void OnClaimPrize(int day)
        {
            panelReward.SetActive(true);

            var reward = DailyRewards.instance.GetReward(day);
            var unit = reward.unit;
            var rewardQt = reward.reward;
            imageReward.sprite = reward.sprite;
            if (rewardQt > 0)
            {
                textReward.text = string.Format("You got {0} {1}!", reward.reward, unit);
                PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+ reward.reward);
            }
            else
            {
                textReward.text = string.Format("You got {0}!", unit);
            }
        }

        private void OnInitialize(bool error, string errorMessage)
        {
            if (!error)
            {
                var showWhenNotAvailable = DailyRewards.instance.keepOpen;
                var isRewardAvailable = DailyRewards.instance.availableReward > 0;

                canvas.gameObject.SetActive(showWhenNotAvailable || (!showWhenNotAvailable && isRewardAvailable));
                UpdateUI();

                SnapToReward();
            }
        }

        // Resets player preferences
        public void OnResetClick()
        {
            DailyRewards.instance.Reset();
            DailyRewards.instance.lastRewardTime = System.DateTime.MinValue;
            readyToClaim = false;

            UpdateUI();
        }

        // Simulates the next day
        public void OnAdvanceDayClick()
        {
            DailyRewards.instance.now = DailyRewards.instance.now.AddDays(1);

            UpdateUI();
        }

        // Simulates the next hour
        public void OnAdvanceHourClick()
        {
            DailyRewards.instance.now = DailyRewards.instance.now.AddHours(1);

            UpdateUI();
        }

    }
}
/***************************************************************************\
Project:      Daily Rewards
Copyright (c) Niobium Studios.
Author:       Guilherme Nunes Barbosa (gnunesb@gmail.com)
\***************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Globalization;

/* 
 * Timed Rewards Canvas is the User interface to show Timed rewards
 */
namespace NiobiumStudios
{
    public class TimedRewardsInterface : MonoBehaviour
    {
        public GameObject canvas;

        [Header("Panel Debug")]
        public GameObject panelDebug;
        public bool isDebug;

        [Header("Panel Reward")]
        public Button buttonClaim;                  // The button to claim the reward
        public Text textInfo;                       // Informative text about the reward

        [Header("Panel Reward Message")]
        public GameObject panelReward;              // Rewards panel
        public Text textReward;                     // Reward Text to show an explanatory message to the player
        public Button buttonCloseReward;            // The Button to close the Rewards Panel
        public Image imageRewardMessage;            // The Image of the reward

        [Header("Panel Available Rewards")]
        public GameObject panelAvailableRewards;    // Available Rewards panel
        public GameObject rewardPrefab;             // The prefab that contains the reward
        public GridLayoutGroup rewardsGroup;        // The Grid that contains the rewards
        public ScrollRect scrollRect;               // The Scroll Rect

        private List<TimedRewardUI> rewardsUI = new List<TimedRewardUI>();

        void Awake()
        {
            canvas.SetActive(false);
            if (!isDebug)
            {
                panelDebug.SetActive(false);
            }
        }

        void Start()
        {
            InitializeAvailableRewardsUI();
            buttonClaim.interactable = false;
            panelAvailableRewards.SetActive(false);

            buttonClaim.onClick.AddListener(() =>
            {
                buttonClaim.interactable = false;
                // On single rewards automatically claims
                if (TimedRewards.instance.rewards.Count == 1)
                {
                    ClaimReward(0);
                }
                else
                {
                    // On multiple rewards shows the Available Rewards panel
                    panelAvailableRewards.SetActive(true);
                }
            });

            buttonCloseReward.onClick.AddListener(() =>
            {
                panelAvailableRewards.SetActive(false);
                panelReward.SetActive(false);
            });
        }

        void OnEnable()
        {
            TimedRewards.onCanClaim += OnCanClaim;
            TimedRewards.onInitialize += OnInitialize;
        }

        void OnDisable()
        {
            TimedRewards.onCanClaim -= OnCanClaim;
            TimedRewards.onInitialize -= OnInitialize;
        }

        void Update()
        {
            // Updates the timer UI
            TimeSpan timer = TimedRewards.instance.timer;
            if (timer.TotalSeconds > 0)
            {
                textInfo.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timer.Hours, timer.Minutes, timer.Seconds);
            }
        }

        // Initializes the UI List based on the rewards size
        private void InitializeAvailableRewardsUI()
        {
            // Initializes only when there is more than one Reward
            if (TimedRewards.instance.rewards.Count > 1)
            {
                for (int i = 0; i < TimedRewards.instance.rewards.Count; i++)
                {
                    var reward = TimedRewards.instance.GetReward(i);

                    GameObject dailyRewardGo = GameObject.Instantiate(rewardPrefab) as GameObject;

                    TimedRewardUI rewardUI = dailyRewardGo.GetComponent<TimedRewardUI>();

                    rewardUI.index = 0;

                    rewardUI.transform.SetParent(rewardsGroup.transform);
                    dailyRewardGo.transform.localScale = Vector2.one;

                    rewardUI.button.onClick.AddListener(OnClickReward(i));

                    rewardUI.reward = reward;
                    rewardUI.Initialize();

                    rewardsUI.Add(rewardUI);
                }
            }
        }

        // The action on the button when claiming the reward
        private UnityEngine.Events.UnityAction OnClickReward(int index)
        {
            return () =>
            {
                panelAvailableRewards.SetActive(false);
                ClaimReward(index);
            };
        }

        // Resets player preferences. Debug Purposes
        public void OnResetClick()
        {
            TimedRewards.instance.Reset();
            buttonClaim.interactable = true;
        }

        // Claimed the reward
        private void ClaimReward(int index)
        {
            TimedRewards.instance.ClaimReward(index);

            panelReward.SetActive(true);

            var reward = TimedRewards.instance.GetReward(index);
            var unit = reward.unit;
            var rewardQt = reward.reward;
            imageRewardMessage.sprite = reward.sprite;
            if (rewardQt > 0)
            {
                textReward.text = string.Format("You got {0} {1}!", reward.reward, unit);
            }
            else
            {
                textReward.text = string.Format("You got {0}!", unit);
            }
        }

        // Delegate
        // Updates the UI
        private void OnCanClaim()
        {
            buttonClaim.interactable = true;
            textInfo.text = "Reward Ready!";
        }

        private void OnInitialize(bool error, string errorMessage)
        {
            if (!error)
            {
                canvas.gameObject.SetActive(true);
            }
        }

    }
}
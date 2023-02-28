/***************************************************************************\
Project:      Daily Rewards
Copyright (c) Niobium Studios.
Author:       Guilherme Nunes Barbosa (gnunesb@gmail.com)
\***************************************************************************/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace NiobiumStudios
{
    /**
    * Timed Rewards Canvas is the User interface to show Timed rewards
    **/
    public class TimedRewards : DailyRewardsCore<TimedRewards>
    {
        public DateTime lastRewardTime;     // The last time the user clicked in a reward
        public TimeSpan timer;
        public float maxTime = 3600f; // How many seconds until the player can claim the reward

        public List<Reward> rewards;

        public delegate void OnCanClaim();              // When the player can claim the reward
        public static OnCanClaim onCanClaim;

        public delegate void OnClaimPrize(int index);   // When the player claims the prize
        public static OnClaimPrize onClaimPrize;

        private bool canClaim;              // Checks if the user can claim the reward

        // Needed Constants
        private const string TIMED_REWARDS_TIME = "TimedRewardsTime";
        private const string FMT = "O";

        void Start()
        {
            StartCoroutine(InitializeTimer());
        }

        // Initializes the timer in case the user already have a player preference
        private IEnumerator InitializeTimer()
        {
            yield return StartCoroutine(base.InitializeDate());

            if (base.isErrorConnect)
            {
                onInitialize(true, base.errorMessage);
            }
            else
            {
                string lastRewardTimeStr = PlayerPrefs.GetString(TIMED_REWARDS_TIME);

                if (!string.IsNullOrEmpty(lastRewardTimeStr))
                {
                    lastRewardTime = DateTime.ParseExact(lastRewardTimeStr, FMT, CultureInfo.InvariantCulture);

                    timer = (lastRewardTime - now).Add(TimeSpan.FromSeconds(maxTime));
                }
                else
                {
                    timer = TimeSpan.FromSeconds(maxTime);
                }
                onInitialize();
            }

        }

        void Update()
        {
            if (!isInitialized)
            {
                return;
            }
            // Keep track of the current time
            now = now.AddSeconds(Time.unscaledDeltaTime);

            // Keeps ticking until the player claims
            if (!canClaim)
            {
                timer = timer.Subtract(TimeSpan.FromSeconds(Time.unscaledDeltaTime));

                if (timer.TotalSeconds <= 0)
                {
                    canClaim = true;
                    if (onCanClaim != null)
                    {
                        onCanClaim();
                    }
                }
                else
                {
                    // We need to save the player time every tick. If the player exits the game the information keeps logged
                    // For perfomance issues you can save this information when the player switches scenes or quits the application
                    PlayerPrefs.SetString(TIMED_REWARDS_TIME, now.Add(timer - TimeSpan.FromSeconds(maxTime)).ToString(FMT));
                }
            }
        }

        // The player claimed the prize. We need to reset to restart the timer
        public void ClaimReward(int rewardIdx)
        {
            PlayerPrefs.SetString(TIMED_REWARDS_TIME, now.Add(timer - TimeSpan.FromSeconds(maxTime)).ToString(FMT));
            timer = TimeSpan.FromSeconds(maxTime);

            canClaim = false;

            if (onClaimPrize != null)
            {
                onClaimPrize(rewardIdx);
            }
        }

        // Resets the Timed Rewards. For debug purposes
        public void Reset()
        {
            PlayerPrefs.DeleteKey(TIMED_REWARDS_TIME);
            canClaim = true;
            timer = TimeSpan.FromSeconds(0);

            if (onCanClaim != null)
            {
                onCanClaim();
            }
        }

        // Returns a reward from an index
        public Reward GetReward(int index)
        {
            return rewards[index];
        }
    }
}
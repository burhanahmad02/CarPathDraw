/***************************************************************************\
Project:      Daily Rewards
Copyright (c) Niobium Studios.
Author:       Guilherme Nunes Barbosa (gnunesb@gmail.com)
\***************************************************************************/
using UnityEngine;
using NiobiumStudios;

/** 
 * This is just a snippet of code to integrate Timed Rewards into your project
 * 
 * Copy / Paste the code below
 **/
public class IntegrationTimedRewards : MonoBehaviour
{
    void OnEnable()
    {
        TimedRewards.onClaimPrize += OnClaimPrizeTimedRewards;
    }

    void OnDisable()
    {
        TimedRewards.onClaimPrize -= OnClaimPrizeTimedRewards;
    }

    // this is your integration function. Can be on Start or simply a function to be called
    public void OnClaimPrizeTimedRewards(int index)
    {
        // This returns a Reward object
        Reward myReward = TimedRewards.instance.GetReward(index);


        // And you can access any property
        print(myReward.unit);   // This is your reward Unit name
        print(myReward.reward); // This is your reward count
    }


}
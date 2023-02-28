using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollect : MonoBehaviour
{
   
    public AudioClip coinnCollect;
    public AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        audio.PlayOneShot(coinnCollect, 0.7F);
    }

}

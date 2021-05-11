using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicePlayer : MonoBehaviour
{
    public AudioClip[] voices;
    private AudioSource player;

    void Awake()
    {
        player = GetComponent<AudioSource>();
        if(player == null)
        {
            player = gameObject.AddComponent<AudioSource>();
        }
    }

    public void Play(int voiceIndex)
    {
        if(voiceIndex >= 0 && voiceIndex < voices.Length)
        {
            player.clip = voices[voiceIndex];
            player.Play();
            Debug.Log("Play voice: " + player.clip.name);
        }
    }
}

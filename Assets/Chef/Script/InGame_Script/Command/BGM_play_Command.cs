using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_play_Command : Command_Parents, Event_interface
{
    public AudioClip audio_BGM;
    private AudioSource audioSourecs;
    public HapticClip clip;
    public BGM_play_Command(AudioClip audio_BGM, HapticClip clip)
    {
        this.audio_BGM = audio_BGM;
        this.clip = clip;
    }

    public void Event()
    {
        if (audio_BGM == null) { Debug.Log("õ]”–“Ù–ß"); return; }

        audioSourecs = Camera.main.GetComponent<AudioSource>();

        audioSourecs.clip = audio_BGM;
        audioSourecs.Play();
        audioSourecs.loop=true;
        if (clip != null) {
            HapticController.Play(clip);
            HapticController.Loop(true);
        }
    }
}

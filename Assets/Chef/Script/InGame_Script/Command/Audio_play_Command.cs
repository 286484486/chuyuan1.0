using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_play_Command : Command_Parents, Event_interface
{
    public AudioClip auidio_se;
    private AudioSource audioSourecs;
    public HapticClip clip;
    public Audio_play_Command(AudioClip auidio_se, HapticClip clip)
    {
        this.auidio_se = auidio_se;
        this.clip = clip;
    }

    public void Event()
    {
        if (auidio_se == null) { Debug.Log("õ]”–“Ù–ß"); return; }

        audioSourecs = Instantiate(Game_admin.game_admin_static.audio_play_object_prefab).GetComponent<AudioSource>();
        audioSourecs.clip = auidio_se;
        audioSourecs.Play();
        
        if (clip != null)
        {
            HapticController.Play(clip);
            HapticController.Loop(false);
        }
        
    }
}

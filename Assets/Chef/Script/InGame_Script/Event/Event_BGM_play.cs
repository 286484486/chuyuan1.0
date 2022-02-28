using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Lofelt.NiceVibrations;

public class Event_BGM_play : Event_parents
{
    [Title("≤•∑≈±≥æ∞“Ù")]
    public AudioClip audio_BGM;
    [Title("≤•∑≈”|”X")]
    public HapticClip clip;

    protected override void Event_on(string mode)
    {
        Event_interface c = new BGM_play_Command(audio_BGM,clip);
        Event_send(mode, c);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Lofelt.NiceVibrations;

public class Event_Audio_play : Event_parents
{
    [Title("播放音效")]
    public AudioClip auidio_se;
    [Title("音效只使用一次")]
    public bool auidio_once;
    [Title("播放觸覺")]
    public HapticClip clip;
    protected override void Event_on(string mode)
    {
        Event_interface c = new Audio_play_Command(auidio_se, clip);
        Event_send(mode, c);
        if (auidio_once)
        {
            Destroy(gameObject.GetComponent<Event_Audio_play>());
        }
    }
}

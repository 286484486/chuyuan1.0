using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Lofelt.NiceVibrations;

public class Event_Audio_play : Event_parents
{
    [Title("������Ч")]
    public AudioClip auidio_se;
    [Title("��Чֻʹ��һ��")]
    public bool auidio_once;
    [Title("�����|�X")]
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

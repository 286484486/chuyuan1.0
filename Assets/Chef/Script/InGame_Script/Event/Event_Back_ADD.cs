using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Back_ADD : Event_parents
{
    [Title("���÷��ؼ����صĳ���id")]
    [SceneObjectsOnly]
    public GameObject room_index;

    protected override void Event_on(string mode)
    {
        Event_interface c = new Back_ADD_Command(room_index);
        Event_send(mode, c);
    }
}

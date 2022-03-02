using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Spine_Play : Event_parents
{
    [Title("���")]
    public GameObject Spine_obj;
    [Title("��������")]
    public string Spine_anime_name;
    [Title("�Ƿ�ѭ��")]
    public bool Spine_loop;
    protected override void Event_on(string mode)
    {
        Event_interface c = new Spine_Play_Command(Spine_obj, Spine_anime_name, Spine_loop);
        Event_send(mode, c);
    }
}

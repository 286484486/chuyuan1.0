using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class Event_switch : Event_parents
{
    [Title("�������ʱ��ʾ,��ʾʱ����")]
    [SceneObjectsOnly]
    public List<GameObject> obj=new List<GameObject>();

    protected override void Event_on(string mode)
    {
        Event_interface c = new item_switch_Command(obj);
        Event_send(mode, c);
    }
}

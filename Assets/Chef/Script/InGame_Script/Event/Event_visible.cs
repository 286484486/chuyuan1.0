using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_visible : Event_parents
{
    [Title("���õ�������ػ���ʾ")]
    [DictionaryDrawerSettings(KeyLabel = "���", ValueLabel = "��ʾ")]
    [SceneObjectsOnly]
    public Dictionary<GameObject,bool> obj = new Dictionary<GameObject, bool>();
    //[Header("���ػ���ʾ")]
    //public List<bool> obj_bool;

    protected override void Event_on(string mode)
    {
        Event_interface c = new item_visible_Command(obj);
        Event_send(mode, c);
    }
}

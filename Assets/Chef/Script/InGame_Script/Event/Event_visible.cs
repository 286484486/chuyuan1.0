using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_visible : Event_parents
{
    [Title("设置的物件隐藏或显示")]
    [DictionaryDrawerSettings(KeyLabel = "物件", ValueLabel = "显示")]
    [SceneObjectsOnly]
    public Dictionary<GameObject,bool> obj = new Dictionary<GameObject, bool>();
    //[Header("隐藏或显示")]
    //public List<bool> obj_bool;

    protected override void Event_on(string mode)
    {
        Event_interface c = new item_visible_Command(obj);
        Event_send(mode, c);
    }
}

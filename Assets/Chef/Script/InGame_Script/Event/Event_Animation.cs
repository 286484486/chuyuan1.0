using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Animation : Event_parents
{
    [Title("设置的物件播放的动画id")]
    [DictionaryDrawerSettings(KeyLabel = "物件", ValueLabel = "动画id")]
    [SceneObjectsOnly]
    public Dictionary<GameObject, string> obj = new Dictionary<GameObject, string>();
    [Title("动画模式参数")]
    public string anime_mode;
    //[Header("隐藏或显示")]
    //public List<bool> obj_bool;

    protected override void Event_on(string mode)
    {
        Event_interface c = new Animation_Command(obj,anime_mode);
        Event_send(mode, c);
    }
}

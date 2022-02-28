using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_image_change : Event_parents
{
    /*
    [Header("要更改图片的物件")]
    [SceneObjectsOnly]
    public List<GameObject> obj;
    [Header("改成什么图片")]
    public List<Sprite> obj_change;
    */
    [Title("要更改图片的物件   改成什么图片")]
    [DictionaryDrawerSettings(KeyLabel = "物件", ValueLabel = "图片")]
    public Dictionary<GameObject, Sprite> obj = new Dictionary<GameObject, Sprite>();
    protected override void Event_on(string mode)
    {
        Event_interface c = new image_change_Command(obj);
        Event_send(mode, c);
    }
}

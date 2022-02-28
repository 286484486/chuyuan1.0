using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Destroy : Event_parents
{
    [Title("要删除的物件")]
    [SceneObjectsOnly]
    public List<GameObject> obj;

    protected override void Event_on(string mode)
    {
        Event_interface c = new Destroy_Command(obj);
        Event_send(mode, c);
    }
}

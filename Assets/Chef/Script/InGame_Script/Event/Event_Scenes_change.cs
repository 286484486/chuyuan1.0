using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Scenes_change : Event_parents
{
    [Title("ˆö¾°Ãû×Ö")]
    public new string name;

    protected override void Event_on(string mode)
    {
        Event_interface c = new Scenes_change_Command(name);
        Event_send(mode, c);
    }
}


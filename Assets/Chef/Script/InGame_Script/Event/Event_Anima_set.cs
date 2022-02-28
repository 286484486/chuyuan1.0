using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Anima_set : Event_parents
{
    [Title("¶¯»­Ãû³Æ")]
    public string anima_name;

    protected override void Event_on(string mode)
    {
        Anima_interface c = new Obj_anima_ACommand(anima_name);
        Event_send(mode, c);
    }
}

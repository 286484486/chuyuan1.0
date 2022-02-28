using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Empty : Event_parents
{
    protected override void Event_on(string mode)
    {

        Event_interface c = new Empty_Command();
        Event_send(mode, c);
    }
}

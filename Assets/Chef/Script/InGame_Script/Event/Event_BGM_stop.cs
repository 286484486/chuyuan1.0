using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Lofelt.NiceVibrations;

public class Event_BGM_stop : Event_parents
{


    protected override void Event_on(string mode)
    {
        Event_interface c = new BGM_stop_Command();
        Event_send(mode, c);

    }
}

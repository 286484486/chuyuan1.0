using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Camera_jitter : Event_parents
{
    [Title("¶¶¶¯Ê±¼ä")]
    public float camera_jitter_time;
    protected override void Event_on(string mode)
    {

        Anima_interface c = new Camera_jitter_Command(camera_jitter_time);
        Event_send(mode, c);
    }
}

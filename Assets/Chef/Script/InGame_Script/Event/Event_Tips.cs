using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Tips : Event_parents
{
    [Title("ÎÄ±¾")]
    [TextArea]
    public string tips_text;

    protected override void Event_on(string mode)
    {
        Event_interface c = new Tips_Command(tips_text);
        Event_send(mode, c);
    }
}
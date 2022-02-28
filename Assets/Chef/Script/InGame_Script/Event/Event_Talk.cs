using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Event_Talk : Event_parents
{
    [Header("¶Ô»°Script")]
    public TalkSaveScript key;



    protected override void Event_on(string mode)
    {
       Event_interface c = new Talk_Command(key, Talk_control.TK_static);
       Event_send(mode, c);

    }
}

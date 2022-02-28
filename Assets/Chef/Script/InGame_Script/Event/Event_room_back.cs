using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_room_back : Event_parents
{
    protected override void Event_on(string mode)
    {

        Event_interface c = new room_back_Command();
        Event_send(mode, c);
    }
}

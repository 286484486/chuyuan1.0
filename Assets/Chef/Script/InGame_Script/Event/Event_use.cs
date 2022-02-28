using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_use : Event_parents
{
    // Start is called before the first frame update
    protected override void Event_on(string mode)
    {
        Event_interface c = new item_Use_Command(Bag_script.Bag_select);
        Event_send(mode, c);
    }
}

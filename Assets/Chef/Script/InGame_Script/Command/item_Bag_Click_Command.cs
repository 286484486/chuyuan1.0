using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_Bag_Click_Command : Command_Parents, Event_interface
{
    GameObject item;
    public item_Bag_Click_Command(GameObject item)
    {
        this.item = item;
    }

    public void Event()
    {
        if (Bag_script.Bag_select == item)
        {
            Bag_script.Bag_select = null;
        }
        else
        {
            Bag_script.Bag_select = item;
        }

        Bag_script.phoneitem_Reset();
    }
}

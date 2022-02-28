using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_visible_Command : Command_Parents, Event_interface
{
    Dictionary<GameObject, bool> obj;
    //List<bool> obj_bool;
    public item_visible_Command(Dictionary<GameObject, bool> obj)
    {
        this.obj = obj;
        //this.obj_bool = obj_bool;
    }

    public void Event()
    {
        foreach (GameObject key in obj.Keys)
        {
            if (key != null)
            {
                key.SetActive(obj[key]);
                /*
                if (key.GetComponent<Event_parents>() != null)
                {
                    key.GetComponent<Event_parents>().Script_on = obj[key];
                }
                */
            }
        }
    }
}

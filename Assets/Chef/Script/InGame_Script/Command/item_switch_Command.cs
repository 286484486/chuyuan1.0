using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_switch_Command : Command_Parents, Event_interface
{
    List<GameObject> obj;
    public item_switch_Command(List<GameObject> obj)
    {
        this.obj = obj;

    }

    public void Event()
    {
        for (int i = 0; i < obj.Count; i++)
        {
            if (obj[i] != null)
            {
                obj[i].SetActive(!obj[i].activeSelf);
                /*
                if (obj[i].GetComponent<Event_parents>() != null)
                {
                    obj[i].GetComponent<Event_parents>().Script_on = obj[i].activeSelf;
                }
                */
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class image_change_Command : Command_Parents, Event_interface
{
    Dictionary<GameObject, Sprite> obj;
    public image_change_Command(Dictionary<GameObject, Sprite> obj)
    {
        this.obj = obj;
    }

    public void Event()
    {
        foreach (GameObject key in obj.Keys)
        {
            if (key != null)
            {
                key.GetComponent<SpriteRenderer>().sprite = obj[key];
            }
        }
    }

}

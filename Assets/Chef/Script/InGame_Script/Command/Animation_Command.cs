using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Command : Command_Parents, Event_interface
{
    Dictionary<GameObject, string> obj;
    string mode;
    public Animation_Command(Dictionary<GameObject, string> obj,string mode)
    {
        this.obj = obj;
        this.mode = mode;
    }

    public void Event()
    {
        foreach (GameObject key in obj.Keys)
        {
            if (key != null)
            {
                key.SetActive(true);
                key.GetComponent<Animation>().Play(obj[key]);
                Anima_interface c = new Animation_ACommand(key, mode);
                Event_Invoker.AddCommand(c);
            }
        }


    }

}

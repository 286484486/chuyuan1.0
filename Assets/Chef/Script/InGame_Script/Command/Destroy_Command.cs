using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Command : Command_Parents, Event_interface
{
    List<GameObject> obj;
    public Destroy_Command(List<GameObject> obj)
    {
        this.obj = obj;
    }

    public void Event()
    {
        for (int i = 0; i < obj.Count; i++)
        {
            if (obj[i] != null)
            {
                Destroy(obj[i]);
            }
        }
    }
}

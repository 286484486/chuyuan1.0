using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_stop_Command : Command_Parents, Event_interface
{
    GameObject obj;
    public Obj_stop_Command(GameObject obj)
    {
        this.obj = obj;

    }

    public void Event()
    {
        Event_Invoker.text_command = "stop";
    }
}

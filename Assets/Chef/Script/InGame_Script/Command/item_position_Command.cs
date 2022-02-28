using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_position_Command : Command_Parents, Event_interface
{
    GameObject obj;
    Vector2 pos;
    public item_position_Command(GameObject obj, Vector2 pos)
    {
        this.obj = obj;
        this.pos = pos;
    }

    public void Event()
    {
        if (obj == null) { return; }
        obj.GetComponent<Transform>().position = pos;
    }
}

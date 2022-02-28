using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_depth_Command : Command_Parents, Event_interface
{
    GameObject obj;
    int depth;
    public item_depth_Command(GameObject obj, int depth)
    {
        this.obj = obj;
        this.depth = depth;
    }

    public void Event()
    {
        obj.GetComponent<SpriteRenderer>().sortingOrder = depth;
    }
}

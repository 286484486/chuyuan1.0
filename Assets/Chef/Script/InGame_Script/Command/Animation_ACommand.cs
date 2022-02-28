using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_ACommand : Command_Parents, Anima_interface
{
    GameObject obj;
    string mode;
    public Animation_ACommand(GameObject obj, string mode)
    {
        this.obj = obj;
        this.mode = mode;
    }

    public void Anima(int i)
    {
        if (obj == null) { Event_Invoker.RemoveACommnad(i); return; }
        Animation anime = obj.GetComponent<Animation>();



        if (anime.isPlaying == false) {
            if (mode == "active")
            {
                obj.SetActive(true);
            }
            if (mode == "deactive")
            {
                obj.SetActive(false);
            }

            Event_Invoker.RemoveACommnad(i);
        }

    }
}

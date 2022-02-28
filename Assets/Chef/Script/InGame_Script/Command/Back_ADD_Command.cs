using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_ADD_Command : Command_Parents, Event_interface
{
    GameObject room_index;
    public Back_ADD_Command(GameObject room_index)
    {
        this.room_index = room_index;
    }

    public void Event()
    {
        if (room_index == null) { return; }
        Game_admin.Back_camera.Add(room_index);
        Game_admin.Back_obj.SetActive(true);
    }
}

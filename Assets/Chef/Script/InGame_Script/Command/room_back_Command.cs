using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_back_Command : Command_Parents, Event_interface
{
    public void Event()
    {
        Game_admin.game_admin_static.Back_Camera();
    }
}

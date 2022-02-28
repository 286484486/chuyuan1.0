using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenes_change_Command : Command_Parents, Event_interface
{
    new string name;
    public Scenes_change_Command(string name)
    {
        this.name = name;
    }


    public void Event()
    {
        Game_admin.game_admin_static.Black_windows_play_change_screen(name);
    }
}

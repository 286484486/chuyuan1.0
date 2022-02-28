using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_Change_Command : Command_Parents, Event_interface
{
    GameObject room_index;
    bool room_mini_game;
    int room_mini_game_index;
    public room_Change_Command(GameObject room_index,bool room_mini_game,int room_mini_game_index)
    {
        this.room_index = room_index;
        this.room_mini_game = room_mini_game;
        this.room_mini_game_index = room_mini_game_index;
    }
    
    public void Event()
    {
        if(room_index == null)
        {
            Debug.Log("õ]”–∑≈÷√îzœÒÕ∑");
            return;
        }
        Camera main_camera;
        main_camera = Camera.main;
        main_camera.GetComponent<Transform>().position = room_index.GetComponent<Transform>().position;
        main_camera.GetComponent<Camera>().orthographicSize = room_index.GetComponent<Camera>().orthographicSize;
        if (room_mini_game)
        {
            Game_admin.mini_Game_control.SetActive(true);
            Game_admin.mini_Game_control.GetComponent<mini_Game_set_Script>().Tips_set.SetActive(true);
            Game_admin.mini_Game_control.GetComponent<mini_Game_set_Script>().room_mini_game_index = room_mini_game_index;
            Game_admin.mini_Game_control.GetComponent<mini_Game_set_Script>().room_mini_game_index_script();
        }

    }
}

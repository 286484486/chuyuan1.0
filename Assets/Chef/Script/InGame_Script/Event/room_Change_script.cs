using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class room_Change_script : Event_parents
{
    [Title("����id")]
    [SceneObjectsOnly]
    public GameObject room_index;
    // Start is called before the first frame update
    [Title("���÷��ؼ����صĳ���id")]
    [SceneObjectsOnly]
    public GameObject room_back;
    [Title("�Ƿ���С��Ϸ��ť")]
    public bool room_mini_game;
    [Title("С��Ϸ���")]
    public int room_mini_game_index;

    protected override void Event_on(string mode)
    {

        Event_interface c = new room_Change_Command(room_index, room_mini_game, room_mini_game_index);
        Event_send(mode, c);
        Event_interface d = new Back_ADD_Command(room_back);
        Event_send(mode, d);
    }
}

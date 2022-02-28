using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_move : Event_parents
{
    [Title("要移动的物件")]
    [SceneObjectsOnly]
    public GameObject obj;
    [Title("相对坐标")]
    public bool is_add;
    [Title("坐标x")]
    public float pos_x;
    [Title("坐标y")]
    public float pos_y;
    [Title("移动速度")]
    public float Obj_speed = 100;
    [Title("速度衰减")]
    public float Obj_speed_down=0;
    protected override void Event_on(string mode)
    {
        if (obj == null) { return; }
        float f_pos_x = pos_x;
        float f_pos_y = pos_y;
        if (is_add)
        {
            f_pos_x = obj.GetComponent<Transform>().position.x + pos_x;
            f_pos_y = obj.GetComponent<Transform>().position.y + pos_y;
        }
        Anima_interface c = new Obj_move_ACommand(obj, f_pos_x, f_pos_y, Obj_speed, Obj_speed_down, "target");
        Event_send(mode, c);
    }
}

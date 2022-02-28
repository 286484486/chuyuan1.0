using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Camera_size : Event_parents
{
    [Title("要缩放的摄像头")]
    [SceneObjectsOnly]
    public GameObject obj;
    [Title("相对大小")]
    public bool is_add;
    [Title("大小Size")]
    public float size;
    [Title("缩放速度")]
    public float Obj_speed = 100;

    [Title("缩放中心点")]
    public bool is_sizeport;
    [ShowIfGroup("@is_sizeport")]
    [BoxGroup("@is_sizeport/缩放中心点")]
    [Title("缩放中心点x")]
    public float is_sizeport_x;
    [ShowIfGroup("@is_sizeport")]
    [BoxGroup("@is_sizeport/缩放中心点")]
    [Title("缩放中心点y")]
    public float is_sizeport_y;
    [Title("缩放模式")]
    public bool size_mode;
    protected override void Event_on(string mode)
    {
        if (obj == null) { return; }
        float f_size = size;
        if (is_add)
        {
            f_size = obj.GetComponent<Camera>().orthographicSize + size;
        }
        float is_sizeport_spd = 0;
        if (is_sizeport && Obj_speed!=0)
        {
            float v_time,v_dis;
           v_time=Mathf.Abs(f_size- obj.GetComponent<Camera>().orthographicSize)/Obj_speed;
            v_dis = Vector2.Distance(obj.transform.position,new Vector2(is_sizeport_x,is_sizeport_y));
            is_sizeport_spd = v_dis / v_time;
        }
        Anima_interface c = new Camera_size_Command(obj, f_size, Obj_speed, size_mode, is_sizeport_spd, is_sizeport_x, is_sizeport_y);
        Event_send(mode, c);
    }
}

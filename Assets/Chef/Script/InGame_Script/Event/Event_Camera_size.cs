using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Camera_size : Event_parents
{
    [Title("Ҫ���ŵ�����ͷ")]
    [SceneObjectsOnly]
    public GameObject obj;
    [Title("��Դ�С")]
    public bool is_add;
    [Title("��СSize")]
    public float size;
    [Title("�����ٶ�")]
    public float Obj_speed = 100;
    [Title("����ģʽ")]
    public bool size_mode;
    protected override void Event_on(string mode)
    {
        if (obj == null) { return; }
        float f_size = size;
        if (is_add)
        {
            f_size = obj.GetComponent<Camera>().orthographicSize + size;
        }
        Anima_interface c = new Camera_size_Command(obj.GetComponent<Camera>(), f_size, Obj_speed, size_mode);
        Event_send(mode, c);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_size_Command : Command_Parents, Anima_interface
{
    GameObject obj;
    float size, spd;
    bool size_mode;

    public float is_sizeport_spd;
    public float is_sizeport_x;
    public float is_sizeport_y;
    public Camera_size_Command(GameObject obj, float size, float spd, bool size_mode,float is_sizeport_spd, float is_sizeport_x,float is_sizeport_y)
    {
        this.obj = obj;
        this.size = size;
        this.spd = spd;
        this.size_mode = size_mode;
        this.is_sizeport_spd = is_sizeport_spd;
        this.is_sizeport_x = is_sizeport_x;
        this.is_sizeport_y = is_sizeport_y;
    }
    
    public void Anima(int i)
    {
        if (obj == null) { Event_Invoker.RemoveACommnad(i); return; }
        if (size <1) { size = 1; }
            Camera C_size = obj.GetComponent<Camera>();
        if (is_sizeport_spd != 0)
        {
            Vector2 v_dis_pos = (new Vector2(is_sizeport_x, is_sizeport_y)- new Vector2(obj.transform.position.x, obj.transform.position.y)).normalized * is_sizeport_spd * Time.deltaTime;
            obj.transform.position = new Vector3(obj.transform.position.x + v_dis_pos.x, obj.transform.position.y + v_dis_pos.y, obj.transform.position.z);
        }
        if(C_size.orthographicSize != size)
        {
            if (!size_mode)
            {
                if (C_size.orthographicSize>size)
                {
                    C_size.orthographicSize -= spd*Time.deltaTime;
                    if (C_size.orthographicSize < size)
                    {
                        C_size.orthographicSize = size;
                    }
                }
                else
                {
                    C_size.orthographicSize += spd * Time.deltaTime;
                    if (C_size.orthographicSize > size)
                    {
                        C_size.orthographicSize = size;
                    }
                }
            }
            if (size_mode)
            {
                float v_spd = spd*Time.deltaTime;
                if (v_spd > 1) { v_spd = 1; }
                C_size.orthographicSize+=(size- C_size.orthographicSize) *v_spd;
                if (Mathf.Abs(size - C_size.orthographicSize)<1f)
                {
                    C_size.orthographicSize = size;
                }
            }
        }
        else
        {
            Event_Invoker.RemoveACommnad(i);
        }
    }
}

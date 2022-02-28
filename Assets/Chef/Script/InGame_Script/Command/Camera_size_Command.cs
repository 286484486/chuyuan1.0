using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_size_Command : Command_Parents, Anima_interface
{
    Camera obj;
    float size, spd;
    bool size_mode;
    public Camera_size_Command(Camera obj, float size, float spd, bool size_mode)
    {
        this.obj = obj;
        this.size = size;
        this.spd = spd;
        this.size_mode = size_mode;
    }
    
    public void Anima(int i)
    {
        if (obj == null) { Event_Invoker.RemoveACommnad(i); return; }

            Camera C_size = obj;
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

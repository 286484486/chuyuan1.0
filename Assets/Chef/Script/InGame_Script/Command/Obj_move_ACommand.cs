using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_move_ACommand : Command_Parents, Anima_interface
{
    GameObject obj;
    float pos_x, pos_y, spd, spd_down;
    string spd_mode;
    public Obj_move_ACommand(GameObject obj, float pos_x, float pos_y, float spd, float spd_down, string spd_mode)
    {
        this.obj = obj;
        this.pos_x = pos_x;
        this.pos_y = pos_y;
        this.spd = spd;
        this.spd_down = spd_down;
        this.spd_mode = spd_mode;
    }

    public void Anima(int i)
    {
        if (obj == null) { Event_Invoker.RemoveACommnad(i); return; }
        if (spd_mode == "target")
        {
            float step = spd * Time.deltaTime;
            Transform t_obj = obj.GetComponent<Transform>();
            Vector3 t_pos = new Vector3(pos_x, pos_y, t_obj.position.z);


            if (Vector3.Distance(t_obj.position, t_pos) > 0)
            {
                if (Vector3.Distance(t_obj.position, t_pos) - (spd * Time.deltaTime) < 0)
                {
                    t_obj.position = t_pos;
                    spd = 0;
                }
                else
                {

                    //Debug.Log((t_obj.position - t_pos).normalized);
                    t_obj.position += (t_pos - t_obj.position).normalized * spd * Time.deltaTime;
                    //t_obj.position =new Vector2(t_obj.position.x*t_dir * step, t_obj.position.y*t_dir*step);
                }
            }
        }
        if (spd_mode == "smooth")
        {
            float v_spd = spd * Time.deltaTime;
            Transform t_obj = obj.GetComponent<Transform>();
            Vector3 t_pos = new Vector3(pos_x, pos_y, t_obj.position.z);
            if (v_spd > 1) { v_spd = 1; }
            t_obj.position += (t_pos - t_obj.position).normalized * Vector3.Distance(t_obj.position, t_pos)*v_spd;
            if (Vector3.Distance(t_obj.position, t_pos) < 1f)
            {
                t_obj.position = t_pos;
                spd = 0;
            }

        }


        spd -= spd_down;
        if (spd < 0) { spd = 0; }
        if (Event_Invoker.text_command == "stop") { spd = 0; }
        if (spd == 0)
        {
            Event_Invoker.RemoveACommnad(i);
        }

    }
}
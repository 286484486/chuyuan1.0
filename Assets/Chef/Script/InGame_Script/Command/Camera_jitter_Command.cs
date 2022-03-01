using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_jitter_Command : Command_Parents, Anima_interface
{
    float camera_jitter_time;
    Vector2 org_pos;
    int mode;
    Vector2 set_pos_now;
    public Camera_jitter_Command(float camera_jitter_time)
    {
        this.camera_jitter_time = camera_jitter_time;
        this.org_pos = Camera.main.transform.position;
        this.set_pos_now = Camera.main.transform.position;
        this.mode = 0;
    }

    public void Anima(int i)
    {

        if (mode == 0)
        {
            camera_jitter_time -= Time.deltaTime;
            if (set_pos_now == new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y))
            {
                set_pos_now = new Vector2(org_pos.x+Random.Range(-100,100), org_pos.y + Random.Range(-100, 100));
            }


            if (camera_jitter_time <= 0)
            {
                mode = 1;
                set_pos_now = org_pos;
            }
        }

        if (mode == 1)
        {

        }

        float v_dis = Vector2.Distance(set_pos_now, new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y));
        if (v_dis > 0)
        {
            float v_spd = 5000 * Time.deltaTime;
            Vector2 v_dis_pos = (set_pos_now - new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y)).normalized  * v_spd;
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + v_dis_pos.x, Camera.main.transform.position.y + v_dis_pos.y, Camera.main.transform.position.z);
            if (Vector2.Distance(set_pos_now, new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y)) < v_spd/2)
            {
                Camera.main.transform.position = new Vector3(set_pos_now.x,set_pos_now.y, Camera.main.transform.position.z);
                if (mode == 1) { mode = 2; }
            }
        }


        if (mode == 2)
        {
            Event_Invoker.RemoveACommnad(i);
        }
    }
}

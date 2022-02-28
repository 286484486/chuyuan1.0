using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q1_angle_script : MonoBehaviour
{
    private bool draging;
    public float angle_set, angle_set_now;
    private Vector3 Pos_mouse;
    public bool locking;
    public float angle_power=1f;
    private EdgeCollider2D coll;
    private CircleCollider2D C_coll;
    public float Angle_delay=1;
    public float Angle_max = -1;
    // Start is called before the first frame update
    void Start()
    {
        //angle_Reset();
        angle_set = gameObject.transform.localEulerAngles.z;
        angle_set_now = angle_set;
        coll = gameObject.GetComponent<EdgeCollider2D>();
        C_coll = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localEulerAngles.z != angle_set)
        {
            angle_Move();
        }

        MDown();
        Mdrag();
        MUp();
    }

    private void MDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (coll != null)
            {
                if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    if (locking) { return; }
                    if (!Game_admin.Some_mode) { return; }
                    draging = true;
                    Pos_mouse = Input.mousePosition; //获取屏幕坐标
                    
                }
            }
            if (C_coll != null)
            {
                if (C_coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    if (locking) { return; }
                    if (!Game_admin.Some_mode) { return; }
                    draging = true;
                    Pos_mouse = Input.mousePosition; //获取屏幕坐标

                }
            }
        }
    }

    private void Mdrag()
    {
        if (draging)
        {
            if (Input.GetMouseButton(0))
            {
                float m_x, m_y, angle_set_x, angle_set_y;
                m_x = (Input.mousePosition.x - Pos_mouse.x) * angle_power;
                m_y = (Input.mousePosition.y - Pos_mouse.y) * angle_power;
                Vector3 m_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                angle_set_x = m_x;
                angle_set_y = m_y;
                if (m_pos.x < gameObject.transform.position.x)
                {
                    angle_set_y = m_y * -1;
                }
                if (m_pos.y > gameObject.transform.position.y)
                {
                    angle_set_x = m_x * -1;
                }


                if (Mathf.Abs(angle_set_x + angle_set_y) >= Angle_delay)
                {
                    float angle_add = Mathf.Floor((angle_set_x + angle_set_y) / Angle_delay);
                    angle_add = angle_add * Angle_delay;
                    if (Mathf.Abs(angle_add) > Angle_max && Angle_max != -1) {
                        if (angle_add > 0) { angle_add = Mathf.Floor(Angle_max/ Angle_delay)* Angle_delay; }
                        if (angle_add < 0) { angle_add = -Mathf.Floor(Angle_max / Angle_delay) * Angle_delay; }
                    }


                    Transform gTran = gameObject.transform;
                    gameObject.transform.rotation = Quaternion.AngleAxis(gameObject.transform.localEulerAngles.z + angle_add, Vector3.forward);
                    angle_set = gameObject.transform.localEulerAngles.z;
                    angle_set_now = gameObject.transform.localEulerAngles.z;

                    Pos_mouse = Input.mousePosition; //获取屏幕坐标
                }
            }
        }

    }


    private void MUp()
    {
        if (draging)
        {
            if (Input.GetMouseButtonUp(0))
            {
                angle_set = gameObject.transform.localEulerAngles.z;
                angle_set_now = gameObject.transform.localEulerAngles.z;
                draging = false;
                Q1_control.Q1_script.Q_mode2_angle();
            }
        }
    }

    /*
    private void OnMouseDown()
    {
        if (locking) { return; }
        draging = true;
        Pos_mouse = Input.mousePosition; //获取屏幕坐标
        //mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition); //屏幕坐标转世界坐标
        //mouseLocalPos = transform.parent.transform.InverseTransformPoint(mouseWorldPos); //世界坐标转本地坐标
        
    }
    

    private void OnMouseDrag()
    {
        if(draging)
        {
            float m_x, m_y,angle_set_x,angle_set_y;
            m_x = (Input.mousePosition.x - Pos_mouse.x)*angle_power;
            m_y = (Input.mousePosition.y - Pos_mouse.y)*angle_power;
            Vector3 m_pos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            angle_set_x = m_x;
            angle_set_y = m_y;
            if (m_pos.x < gameObject.transform.position.x)
            {
                angle_set_y = m_y * -1;
            }
            if (m_pos.y > gameObject.transform.position.y)
            {
                angle_set_x = m_x * -1;
            }

            Transform gTran = gameObject.transform;
            gameObject.transform.rotation = Quaternion.AngleAxis(gameObject.transform.localEulerAngles.z+angle_set_x + angle_set_y, Vector3.forward);
            angle_set = gameObject.transform.localEulerAngles.z;
            angle_set_now = gameObject.transform.localEulerAngles.z;

            Pos_mouse = Input.mousePosition; //获取屏幕坐标
        }
    }

    private void OnMouseUp()
    {
        draging = false;
    }

    */



    private void angle_Reset()
    {
        while (gameObject.GetComponent<Transform>().position.z < 0) { gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z+360); }
        while (gameObject.GetComponent<Transform>().position.z >= 360) { gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z - 360); }
    
    }

    private void angle_Move()
    {
        float v_spd = 5 * Time.deltaTime;
        float pos_z = angle_set_now;
        if (v_spd > 1) { v_spd = 1; }
        pos_z += (angle_set - pos_z) * v_spd;
        if (Mathf.Abs(angle_set - pos_z) < 1f)
        {
            pos_z = angle_set;
            while (angle_set >= 360) { angle_set -= 360; }
            while (angle_set < 0) { angle_set += 360; }
            while (angle_set_now >= 360) { angle_set_now -= 360; }
            while (angle_set_now < 0) { angle_set_now += 360; }
        }
        gameObject.transform.rotation = Quaternion.AngleAxis(pos_z, Vector3.forward);
        angle_set_now = pos_z;
    }

    public void Lock(float angle , bool v_lock)
    {
        locking = v_lock;
        angle_set = angle;
    }
    public void Lock( bool v_lock)
    {
        locking = v_lock;
    }
}

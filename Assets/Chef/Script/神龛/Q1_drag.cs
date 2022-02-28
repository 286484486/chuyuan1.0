using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q1_drag : MonoBehaviour
{
    public bool locking;
    private bool draging;
    private Vector3 Pos_mouse;
    public Q1_control Script;
    [HideInInspector]
    public int loc_now=-1;
    public int clear_loc;
    private CircleCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position != gameObject.transform.parent.position)
        {
            float v_spd = 15 * Time.deltaTime;
            Transform t_obj = gameObject.transform;
            Vector3 t_pos = gameObject.transform.parent.position;
            if (v_spd > 1) { v_spd = 1; }
            t_obj.position += (t_pos - t_obj.position).normalized * Vector3.Distance(t_obj.position, t_pos) * v_spd;
            if (Vector3.Distance(t_obj.position, t_pos) < 1f)
            {
                t_obj.position = t_pos;
            }
        }

        MDown();
        Mdrag();
        MUp();
    }

    private void MDown()
    {

        if (coll != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
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
                Pos_mouse = Input.mousePosition; //获取屏幕坐标
            }
        }
        

    }


    private void MUp()
    {
        if (Input.GetMouseButtonUp(0) && coll != null)
        {
            if (draging)
            {
                if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    if (locking) { return; }
                    bool Set_move = false;
                    int v_loc = -1;
                    float v_angle = Script.Bring_Block.GetComponent<Q1_angle_script>().angle_set_now;
                    if (loc_now >= 0)
                    {
                        Set_move = false;
                        if (loc_now == 0)
                        {
                            if (Mathf.Abs(v_angle - 0) < 1) { v_loc = 0; }
                            if (Mathf.Abs(v_angle - 180) < 1) { v_loc = 1; }
                        }
                        if (loc_now == 1)
                        {
                            if (Mathf.Abs(v_angle - 288) < 1) { v_loc = 0; }
                            if (Mathf.Abs(v_angle - 108) < 1) { v_loc = 1; }
                        }
                        if (loc_now == 2)
                        {
                            if (Mathf.Abs(v_angle - 216) < 1) { v_loc = 0; }
                            if (Mathf.Abs(v_angle - 36) < 1) { v_loc = 1; }
                        }
                        if (loc_now == 3)
                        {
                            if (Mathf.Abs(v_angle - 144) < 1) { v_loc = 0; }
                            if (Mathf.Abs(v_angle - 324) < 1) { v_loc = 1; }
                        }
                        if (loc_now == 4)
                        {
                            if (Mathf.Abs(v_angle - 72) < 1) { v_loc = 0; }
                            if (Mathf.Abs(v_angle - 252) < 1) { v_loc = 1; }
                        }
                    }
                    if (loc_now == -1)
                    {
                        Set_move = true;
                        if (Mathf.Abs(v_angle - 0) < 1) { v_loc = 0; }
                        if (Mathf.Abs(v_angle - 288) < 1) { v_loc = 1; }
                        if (Mathf.Abs(v_angle - 216) < 1) { v_loc = 2; }
                        if (Mathf.Abs(v_angle - 144) < 1) { v_loc = 3; }
                        if (Mathf.Abs(v_angle - 72) < 1) { v_loc = 4; }
                    }
                    if (loc_now == -2)
                    {
                        Set_move = true;
                        if (Mathf.Abs(v_angle - 180) < 1) { v_loc = 0; }
                        if (Mathf.Abs(v_angle - 108) < 1) { v_loc = 1; }
                        if (Mathf.Abs(v_angle - 36) < 1) { v_loc = 2; }
                        if (Mathf.Abs(v_angle - 324) < 1) { v_loc = 3; }
                        if (Mathf.Abs(v_angle - 252) < 1) { v_loc = 4; }
                    }
                    if (v_loc != -1)
                    {
                        if (!Set_move)
                        {
                            if (Script.Bring_Save[v_loc] == null)
                            {
                                Script.Bring_Save[v_loc] = gameObject.transform;
                                gameObject.transform.SetParent(Script.Bring_Block_set[v_loc]);
                                Script.Bring_Ele[loc_now] = null;
                                if (v_loc == 0) { loc_now = -1; }
                                if (v_loc == 1) { loc_now = -2; }
                            }
                        }
                        if (Set_move)
                        {
                            if (Script.Bring_Ele[v_loc] == null)
                            {

                                Script.Bring_Ele[v_loc] = gameObject.transform;
                                gameObject.transform.SetParent(Script.Ele_Block2[v_loc].transform);
                                if (loc_now == -1)
                                {
                                    Script.Bring_Save[0] = null;
                                }
                                if (loc_now == -2)
                                {
                                    Script.Bring_Save[1] = null;
                                }
                                loc_now = v_loc;
                            }
                        }
                    }

                    Q1_control.Q1_mode2_check_static();
                }
            }
                draging = false;
        }
        
    }

    /*
    private void OnMouseUpAsButton()
    {
        if (locking) { return; }
        bool Set_move=false;
        int v_loc = -1;
        float v_angle = Script.Bring_Block.GetComponent<Q1_angle_script>().angle_set_now;
        if (loc_now >= 0)
        {
            Set_move = false;
            if (loc_now == 0)
            {
                if(v_angle == 0){ v_loc = 0; }
                if (v_angle == 180) { v_loc = 1; }
            }
            if (loc_now == 1)
            {
                if (v_angle == 288) { v_loc = 0; }
                if (v_angle == 108) { v_loc = 1; }
            }
            if (loc_now == 2)
            {
                if (v_angle == 216) { v_loc = 0; }
                if (v_angle == 36) { v_loc = 1; }
            }
            if (loc_now == 3)
            {
                if (v_angle == 144) { v_loc = 0; }
                if (v_angle == 324) { v_loc = 1; }
            }
            if (loc_now == 4)
            {
                if (v_angle == 72) { v_loc = 0; }
                if (v_angle == 252) { v_loc = 1; }
            }
        }
        if(loc_now == -1)
        {
            Set_move = true;
            if (v_angle == 0) { v_loc = 0; }
            if (v_angle == 288) { v_loc = 1; }
            if (v_angle == 216) { v_loc = 2; }
            if (v_angle == 144) { v_loc = 3; }
            if (v_angle == 72) { v_loc = 4; }
        }
        if(loc_now == -2)
        {
            Set_move = true;
            if (v_angle == 180) { v_loc = 0; }
            if (v_angle == 108) { v_loc = 1; }
            if (v_angle == 36) { v_loc = 2; }
            if (v_angle == 324) { v_loc = 3; }
            if (v_angle == 252) { v_loc = 4; }
        }
        if (v_loc != -1)
        {
            if (!Set_move)
            {             
                if (Script.Bring_Save[v_loc] == null)
                {
                    Script.Bring_Save[v_loc] = gameObject.transform;
                    gameObject.transform.SetParent(Script.Bring_Block_set[v_loc]);
                    Script.Bring_Ele[loc_now] = null;
                    if (v_loc == 0) { loc_now = -1; }
                    if (v_loc == 1) { loc_now = -2; }
                }
            }
            if (Set_move)
            {
                if (Script.Bring_Ele[v_loc] == null)
                {
    
                    Script.Bring_Ele[v_loc] = gameObject.transform;
                    gameObject.transform.SetParent(Script.Ele_Block2[v_loc].transform);
                    if (loc_now == -1)
                    {
                        Script.Bring_Save[0] = null;
                    }
                    if (loc_now == -2)
                    {
                        Script.Bring_Save[1] = null;
                    }
                    loc_now = v_loc;
                }
            }
        }

    }
    */

    public void Lock(bool v_lock)
    {
        locking = v_lock;
    }
}

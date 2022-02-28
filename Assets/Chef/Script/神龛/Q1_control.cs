using System.Collections.Generic;
using UnityEngine;

public class Q1_control : MonoBehaviour
{
    private bool is_clear;
    private float delay,floatvar;
    private int Q_mode, delay_mode;
    public List<Transform> Angle_obj=new List<Transform>();
    public GameObject Q_camera;

    public GameObject[] Q_Block = new GameObject[5];
    public GameObject Q_Block_center;
    public GameObject[] Ele_Block = new GameObject[5];
    public GameObject[] Ele_Block2 = new GameObject[5];
    public GameObject[] Ele_Block3 = new GameObject[5];
    public GameObject[] Ele_Block4 = new GameObject[5];
    private float[] Ele_Block_float = new float[5];

    
    public GameObject Bring_Block;
    public Transform[] Bring_Block_set = new Transform[2];
    public  Transform[] Bring_Save=new Transform[2];
    public Transform[] Bring_Ele = new Transform[5];

    public static Q1_control Q1_script;

    public TalkSaveScript talksave;

    void Awake()
    {
        Q1_script = gameObject.GetComponent<Q1_control>();
        Q_mode = 0;
        delay = 0;
        delay_mode = 0;
        for(int i=0;i< Ele_Block2.Length; i++)
        {
            foreach (Transform child in Ele_Block2[i].transform)
            {
                Bring_Ele[i] = child;
                Bring_Ele[i].GetComponent<Q1_drag>().loc_now = i;
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        Check_Q1();
        mode_Change();
    }

    private void Check_Q1()
    {

        if (Input.GetMouseButtonUp(0))
        {
            if (is_clear) { return; }
            if (Q_mode == 0)
            {
                for (int i = 0; i < Angle_obj.Count; i++)
                {

                    if (Mathf.Abs(Angle_obj[i].localEulerAngles.z - 0) > 15 && Mathf.Abs(Angle_obj[i].localEulerAngles.z - 360) > 15)
                    {
                        return;
                    }
                    else
                    {
                        
                    }
                }
                is_clear = true;
                for (int i = 0; i < Angle_obj.Count; i++)
                {
                    if (Angle_obj[i].GetComponent<Q1_angle_script>().angle_set_now>=180) { Angle_obj[i].GetComponent<Q1_angle_script>().angle_set_now -= 360; }
                    Angle_obj[i].GetComponent<Q1_angle_script>().Lock(0, true);
                }
                delay = 2;
                delay_mode = 0;
            }
            if(Q_mode == 1)
            {
                Q_mode2_angle();
            }
        }

    }


    public static void Q1_mode2_check_static()
    {
        Q1_script.Q1_mode2_check();
    }
    public void Q_mode2_angle()
    {
        if (Bring_Block.GetComponent<Q1_angle_script>().angle_set_now >= 360 - 18)
        {
            Bring_Block.transform.rotation = Quaternion.AngleAxis(Bring_Block.transform.localEulerAngles.z - 360, Vector3.forward);
            Bring_Block.GetComponent<Q1_angle_script>().angle_set_now -= 360;
        }

        if (Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 0) < 18 || Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 180) < 18 || Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 360) < 18)
        {
            Bring_Block.GetComponent<Q1_angle_script>().Lock(0, false);
            if (Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 180) < 18) { Bring_Block.GetComponent<Q1_angle_script>().Lock(180, false); }
        }
        else
        {
            if (Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 36) < 18 || Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 216) < 18)
            {
                Bring_Block.GetComponent<Q1_angle_script>().Lock(36, false);
                if (Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 216) < 18) { Bring_Block.GetComponent<Q1_angle_script>().Lock(216, false); }
            }
            else
            {
                if (Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 72) < 18 || Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 252) < 18)
                {
                    Bring_Block.GetComponent<Q1_angle_script>().Lock(72, false);
                    if (Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 252) < 18) { Bring_Block.GetComponent<Q1_angle_script>().Lock(252, false); }
                }
                else
                {
                    if (Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 108) < 18 || Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 288) < 18)
                    {
                        Bring_Block.GetComponent<Q1_angle_script>().Lock(108, false);
                        if (Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 288) < 18) { Bring_Block.GetComponent<Q1_angle_script>().Lock(288, false); }
                    }
                    else
                    {
                        if (Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 144) < 18 || Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 324) < 18)
                        {
                            Bring_Block.GetComponent<Q1_angle_script>().Lock(144, false);
                            if (Mathf.Abs(Bring_Block.transform.localEulerAngles.z - 324) < 18) { Bring_Block.GetComponent<Q1_angle_script>().Lock(324, false); }
                        }
                    }
                }
            }
        }
    }

    public void Q1_mode2_check()
    {

        if (is_clear) { return; }
        for (int i = 0; i < Bring_Ele.Length; i++)
        {
            if (Bring_Ele[i] == null) { return; }
            if (Bring_Ele[i].GetComponent<Q1_drag>().clear_loc != i) { return; }
        }

        for (int i = 0; i < Bring_Ele.Length; i++)
        {
            if (Bring_Ele[i] == null) { return; }
            Bring_Ele[i].GetComponent<Q1_drag>().Lock(true);
        }
        Bring_Block.GetComponent<Q1_angle_script>().Lock(true);
        is_clear = true;
        delay = 2;
        delay_mode = 0;
    }


    private void mode_Change()
    {
        if (delay > 0)
        {
            
            delay -= Time.deltaTime;
            if (Q_mode == 0)
            {

                if (delay <= 0 && delay_mode==0)
                {
                    delay = 2;
                    delay_mode = 1;
                    Anima_interface c = new Camera_size_Command(Q_camera, 2300f, 1f, true,0,0,0);
                    Event_Invoker.AddCommand(c);
                    Anima_interface d = new Camera_size_Command(Camera.main.gameObject, 2300f, 1f, true,0,0,0);
                    Event_Invoker.AddCommand(d);
                }
                if (delay <= 0 && delay_mode == 1)
                {
                    delay = 2;
                    delay_mode = 2;
                    Vector3 v_Vec;
                    for (int i = 0; i < Q_Block.Length; i++)
                    {
                        v_Vec = Q_Block[i].transform.position + (Q_Block[i].transform.position - Q_Block_center.transform.position).normalized * 320f;
                        Anima_interface d = new Obj_move_ACommand(Q_Block[i], v_Vec.x, v_Vec.y, 1f, 0, "smooth");
                        Event_Invoker.AddCommand(d);
                    }
                    for (int i = 0; i < Ele_Block2.Length; i++)
                    {
                        Anima_interface d = new Obj_move_ACommand(Ele_Block2[i], Ele_Block2[i].transform.position.x, Ele_Block2[i].transform.position.y + 455, 2f, 0, "smooth");
                        Event_Invoker.AddCommand(d);
                        if (i == 0)
                        {
                            floatvar = Ele_Block2[i].transform.position.y + 455;
                        }
                    }
                    
                    for (int i = 0; i < Ele_Block.Length; i++)
                    {
                        Ele_Block_float[i] = Ele_Block[i].transform.localEulerAngles.z;
                    }
                }

                if (delay_mode == 2)
                {
                    if (delay > 1 && delay<1.5)
                    {
                        delay = 1.4f;

                        if (Ele_Block2[0].transform.position.y == floatvar)
                        {
                            Event_interface c = new Obj_stop_Command(Ele_Block2[0]);
                            Event_Invoker.AddCommand(c);
                            for (int i = 0; i < Ele_Block.Length; i++)
                            {
                                float v_k = -72 * i;
                                float v_spd = 3 * Time.deltaTime;
                                if (v_spd > 1) { v_spd = 1; }
                                Ele_Block_float[i] += (v_k - Ele_Block_float[i]) * v_spd;
                                if (Mathf.Abs(v_k - Ele_Block_float[i]) < 1f)
                                {
                                    Ele_Block_float[i] = v_k;
                                }
                                Ele_Block[i].transform.rotation = Quaternion.AngleAxis(Ele_Block_float[i], Vector3.forward);
                                if (Ele_Block_float[4] == v_k && i == 4)
                                {
                                    
                                    delay = 1;
                                }
                            }
                        }
                    }

                    if (delay <= 0)
                    {
                        delay = 2;
                        delay_mode = 3;
                        Vector3 v_Vec;
                        for (int i = 0; i < Q_Block.Length; i++)
                        {
                            v_Vec = Ele_Block4[i].transform.position + (Ele_Block4[i].transform.position - Q_Block_center.transform.position).normalized * 455f;
                            Anima_interface d = new Obj_move_ACommand(Ele_Block4[i], v_Vec.x, v_Vec.y, 2f, 0, "smooth");
                            Event_Invoker.AddCommand(d);
                        }
                    }

                }
                if (delay <= 0 && delay_mode == 3)
                {

                    delay = 2;
                    delay_mode = 4;
                }

                if (delay<=0 && delay_mode == 4)
                {
                    Q_mode = 1;
                    is_clear = false;
                    Bring_Block.GetComponent<Q1_angle_script>().locking = false;
                    for (int i = 0; i < Bring_Ele.Length; i++)
                    {
                        Bring_Ele[i].GetComponent<Q1_drag>().locking = false;
                    }
                }
            }
            if(Q_mode == 1)
            {
                if (delay <= 0 && delay_mode == 0)
                {
                    Q_mode = 2;
                    is_clear = false;

                     Event_interface c = new Talk_Command(talksave, Talk_control.TK_static);
                    Event_Invoker.AddCommand(c);
                }
            }

            Game_admin.wait_mode = is_clear;
            Game_admin.mode_check();
        }
    }


    public void Q_mode2_Click()
    {

    }

}

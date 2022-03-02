using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Qsky2_control : MonoBehaviour
{
    private int delay_mode;
    private float delay;
    public int Q_mode;




    private GameObject now_obj, move_obj;
    private float move_x, move_y;
    private int  now_obj_mode;
    private Vector3 Pos_mouse;

    [Title("轉盤obj")]
    public GameObject[] Set_obj = new GameObject[2];
    [Title("底盤obj")]
    public GameObject[] Finish_obj = new GameObject[5];
    private int Set_mode, Set_this;
    [Title("底盤名稱")]
    public GameObject[] Finish_name = new GameObject[5];
    [Title("底盤位置")]
    public GameObject[] Finish_obj_loc = new GameObject[5];
    [Title("旋轉點擊判定")]
    public GameObject Drag_obj;
    [Title("旋轉點擊非判定")]
    public CircleCollider2D coll_unclick;

    [Title("旋轉間隔")]
    public float Angle_delay = 1;
    [Title("旋轉速度上限")]
    public float Angle_max = -1;
    [Title("旋轉力度")]
    public float angle_power = 1f;

    [Title("完成后立刻执行的触发器")]
    [SceneObjectsOnly]
    public List<GameObject> next_TRI = new List<GameObject>();
    [Title("下一个触发器廷时触发")]
    public float next_time = 0;

    //與中心點的距離
    private float Drag_pos, Drag_pos_now;
    private Vector2 Drag_dir;

    // Start is called before the first frame update
    void Start()
    {
        Drag_pos = Vector2.Distance(new Vector2(Drag_obj.transform.position.x, Drag_obj.transform.position.y), new Vector2(Finish_obj_loc[0].transform.position.x, Finish_obj_loc[0].transform.position.y));
        Q_mode = 0;
        for(int i = 0; i < Finish_obj.Length; i++)
        {
            if (Finish_obj[i] != null)
            {
                Finish_obj[i].transform.position = Finish_obj_loc[i].transform.position;
                Finish_obj[i].transform.rotation = Finish_obj_loc[i].transform.rotation;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        Set_Q_mode();
        if (delay > 0) { return; }
        if (Input.GetMouseButtonDown(0) && Game_admin.Some_mode)
        {
            if (now_obj == null && move_obj == null)
            {
                for(int i = 0; i < Finish_obj.Length; i++)
                {
                    if (Finish_obj[i] == null) { continue; }
                    BoxCollider2D coll2;
                    coll2 = Finish_obj[i].GetComponent<BoxCollider2D>();
                    if (coll2.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                    {
                        now_obj = Finish_obj[i];
                        Pos_mouse = Input.mousePosition; //获取屏幕坐标
                        now_obj_mode = 1;
                        Drag_pos_now = Vector2.Distance(new Vector2(Drag_obj.transform.position.x, Drag_obj.transform.position.y), new Vector2(now_obj.transform.position.x, now_obj.transform.position.y));
                        Drag_dir = (new Vector2(now_obj.transform.position.x, now_obj.transform.position.y) - new Vector2(Drag_obj.transform.position.x, Drag_obj.transform.position.y)).normalized;
                        Set_mode = i;
                    }

                }
                for (int i = 0; i < Set_obj.Length; i++)
                {
                    if (Set_obj[i] == null) { continue; }
                    BoxCollider2D coll2;
                    coll2 = Set_obj[i].GetComponent<BoxCollider2D>();
                    if (coll2.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                    {
                        
                        now_obj = Set_obj[i];
                        Pos_mouse = Input.mousePosition; //获取屏幕坐标
                        now_obj_mode = 1;
                        Drag_pos_now = Vector2.Distance(new Vector2(Drag_obj.transform.position.x, Drag_obj.transform.position.y), new Vector2(now_obj.transform.position.x, now_obj.transform.position.y));
                        Drag_dir = (new Vector2(now_obj.transform.position.x, now_obj.transform.position.y) - new Vector2(Drag_obj.transform.position.x, Drag_obj.transform.position.y)).normalized;
                        Set_mode = i+5;
                    }

                }
                if (now_obj == null)
                {
                    CircleCollider2D coll2;
                    coll2 = Drag_obj.GetComponent<CircleCollider2D>();
                    if (coll2.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                    {
                        if (!coll_unclick.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                        {
                            now_obj = Drag_obj;
                            Pos_mouse = Input.mousePosition; //获取屏幕坐标
                            now_obj_mode = 0;
                        }
                    }
                }
            }

        }

        if (now_obj != null)
        {
            if (now_obj_mode == 0)
            {
                float m_x, m_y, angle_set_x, angle_set_y;
                m_x = (Input.mousePosition.x - Pos_mouse.x) * angle_power;
                m_y = (Input.mousePosition.y - Pos_mouse.y) * angle_power;
                Vector3 m_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                angle_set_x = m_x;
                angle_set_y = m_y;
                if (m_pos.x < now_obj.transform.position.x)
                {
                    angle_set_y = m_y * -1;
                }
                if (m_pos.y > now_obj.transform.position.y)
                {
                    angle_set_x = m_x * -1;
                }


                if (Mathf.Abs(angle_set_x + angle_set_y) >= Angle_delay)
                {
                    float angle_add = Mathf.Floor((angle_set_x + angle_set_y) / Angle_delay);
                    angle_add = angle_add * Angle_delay;
                    if (Mathf.Abs(angle_add) > Angle_max && Angle_max != -1)
                    {
                        if (angle_add > 0) { angle_add = Mathf.Floor(Angle_max / Angle_delay) * Angle_delay; }
                        if (angle_add < 0) { angle_add = -Mathf.Floor(Angle_max / Angle_delay) * Angle_delay; }
                    }



                    //now_obj.transform.rotation = Quaternion.AngleAxis(now_obj.transform.localEulerAngles.z + angle_add, Vector3.forward);
                    now_obj.GetComponent<Qsky2_angle>().Angle_set_sc(angle_add);
                    now_obj.GetComponent<Qsky2_angle>().angle_set = now_obj.transform.localEulerAngles.z;
                    now_obj.GetComponent<Qsky2_angle>().angle_set_now = now_obj.transform.localEulerAngles.z;

                    Pos_mouse = Input.mousePosition; //获取屏幕坐标
                }
            }
            if (now_obj_mode == 1)
            {
                float m_x, m_y;
                m_x = (Input.mousePosition.x - Pos_mouse.x);
                m_y = (Input.mousePosition.y - Pos_mouse.y);

                //Vector2 v_dis_pos2 = (new Vector2(Input.mousePosition.x, Input.mousePosition.y) - new Vector2(Pos_mouse.x, Pos_mouse.y)).normalized * (Vector2.Distance(new Vector2(0, 0), new Vector2(m_x, m_y)));
                if (m_x != 0 || m_y != 0)
                {
                    int m_set = 0;
                    bool v_ok = false;

                    Vector2 v_dir = (new Vector2(Input.mousePosition.x, Input.mousePosition.y) - new Vector2(Pos_mouse.x, Pos_mouse.y)).normalized;
                    float dot = Vector2.Dot(Drag_dir, v_dir);
                    float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
                    //如果想打印角度，取消注释即可
                    if (angle <= 60) { m_set = 1; }
                    if (angle >= 120) { m_set = -1; }

                    
                    
                    Drag_pos_now += (Vector2.Distance(new Vector2(0, 0), new Vector2(m_x, m_y))) * m_set;

                    if (Set_mode <= 4)
                    {
                        if (Drag_obj.GetComponent<Qsky2_angle>().angle_set_now == 90)
                        {
                            if(Set_mode==0 && Set_obj[0] == null)
                            {
                                Set_this = 0;
                                v_ok = true;
                            }
                        }
                        if (Drag_obj.GetComponent<Qsky2_angle>().angle_set_now == 150)
                        {
                            if (Set_mode == 1 && Set_obj[0] == null)
                            {
                                Set_this = 0;
                                v_ok = true;
                            }
                            if (Set_mode == 3 && Set_obj[1] == null)
                            {
                                Set_this = 1;
                                v_ok = true;
                            }
                        }
                        if (Drag_obj.GetComponent<Qsky2_angle>().angle_set_now == 210)
                        {
                            if (Set_mode == 2 && Set_obj[0] == null)
                            {
                                Set_this = 0;
                                v_ok = true;
                            }
                            if (Set_mode == 4 && Set_obj[1] == null)
                            {
                                Set_this = 1;
                                v_ok = true;
                            }
                        }
                        if (Drag_obj.GetComponent<Qsky2_angle>().angle_set_now == 270)
                        {
                            if (Set_mode == 0 && Set_obj[1] == null)
                            {
                                Set_this = 1;
                                v_ok = true;
                            }
                        }
                        if (Drag_obj.GetComponent<Qsky2_angle>().angle_set_now == 330)
                        {
                            if (Set_mode == 3 && Set_obj[0] == null)
                            {
                                Set_this = 0;
                                v_ok = true;
                            }
                            if (Set_mode == 1 && Set_obj[1] == null)
                            {
                                Set_this = 1;
                                v_ok = true;
                            }
                        }
    
                        if (Drag_obj.GetComponent<Qsky2_angle>().angle_set_now == 30)
                        {
                            if (Set_mode == 4 && Set_obj[0] == null)
                            {
                                Set_this = 0;
                                v_ok = true;
                            }
                            if (Set_mode == 2 && Set_obj[1] == null)
                            {
                                Set_this = 1;
                                v_ok = true;
                            }
                        }
                    }
                    if (Set_mode >= 5)
                    {
                        if (Drag_obj.GetComponent<Qsky2_angle>().angle_set_now == 90)
                        {
                            if (Set_mode == 5 && Finish_obj[0] == null)
                            {
                                Set_this = 0;
                                v_ok = true;
                            }
                        }
                        if (Drag_obj.GetComponent<Qsky2_angle>().angle_set_now == 150)
                        {
                            if (Set_mode == 5 && Finish_obj[1] == null)
                            {
                                Set_this = 1;
                                v_ok = true;
                            }
                            if (Set_mode == 6 && Finish_obj[3] == null)
                            {
                                Set_this = 3;
                                v_ok = true;
                            }
                        }
                        if (Drag_obj.GetComponent<Qsky2_angle>().angle_set_now == 210)
                        {
                            if (Set_mode == 5 && Finish_obj[2] == null)
                            {
                                Set_this = 2;
                                v_ok = true;
                            }
                            if (Set_mode == 6 && Finish_obj[4] == null)
                            {
                                Set_this = 4;
                                v_ok = true;
                            }
                        }
                        if (Drag_obj.GetComponent<Qsky2_angle>().angle_set_now == 270)
                        {
                            if (Set_mode == 6 && Finish_obj[0] == null)
                            {
                                Set_this = 0;
                                v_ok = true;
                            }
                        }
                        if (Drag_obj.GetComponent<Qsky2_angle>().angle_set_now == 330)
                        {
                            if (Set_mode == 5 && Finish_obj[3] == null)
                            {
                                Set_this = 3;
                                v_ok = true;
                            }
                            if (Set_mode == 6 && Finish_obj[1] == null)
                            {
                                Set_this = 1;
                                v_ok = true;
                            }
                        }
                        if (Drag_obj.GetComponent<Qsky2_angle>().angle_set_now == 30)
                        {
                            if (Set_mode == 5 && Finish_obj[4] == null)
                            {
                                Set_this = 4;
                                v_ok = true;
                            }
                            if (Set_mode == 6 && Finish_obj[2] == null)
                            {
                                Set_this = 2;
                                v_ok = true;
                            }
                        }
                    }


                    if (v_ok || Set_mode <= 4)
                    {
                        if (Drag_pos_now > Drag_pos) { Drag_pos_now = Drag_pos; }
                    }
                    else
                    {
                        if (Drag_pos_now >= (Drag_pos+200)/2-1) { Drag_pos_now = (Drag_pos + 200 )/ 2 - 1; }
                    }
                    

                    if (v_ok || Set_mode>=5)
                    {
                        if (Drag_pos_now < 200) { Drag_pos_now = 200; }
                    }
                    else
                    {
                        if (Drag_pos_now < (Drag_pos + 200) / 2){ Drag_pos_now = (Drag_pos + 200) / 2; }
                    }


                    Vector2 v_dis_pos = Drag_dir * Drag_pos_now;

                    Pos_mouse = Input.mousePosition;

                    now_obj.transform.position = new Vector2(Drag_obj.transform.position.x + v_dis_pos.x, Drag_obj.transform.position.y + v_dis_pos.y);
                }
                //now_obj.transform.position = new Vector2(now_obj.transform.position.x, now_obj.transform.position.y).normalized* Drag_pos;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (now_obj_mode == 0)
                {
                    float v_angle_set = 30;
                    for (float i = 0; i < 360; i += v_angle_set)
                    {
                        if (Mathf.Abs(now_obj.transform.localEulerAngles.z - 0) <= i + v_angle_set / 2 && Mathf.Abs(now_obj.transform.localEulerAngles.z - 0) > i - v_angle_set / 2 || Mathf.Abs(now_obj.transform.localEulerAngles.z - 360) <= v_angle_set / 2 - i)
                        {
                            if (now_obj.GetComponent<Qsky2_angle>().angle_set_now >= 360 - v_angle_set / 2) { now_obj.GetComponent<Qsky2_angle>().angle_set_now -= 360; }
                            now_obj.GetComponent<Qsky2_angle>().Lock(i);
                        }
                    }
                }
                if (now_obj_mode == 1)
                {
                    if (Drag_pos_now >= (Drag_pos + 200)/ 2){
                        move_x = Drag_obj.transform.position.x + (Drag_dir * Drag_pos).x;
                        move_y = Drag_obj.transform.position.y + (Drag_dir * Drag_pos).y;
                        now_obj.transform.SetParent(Drag_obj.transform.parent);
                        if (Set_mode >= 5)
                        {
                            Set_obj[Set_mode- 5] = null;
                            Finish_obj[Set_this] = now_obj;
                        }
                    }
                    else
                    {
                        move_x = Drag_obj.transform.position.x + (Drag_dir * 200).x;
                        move_y = Drag_obj.transform.position.y + (Drag_dir * 200).y;
                        now_obj.transform.SetParent(Drag_obj.transform);
                        if (Set_mode <= 4)
                        {
                            Finish_obj[Set_mode] = null;
                            Set_obj[Set_this] = now_obj;
                        }
                    }
                    move_obj = now_obj;
                }
                now_obj = null;
            }
            
        }


        if (now_obj == null && move_obj != null)
        {
            float v_dis = Vector2.Distance(new Vector2(move_obj.transform.position.x, move_obj.transform.position.y), new Vector2(move_x, move_y));
            if (v_dis > 0)
            {
                float v_spd = 10 * Time.deltaTime;
                if (v_spd > 1) { v_spd = 1; }
                Vector2 v_dis_pos = (new Vector2(move_x, move_y) - new Vector2(move_obj.transform.position.x, move_obj.transform.position.y)).normalized * v_dis * v_spd;
                move_obj.transform.position = new Vector2(move_obj.transform.position.x + v_dis_pos.x, move_obj.transform.position.y + v_dis_pos.y);
                if (Vector2.Distance(new Vector2(move_obj.transform.position.x, move_obj.transform.position.y), new Vector2(move_x, move_y)) < 1f)
                {
                    move_obj.transform.position = new Vector2(move_x, move_y);
                }
            }
            else
            {
                Face_reset();
                move_obj = null;
            }
        }

    }


    public void Set_Q_mode()
    {

    }

    public void Face_reset()
    {
        bool finish = true;


        for (int i = 0; i < Finish_name.Length; i++)
        {
            if (Finish_obj[i] == null) { finish = false; break; }
            if (Finish_name[i] != Finish_obj[i])
            {
                finish = false;
                break;
            }
        }

        if (finish)
        {
            Q_mode = 2;
            delay_mode = 0;
            delay = 2;
            Finish_Tri();
        }
    }

    public void Finish_Tri()
    {
        Game_admin.Next_Tri_set(next_TRI, next_time);
    }
}

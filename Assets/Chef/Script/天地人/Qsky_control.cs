using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Qsky_control : MonoBehaviour
{
    private int delay_mode;
    private float delay;
    public int Q_mode;

    public GameObject Drag_obj;
    public float Drag_obj_y,Drag_obj_y_org;

    public List<GameObject> angle_obj_set = new List<GameObject>();
    public List<GameObject> angle_obj_show = new List<GameObject>();
    private List<GameObject> angle_obj = new List<GameObject>();
    private GameObject now_obj, move_obj;
    private int now_obj_mode,angle_mode;
    private Vector3 Pos_mouse;


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


    // Start is called before the first frame update
    void Start()
    {
        Drag_obj_y_org = Drag_obj.transform.position.y;
        Drag_obj_y = 0;
        Q_mode = 0;
        for(int i = 0; i < angle_obj_show.Count; i++)
        {
            angle_obj_show[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Set_Q_mode();
        if (delay > 0) { return; }
        if (Input.GetMouseButtonDown(0) && Game_admin.Some_mode)
        {
            if (now_obj == null && move_obj==null)
            {
                if (Q_mode == 1)
                {
                    CircleCollider2D coll;
                    for (int i = 0; i < angle_obj.Count; i++)
                    {
                        coll = angle_obj[i].GetComponent<CircleCollider2D>();
                        if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                        {

                            now_obj = angle_obj[i];
                            Pos_mouse = Input.mousePosition; //获取屏幕坐标
                            now_obj_mode = 0;
                        }
                    }
                }
                if (Q_mode == 0) { 
                    BoxCollider2D coll2;
                    coll2 = Drag_obj.GetComponent<BoxCollider2D>();
                    if (coll2.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                    {

                        now_obj = Drag_obj;
                        Pos_mouse = Input.mousePosition; //获取屏幕坐标
                        now_obj_mode = 1;
                    }
                }
            }
        }

        if (now_obj != null)
        {
            if (now_obj_mode == 0) { 
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


               
                    now_obj.transform.rotation = Quaternion.AngleAxis(now_obj.transform.localEulerAngles.z + angle_add, Vector3.forward);
                    now_obj.GetComponent<Qsky_angle>().angle_set = now_obj.transform.localEulerAngles.z;
                    now_obj.GetComponent<Qsky_angle>().angle_set_now = now_obj.transform.localEulerAngles.z;

                    Pos_mouse = Input.mousePosition; //获取屏幕坐标
                }
            }
            if (now_obj_mode == 1)
            {
                float m_y;
                m_y = Input.mousePosition.y - Pos_mouse.y;
                Drag_obj_y += m_y;

                now_obj.transform.position = new Vector2(now_obj.transform.position.x,now_obj.transform.position.y+ m_y);

                Pos_mouse = Input.mousePosition; //获取屏幕坐标
            }

            if (Input.GetMouseButtonUp(0))
            {
                if(now_obj_mode == 0)
                {
                    bool is_clear = true;
                    for (int i = 0; i < angle_obj.Count; i++)
                    {

                        if (Mathf.Abs(angle_obj[i].transform.localEulerAngles.z - 0) > 15 && Mathf.Abs(angle_obj[i].transform.localEulerAngles.z - 360) > 15)
                        {
                            is_clear = false;
                            break;
                        }
                    }
                    if (is_clear)
                    {
                        for (int i = 0; i < angle_obj.Count; i++)
                        {
                            if (angle_obj[i].transform.GetComponent<Qsky_angle>().angle_set_now >= 180) { angle_obj[i].transform.GetComponent<Qsky_angle>().angle_set_now -= 360; }
                            angle_obj[i].transform.GetComponent<Qsky_angle>().Lock(0);
                        }
                        delay = 1;
                        angle_obj_set[angle_mode].GetComponent<Qsky_angle_set>().is_finish = true;
                        angle_obj_show[angle_mode].SetActive(true);
                    }
                }



                if (now_obj_mode == 1)
                {
                    if (Mathf.Abs(Drag_obj_y - 120)<50)
                    {
                        Drag_obj_y = 120;
                        move_obj = now_obj;
                        angle_mode = 0;

                    }
                    if (Mathf.Abs(Drag_obj_y - 340) < 50)
                    {
                        Drag_obj_y = 340;
                        move_obj = now_obj;
                        angle_mode = 1;
                    }
                    if (Mathf.Abs(Drag_obj_y - 590) < 50)
                    {
                        Drag_obj_y = 590;
                        move_obj = now_obj;
                        angle_mode = 2;
                    }
                }
                now_obj = null;
            }
        }


        if(now_obj==null && move_obj != null)
        {
            if (move_obj.transform.position.y- Drag_obj_y_org != Drag_obj_y)
            {
                float v_spd = 10 * Time.deltaTime;
                if (v_spd > 1) { v_spd = 1; }
                move_obj.transform.position = new Vector2(move_obj.transform.position.x, move_obj.transform.position.y+(Drag_obj_y-(move_obj.transform.position.y - Drag_obj_y_org)) *v_spd);
                if (Mathf.Abs(move_obj.transform.position.y - Drag_obj_y_org - Drag_obj_y) <1)
                {
                    move_obj.transform.position = new Vector2(move_obj.transform.position.x, move_obj.transform.position.y+(move_obj.transform.position.y - Drag_obj_y - Drag_obj_y_org));
                    move_obj = null;
                    if (!angle_obj_set[angle_mode].GetComponent<Qsky_angle_set>().is_finish)
                    {
                        Q_mode = 1;
                        angle_obj_set[angle_mode].SetActive(true);
                        angle_obj_set[angle_mode].transform.position = transform.position;
                        for (int i = 0; i < angle_obj_set.Count; i++)
                        {
                            angle_obj = angle_obj_set[angle_mode].GetComponent<Qsky_angle_set>().angle_obj;
                        }
                    }
                }
            }
        }

    }


    public void Set_Q_mode()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            if (Q_mode == 1)
            {
                if (delay <= 0 && delay_mode == 0)
                {
                    angle_obj_set[angle_mode].SetActive(false);
                    angle_obj.Clear();
                    bool is_finish = true;
                    for (int i = 0; i < angle_obj_set.Count; i++)
                    {
                        if (!angle_obj_set[i].GetComponent<Qsky_angle_set>().is_finish)
                        {
                            is_finish = false;
                            break;
                        }

                    }
                    if (!is_finish) { 
                        delay = 0;
                        Q_mode = 0;
                    }
                    else
                    {
                        delay = 1;
                        delay_mode = 5;
                    }
                }
                if (delay <= 0 && delay_mode == 5)
                {
                    Finish_Tri();

                }
            }
        }

    }

    public void Face_reset()
    {
        bool finish = true;

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

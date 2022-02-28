using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class QmathC_control : SerializedMonoBehaviour
{
    private int delay_mode;
    private float delay;
    public int Q_mode;

    private GameObject now_obj;
    private int now_i, now_j;
    private float y_move, mouse_y, x_move, mouse_x,first_x,first_y;

    public GameObject block_perfab;
    public GameObject[] block_obj = new GameObject[8];
    public GameObject block_control;

    private GameObject move_obj,angle_obj;
    private float move_obj_x,angle_obj_angle;
    private float move_obj_y;
    private float block_w;


    // Start is called before the first frame update

    void Awake()
    {
        Q_mode = 0;
        delay = 0;
        delay_mode = 0;
        block_w = 200;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BoxCollider2D coll;
        if (Input.GetMouseButtonDown(0) && Game_admin.Some_mode)
        {
            if (now_obj == null)
            {
                for (int i = 0; i < block_obj.Length; i++)
                {
                    if (block_obj[i] != null)
                    {
                        coll = block_obj[i].GetComponent<BoxCollider2D>();
                        if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                        {
                            now_obj = block_obj[i];
                            now_i = i;
                            y_move = 0;
                            x_move = 0;
                            mouse_x = Input.mousePosition.x;
                            mouse_y = Input.mousePosition.y;
                        }
                    }
                }
            }
            if(now_obj == null)
            {
                CircleCollider2D coll2 = gameObject.GetComponent<CircleCollider2D>();
                if (coll2.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    now_obj = block_control;
                    now_i = -1;
                    first_x = Input.mousePosition.x;
                    first_y = Input.mousePosition.y;
                }
            }
        }

        if (now_obj != null)
        {
            x_move += Input.mousePosition.x - mouse_x;
            y_move += Input.mousePosition.y - mouse_y;
            mouse_x = Input.mousePosition.x;
            mouse_y = Input.mousePosition.y;
            while (true)
            {
                if (now_i == 0)
                {
                    Debug.Log(Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z));
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 0)
                    {
                        if (block_obj[4]!=null) { break; }
                        if (y_move > 100) { 
                            block_obj[4] = block_obj[now_i]; 
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null ;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x;
                            move_obj_y = now_obj.transform.position.y + block_w;
                            now_obj = null; 
                            break; 
                        }
                    }
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 90)
                    {
                        if (block_obj[5] != null) { break; }
                        if (x_move < -100)
                        {
                            block_obj[5] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x - block_w;
                            move_obj_y = now_obj.transform.position.y;
                            now_obj = null;
                            break;
                        }
                    }
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 180)
                    {
                        if (block_obj[6] != null) { break; }
                        if (y_move < -100)
                        {
                            block_obj[6] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x;
                            move_obj_y = now_obj.transform.position.y - block_w;
                            now_obj = null;
                            break;
                        }
                    }
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 270)
                    {
                        if (block_obj[7] != null) { break; }
                        if (x_move > 100)
                        {
                            block_obj[7] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x + block_w;
                            move_obj_y = now_obj.transform.position.y;
                            now_obj = null;
                            break;
                        }
                    }
                }
                if (now_i == 1)
                {
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 90)
                    {
                        if (block_obj[4] != null) { break; }
                        if (y_move > 100)
                        {
                            block_obj[4] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x;
                            move_obj_y = now_obj.transform.position.y + block_w;
                            now_obj = null;
                            break;
                        }
                    }
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 180)
                    {
                        if (block_obj[5] != null) { break; }
                        if (x_move < -100)
                        {
                            block_obj[5] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x - block_w;
                            move_obj_y = now_obj.transform.position.y;
                            now_obj = null;
                            break;
                        }
                    }
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 270)
                    {
                        if (block_obj[6] != null) { break; }
                        if (y_move < -100)
                        {
                            block_obj[6] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x;
                            move_obj_y = now_obj.transform.position.y - block_w;
                            now_obj = null;
                            break;
                        }
                    }
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 0)
                    {
                        if (block_obj[7] != null) { break; }
                        if (x_move > 100) {
                            block_obj[7] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x + block_w;
                            move_obj_y = now_obj.transform.position.y;
                            now_obj = null;
                            break;
                        }
                    }
                }
                if (now_i == 2)
                {
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 180)
                    {
                        if (block_obj[4] != null) { break; }
                        if (y_move > 100)
                        {
                            block_obj[4] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x;
                            move_obj_y = now_obj.transform.position.y + block_w;
                            now_obj = null;
                            break;
                        }
                    }
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 270)
                    {
                        if (block_obj[5] != null) { break; }
                        if (x_move < -100)
                        {
                            block_obj[5] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x - block_w;
                            move_obj_y = now_obj.transform.position.y;
                            now_obj = null;
                            break;
                        }
                    }
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 0)
                    {
                        if (block_obj[6] != null) { break; }
                        if (y_move < -100)
                        {
                            block_obj[6] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x;
                            move_obj_y = now_obj.transform.position.y - block_w;
                            now_obj = null;
                            break;
                        }
                    }
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 90)
                    {
                        if (block_obj[7] != null) { break; }
                        if (x_move > 100)
                        {
                            block_obj[7] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x + block_w;
                            move_obj_y = now_obj.transform.position.y;
                            now_obj = null;
                            break;
                        }
                    }
                }
                if (now_i == 3)
                {
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 270)
                    {
                        if (block_obj[4] != null) { break; }
                        if (y_move > 100)
                        {
                            block_obj[4] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x;
                            move_obj_y = now_obj.transform.position.y + block_w;
                            now_obj = null;
                            break;
                        }
                    }
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 0)
                    {
                        if (block_obj[5] != null) { break; }
                        if (x_move < -100)
                        {
                            block_obj[5] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x - block_w;
                            move_obj_y = now_obj.transform.position.y;
                            now_obj = null;
                            break;
                        }
                    }
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 90)
                    {
                        if (block_obj[6] != null) { break; }
                        if (y_move < -100)
                        {
                            block_obj[6] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x;
                            move_obj_y = now_obj.transform.position.y - block_w;
                            now_obj = null;
                            break;
                        }
                    }
                    if (Mathf.Round(now_obj.transform.parent.transform.localEulerAngles.z) == 180)
                    {
                        if (block_obj[7] != null) { break; }
                        if (x_move > 100)
                        {
                            block_obj[7] = block_obj[now_i];
                            block_obj[now_i].transform.parent = transform;
                            block_obj[now_i] = null;
                            Game_admin.wait_mode = true;
                            Game_admin.mode_check();
                            move_obj = now_obj;
                            move_obj_x = now_obj.transform.position.x + block_w;
                            move_obj_y = now_obj.transform.position.y;
                            now_obj = null;
                            break;
                        }
                    }
                }

                if (now_i == 4)
                {
                    int v_now_i =0;
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 0) { v_now_i = 0; }
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 90) { v_now_i = 1; }
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 180) { v_now_i = 2; }
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 270) { v_now_i = 3; }

                    if (block_obj[v_now_i] != null) { break; }
                    if (y_move < -100)
                    {
                        block_obj[v_now_i] = block_obj[now_i];
                        block_obj[now_i].transform.parent = block_control.transform;
                        block_obj[now_i] = null;
                        Game_admin.wait_mode = true;
                        Game_admin.mode_check();
                        move_obj = now_obj;
                        move_obj_x = now_obj.transform.position.x;
                        move_obj_y = now_obj.transform.position.y - block_w;
                        now_obj = null;
                        break;
                    }
                }
                if (now_i == 5)
                {
                    int v_now_i = 0;
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 0) { v_now_i = 3; }
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 90) { v_now_i = 0; }
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 180) { v_now_i = 1; }
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 270) { v_now_i = 2; }
                    Debug.Log(v_now_i);
                    if (block_obj[v_now_i] != null) { break; }
                   
                    if (x_move > 100)
                    {
                        block_obj[v_now_i] = block_obj[now_i];
                        block_obj[now_i].transform.parent = block_control.transform;
                        block_obj[now_i] = null;
                        Game_admin.wait_mode = true;
                        Game_admin.mode_check();
                        move_obj = now_obj;
                        move_obj_x = now_obj.transform.position.x + block_w;
                        move_obj_y = now_obj.transform.position.y;
                        now_obj = null;
                        break;
                    }
                }
                if (now_i == 6)
                {
                    int v_now_i = 0;
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 0) { v_now_i = 2; }
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 90) { v_now_i = 3; }
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 180) { v_now_i = 0; }
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 270) { v_now_i = 1; }
                    Debug.Log(v_now_i);
                    if (block_obj[v_now_i] != null) { break; }

                    if (y_move > 100)
                    {
                        block_obj[v_now_i] = block_obj[now_i];
                        block_obj[now_i].transform.parent = block_control.transform;
                        block_obj[now_i] = null;
                        Game_admin.wait_mode = true;
                        Game_admin.mode_check();
                        move_obj = now_obj;
                        move_obj_x = now_obj.transform.position.x;
                        move_obj_y = now_obj.transform.position.y + block_w;
                        now_obj = null;
                        break;
                    }
                }
                if (now_i == 7)
                {
                    int v_now_i = 0;
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 0) { v_now_i = 1; }
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 90) { v_now_i = 2; }
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 180) { v_now_i = 3; }
                    if (Mathf.Round(block_control.transform.localEulerAngles.z) == 270) { v_now_i = 0; }
                    Debug.Log(v_now_i);
                    if (block_obj[v_now_i] != null) { break; }

                    if (x_move < -100)
                    {
                        block_obj[v_now_i] = block_obj[now_i];
                        block_obj[now_i].transform.parent = block_control.transform;
                        block_obj[now_i] = null;
                        Game_admin.wait_mode = true;
                        Game_admin.mode_check();
                        move_obj = now_obj;
                        move_obj_x = now_obj.transform.position.x - block_w;
                        move_obj_y = now_obj.transform.position.y;
                        now_obj = null;
                        break;
                    }
                }
                if (now_i == -1)
                {
                    Vector3 m_pos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    float m_x, m_y, angle_set_x, angle_set_y;
                    m_x = (Input.mousePosition.x - first_x);
                    m_y = (Input.mousePosition.y - first_y);
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
                    if (Mathf.Abs(angle_set_x + angle_set_y) >= 100)
                    {
                        Game_admin.wait_mode = true;
                        Game_admin.mode_check();
                        float angle_add = Mathf.Floor((angle_set_x + angle_set_y));
                        if (angle_add > 0) { angle_obj_angle = now_obj.transform.localEulerAngles.z + 90; }
                        if (angle_add < 0) { angle_obj_angle= now_obj.transform.localEulerAngles.z - 90; }

                        angle_obj = now_obj;
                        now_obj = null;
                        break;
                    }
                    break;
                }
                break;
            }
            if (Input.GetMouseButtonUp(0))
            {
                now_obj = null;
            }
        }

        if (move_obj != null)
        {
            if (move_obj.transform.position.x != move_obj_x)
            {
                int m_num;
                if (move_obj.transform.position.x <= move_obj_x) { m_num = 1; }
                else { m_num = -1; }
                move_obj.transform.position = new Vector2(move_obj.transform.position.x + (block_w / (60000 * Time.deltaTime)) * m_num, move_obj.transform.position.y);
                if (Mathf.Abs(move_obj.transform.position.x - move_obj_x) < 1)
                {
                    move_obj.transform.position = new Vector2(move_obj_x, move_obj.transform.position.y);
                }
            }
            if (move_obj.transform.position.y != move_obj_y)
            {
                int m_num;
                if (move_obj.transform.position.y <= move_obj_y) { m_num = 1; }
                else { m_num = -1; }
                move_obj.transform.position = new Vector2(move_obj.transform.position.x, move_obj.transform.position.y + (block_w / (60000 * Time.deltaTime)) * m_num);
                if (Mathf.Abs(move_obj.transform.position.y - move_obj_y) < 1)
                {
                    move_obj.transform.position = new Vector2(move_obj.transform.position.x, move_obj_y);
                }
            }
            if (move_obj.transform.position.x == move_obj_x && move_obj.transform.position.y == move_obj_y)
            {
                move_obj = null;
                Game_admin.wait_mode = false;
                Game_admin.mode_check();
            }
        }
        if (angle_obj != null)
        {

            int m_num;
            if (angle_obj.transform.localEulerAngles.z <= angle_obj_angle) { m_num = 1; }
            else { m_num = -1; }

            if (angle_obj.transform.rotation.z != angle_obj_angle)
            {
                angle_obj.transform.rotation = Quaternion.AngleAxis(angle_obj.transform.localEulerAngles.z + 90 / (600000 * Time.deltaTime) * m_num, Vector3.forward);
                if (Mathf.Abs(angle_obj.transform.localEulerAngles.z - angle_obj_angle) < 1 || Mathf.Abs(angle_obj.transform.localEulerAngles.z - (angle_obj_angle + 360)) < 1)
                {
                    angle_obj.transform.rotation = Quaternion.AngleAxis(Mathf.Round(angle_obj_angle), Vector3.forward);
                    angle_obj = null;
                    Game_admin.wait_mode = false;
                    Game_admin.mode_check();
                    
                }
            }
        }
    }



    public void Face_reset()
    {
        bool finish = false;



        if (finish)
        {
            Q_mode = 1;
            delay_mode = 0;
            delay = 2;
        }
    }
}

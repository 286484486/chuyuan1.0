using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Qblock_control : SerializedMonoBehaviour
{
    private int delay_mode;
    private float delay;
    public int Q_mode;
    public GameObject[,] Save_obj = new GameObject[5,5];
    private string[,] Save_obj_name = new string[5, 5];
    public GameObject[,] Save_finish_obj = new GameObject[5, 5];
    public GameObject now_obj;
    private float y_move,mouse_y,x_move,mouse_x,now_x,now_y;
    private int now_i, now_j;
    private int block_count;
    private float block_w;

    private GameObject move_obj;
    private float move_obj_x;
    private float move_obj_y;
    public float spd_max=500;


    // Start is called before the first frame update

    void Awake()
    {
        block_count = 0;
        Q_mode = 0;
        delay = 0;
        delay_mode = 0;
        block_w = 116;
        move_obj = null;
        for (int i = 0; i < Save_obj.GetLength(0); i++)
        {
            for (int j = 0; j < Save_obj.GetLength(1); j++)
            {
                Save_obj_name[i, j] = "";
                if (Save_obj[i, j] != null)
                {

                    Instantiate(Save_obj[i,j],transform.parent);
                    Save_obj[i, j].transform.position = new Vector2(transform.position.x - 264 + i * block_w, transform.position.y + 180 - j * block_w);
                }
                if (Save_finish_obj[i, j] != null)
                {
                    Save_finish_obj[i, j].transform.position = new Vector2(transform.position.x - 264 + i * block_w, transform.position.y + 180 - j * block_w);
                    Save_obj_name[i, j] = Save_finish_obj[i, j].GetComponent<Qblock_block>().block_check_name; Save_finish_obj[i, j] = null;
                    block_count += 1;
                }
            }
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (delay > 0) {return; }
        BoxCollider2D coll;
        if (Input.GetMouseButtonDown(0) && Game_admin.Some_mode && move_obj==null)
        {
            for (int i = 0; i < Save_obj.GetLength(0); i++)
            {
                for (int j = 0; j < Save_obj.GetLength(1); j++)
                {
                    if (Save_obj[i, j] != null)
                    {
                        
                        if (Save_obj[i, j].GetComponent<Qblock_block>().block_name=="block")
                        {
                            coll = Save_obj[i, j].GetComponent<BoxCollider2D>();
                            if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                            {
                                
                                now_obj = Save_obj[i, j];
                                now_i = i;
                                now_j = j;
                                y_move = 0;
                                x_move = 0;
                                mouse_x = Input.mousePosition.x;
                                mouse_y = Input.mousePosition.y;
                                move_obj_x = now_obj.transform.position.x;
                                move_obj_y = now_obj.transform.position.y;
                                now_x = now_obj.transform.position.x;
                                now_y = now_obj.transform.position.y;
                            }
                        }
                    }
                }
            }
        }

        if (now_obj != null)
        {

            x_move += Input.mousePosition.x - mouse_x;
            y_move += Input.mousePosition.y - mouse_y;


            move_obj = now_obj;

            if (move_obj != null)
            {
                if (now_obj == null)
                {
                    x_move = 0;
                    y_move = 0;
                }
            }
            mouse_x = Input.mousePosition.x;
            mouse_y = Input.mousePosition.y;
            if (y_move !=0 || x_move!=0)
            {
                if (y_move >0)
                {
                    if (now_j != 0)
                    {
                        if (Save_obj[now_i, now_j - 1] == null)
                        {
                            
                            move_obj_y = now_y + y_move;
                            
                        }
                        else
                        {
                            move_obj_y = now_y;
                        }
                    }
                    else { move_obj_y = now_y; }
                }
                if (y_move <0)
                {
                    if (now_j != Save_obj.GetLength(1)-1)
                    {
                        if (Save_obj[now_i, now_j + 1] == null)
                        {
                            move_obj_y = now_y + y_move;
                        }
                        else { move_obj_y = now_y; }
                    }
                    else
                    {
                        move_obj_y = now_y;
                    }
                }
                if (x_move >0)
                {
                    if (now_i != Save_obj.GetLength(0)-1)
                    {
                        if (Save_obj[now_i+1, now_j] == null)
                        {
                            move_obj_x = now_x + x_move;
                        }
                        else
                        {
                            move_obj_x = now_x;
                        }
                    }
                    else
                    {
                        move_obj_x = now_x;
                    }
                }
                if (x_move <0)
                {
                    if (now_i != 0)
                    {
                        if (Save_obj[now_i - 1, now_j] == null)
                        {
                            move_obj_x = now_x + x_move;
                        }
                        else
                        {
                            move_obj_x = now_x;
                        }
                    }
                    else
                    {
                        move_obj_x = now_x;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                now_obj = null;
                move_obj_x = now_x;
                move_obj_y = now_y;


            }


            if(now_obj == null)
            {

            }

        }

        if (move_obj != null)
        {
            float v_spd;
            int m_num;
            if(move_obj.transform.position.x!= move_obj_x && Mathf.Abs(now_y- move_obj.transform.position.y)<spd_max*Time.deltaTime/2)
            {
                move_obj.transform.position = new Vector2(move_obj.transform.position.x, now_y);
 

                v_spd = spd_max;
                if (move_obj.transform.position.x <= move_obj_x) { m_num = 1; }
                else { m_num = -1; }
                move_obj.transform.position = new Vector2(move_obj.transform.position.x + v_spd * Time.deltaTime * m_num, move_obj.transform.position.y);
                if (Mathf.Abs(move_obj.transform.position.x - move_obj_x) < v_spd * Time.deltaTime)
                {
                    move_obj.transform.position = new Vector2(move_obj_x, move_obj.transform.position.y);
                    if (now_obj == null)
                    {
                        Face_reset();
                    }
                }

                if (move_obj_x - now_x < -block_w / 2)
                {
                    Save_obj[now_i-1, now_j] = Save_obj[now_i, now_j];
                    Save_obj[now_i, now_j] = null;
                    now_i-= 1;
                    now_x -= block_w;
                    x_move += block_w;
                    move_obj_x = now_x + x_move;
                }
                if (move_obj_x - now_x > block_w / 2)
                {
                    Save_obj[now_i+1, now_j] = Save_obj[now_i, now_j];
                    Save_obj[now_i, now_j] = null;
                    now_i += 1;
                    now_x += block_w;
                    x_move -= block_w;
                    move_obj_x = now_x + x_move;
                }
            }
            if (move_obj.transform.position.y != move_obj_y && Mathf.Abs(now_x - move_obj.transform.position.x) < spd_max * Time.deltaTime / 2)
            {
                move_obj.transform.position = new Vector2(now_x, move_obj.transform.position.y);
 

                v_spd = spd_max;
                if (move_obj.transform.position.y <= move_obj_y) { m_num = 1; }
                else { m_num = -1; }
                move_obj.transform.position = new Vector2(move_obj.transform.position.x, move_obj.transform.position.y+ v_spd * Time.deltaTime * m_num);
                if(Mathf.Abs(move_obj.transform.position.y - move_obj_y) < v_spd * Time.deltaTime)
                {
                    move_obj.transform.position = new Vector2(move_obj.transform.position.x, move_obj_y);
                    if (now_obj == null)
                    {
                        Face_reset();
                    }
                }
                
                if (move_obj_y - now_y < -block_w / 2)
                {
                    Save_obj[now_i,now_j + 1] = Save_obj[now_i, now_j];
                    Save_obj[now_i, now_j] = null;
                    now_j += 1;
                    now_y -= block_w;
                    y_move += block_w;
                    move_obj_y = now_y + y_move;
                }
                if (move_obj_y - now_y > block_w / 2)
                {
                    Save_obj[now_i, now_j - 1] = Save_obj[now_i, now_j];
                    Save_obj[now_i, now_j] = null;
                    now_j -= 1;
                    now_y += block_w;
                    y_move -= block_w;
                    move_obj_y = now_y + y_move;
                }
                
            }
            if(move_obj.transform.position.x==move_obj_x && move_obj.transform.position.y == move_obj_y)
            {
                move_obj = null;
                Game_admin.wait_mode = false;
                Game_admin.mode_check();
            }
        }
    }



    public void Face_reset()
    {
        bool finish = true;

        for (int i = 0; i < Save_obj.GetLength(0); i++)
        {
            for (int j = 0; j < Save_obj.GetLength(1); j++)
            {
                if (Save_obj[i, j] != null)
                {
                    if (Save_obj[i, j].GetComponent<Qblock_block>().block_name == "block")
                    {
                        if (Save_obj[i, j].GetComponent<Qblock_block>().block_check_name != Save_obj_name[i, j]) { finish = false; break; }
                    }
                }
            }
            if (!finish) { break; }
        }


        if (finish)
        {
            Q_mode = 1;
            delay_mode = 0;
            delay = 2;
        }
    }
}

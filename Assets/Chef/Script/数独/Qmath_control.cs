using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Qmath_control : SerializedMonoBehaviour
{
    private int delay_mode;
    private float delay;
    public int Q_mode;


    private GameObject[,] Math_obj = new GameObject[6, 6];
    private GameObject[,] touch_obj = new GameObject[6, 6];
    public bool[,] Math_Qset = new bool[6, 6];
    private GameObject now_obj,move_obj;
    private int now_i, now_j,move_mode;
    private float move_x, move_y;

    public GameObject block_perfab;
    public GameObject block_get;

    public GameObject touch_prefab;

    // Start is called before the first frame update

    void Awake()
    {
        Q_mode = 0;
        delay = 0;
        delay_mode = 0;

        for(int i = 0; i < Math_obj.GetLength(0); i++)
        {
            for (int j = 0; j < Math_obj.GetLength(1); j++)
            {
                touch_obj[i,j]=Instantiate(touch_prefab, transform.parent);
                touch_obj[i, j].transform.position = new Vector2(transform.position.x - 264 + i * 150, transform.position.y - 264 + j * 150);
            }
        }
        transform.parent.gameObject.SetActive(false);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (delay > 0) { return; }
   
        BoxCollider2D coll;
        if (Input.GetMouseButtonDown(0) && Game_admin.Some_mode )
        {
            if (now_obj == null && move_obj == null)
            {
                coll = block_get.GetComponent<BoxCollider2D>();
                if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {

                    now_obj = Instantiate(block_perfab, transform.parent);
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    now_obj.transform.position = new Vector2(mousePosition.x, mousePosition.y);
                    now_i = -1;
                    now_j = -1;
                }
            }
            if(now_obj == null && move_obj == null)
            {
                for (int i = 0; i < Math_obj.GetLength(0); i++)
                {
                    for (int j = 0; j < Math_obj.GetLength(1); j++)
                    {
                        if(Math_obj[i, j] == null) { continue; }
                        coll = Math_obj[i,j].GetComponent<BoxCollider2D>();
                        if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                        {
                            now_obj = Math_obj[i, j];
                            now_i = i;
                            now_j = j;
                        }
                    }
                }
            }
        }

        if (now_obj != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            now_obj.transform.position = new Vector2(mousePosition.x, mousePosition.y);
            if (Input.GetMouseButtonUp(0))
            {
                move_mode = 0;
                move_obj = now_obj;
                move_x = block_get.transform.position.x;
                move_y = block_get.transform.position.y;
                if (now_i != -1) { Math_obj[now_i, now_j] = null; }
                for (int i = 0; i < touch_obj.GetLength(0); i++)
                {
                    for (int j = 0; j < touch_obj.GetLength(1); j++)
                    {
                        if (touch_obj[i, j] == null) { continue; }
                        if (Math_obj[i, j] != null)
                        {
                            if (Math_obj[i, j] != now_obj) { continue; }
                        }
                        coll = touch_obj[i, j].GetComponent<BoxCollider2D>();
                        if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                        {
                            move_mode = 1;
                            move_x = touch_obj[i, j].transform.position.x;
                            move_y = touch_obj[i, j].transform.position.y;
                            Math_obj[i, j] = now_obj;
                            
                        }
                    }
                }

                now_obj = null;
            }
        }


        if(move_obj!=null && now_obj == null)
        {
            float v_dis=Vector2.Distance(new Vector2(move_obj.transform.position.x, move_obj.transform.position.y),new Vector2(move_x,move_y));
            if (v_dis > 0)
            {
                float v_spd = 10 * Time.deltaTime;
                if (v_spd > 1) { v_spd = 1; }
                Vector2 v_dis_pos= (new Vector2(move_x, move_y) - new Vector2(move_obj.transform.position.x, move_obj.transform.position.y)).normalized * v_dis * v_spd;
                move_obj.transform.position = new Vector2(move_obj.transform.position.x+v_dis_pos.x, move_obj.transform.position.y + v_dis_pos.y);
                if (Vector2.Distance(new Vector2(move_obj.transform.position.x, move_obj.transform.position.y), new Vector2(move_x, move_y)) < 1f)
                {
                    move_obj.transform.position = new Vector2(move_x, move_y);
                }
            }
            else
            {
                Face_reset();
                if (move_mode == 0)
                {
                    Destroy(move_obj);
                }
                move_obj = null;
            }
        }
    }



    public void Face_reset()
    {
        bool finish = true;

        for (int i = 0; i < Math_obj.GetLength(0); i++)
        {
            for (int j = 0; j < Math_obj.GetLength(1); j++)
            {
                if(Math_obj[i,j]==null && Math_Qset[i,j]) { finish = false;break; }
                if (Math_obj[i, j] != null && !Math_Qset[i, j]) { finish = false; break; }
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

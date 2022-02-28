using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Qbelt_control : SerializedMonoBehaviour
{
    private int delay_mode;
    private float delay;
    public int Q_mode;

    private GameObject[,] Save_obj = new GameObject[7, 1];
    public int[,] Save_obj_name = new int[7, 1];
    private GameObject now_obj;
    private int now_i,now_j, now_count;

    public GameObject block_prefab;
    // Start is called before the first frame update

    void Awake()
    {
        Q_mode = 0;
        delay = 0;
        delay_mode = 0;

        now_count = 0;
        for (int i = 0; i < Save_obj.GetLength(0); i++)
        {
            for (int j = 0; j < Save_obj.GetLength(1); j++)
            {
                Save_obj[i, j] = Instantiate(block_prefab, transform.parent);
                Save_obj[i, j].transform.position = new Vector2(transform.position.x - (525 - 120) + i * 950 / 7, transform.position.y);
            }
            
        }
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
            for (int i = 0; i < Save_obj.GetLength(0); i++)
            {
                for (int j = 0; j < Save_obj.GetLength(1); j++)
                {
                    if (Save_obj[i, j] != null)
                    {
                        coll = Save_obj[i,j].GetComponent<BoxCollider2D>();
                        if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                        {
                            if (!Save_obj[i,j].GetComponent<Qbelt_data>().is_lock)
                            {
                                now_obj = Save_obj[i,j];
                                now_i = i;
                                now_j = j;
                            }
                        }
                    }
                }
            }
        }

        if (now_obj != null)
        {
            coll = Save_obj[now_i,now_j].GetComponent<BoxCollider2D>();
            if (!coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                now_obj = null;
            }
            if (now_obj != null)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    if(Save_obj_name[now_i, now_j] == now_count)
                    {
                        now_count += 1;
                        Save_obj[now_i, now_j].GetComponent<Qbelt_data>().is_lock = true;
                        Save_obj[now_i, now_j].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
                    }
                    else
                    {
                        for (int i = 0; i < Save_obj.GetLength(0); i++)
                        {
                            for (int j = 0; j < Save_obj.GetLength(1); j++)
                            {
                                Save_obj[i, j].GetComponent<Qbelt_data>().is_lock = false;
                                Save_obj[i, j].GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.08f, 0.28f);
                            }

                        }
                        now_count = 0;
                    }

                    now_obj = null;
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

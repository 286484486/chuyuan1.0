using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Qpair_control : SerializedMonoBehaviour
{
    private int delay_mode;
    private float delay;
    public int Q_mode;
    private GameObject[,] Save_obj = new GameObject[6, 6];
    public int[,] Save_obj_name = new int[6, 6];
    private GameObject now_obj;
    private int now_i, now_j;
    private int block_count;
    private int[] Save_obj_set_i = new int[2];
    private int[] Save_obj_set_j = new int[2];

    public GameObject block_prefab;

    // Start is called before the first frame update

    void Awake()
    {
        Save_obj_set_i[0] = -1;
        Save_obj_set_j[0] = -1;
        Save_obj_set_i[1] = -1;
        Save_obj_set_j[1] = -1;
        block_count = 0;
        Q_mode = 0;
        delay = 0;
        delay_mode = 0;
        for (int i = 0; i < Save_obj.GetLength(0); i++)
        {
            for (int j = 0; j < Save_obj.GetLength(1); j++)
            {
                Save_obj[i, j] = Instantiate(block_prefab, transform.parent);
                Save_obj[i, j].transform.position = new Vector2(transform.position.x - (300 + 25 / 2) + i * 125, transform.position.y + (300 + 25 / 2) - j * 125);
                block_count += 1;
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

                        if (!Save_obj[i, j].GetComponent<Qpair_data>().is_lock)
                        {
                            coll = Save_obj[i, j].GetComponent<BoxCollider2D>();
                            if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                            {

                                now_obj = Save_obj[i, j];
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
            coll = Save_obj[now_i, now_j].GetComponent<BoxCollider2D>();
            if (!coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                now_obj = null;
            }
            if (now_obj != null)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    if (Save_obj_set_i[0]!=-1)
                    {
                        if (Save_obj_name[Save_obj_set_i[0], Save_obj_set_j[0]] == Save_obj_name[now_i, now_j])
                        {
                            Save_obj[Save_obj_set_i[0], Save_obj_set_j[0]].GetComponent<Qpair_data>().is_lock = true;
                            Save_obj[now_i, now_j].GetComponent<Qpair_data>().is_lock = true;
                            Save_obj[Save_obj_set_i[0], Save_obj_set_j[0]].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                            Save_obj[now_i, now_j].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                            block_count -= 2;
                            Save_obj_set_i[0] = -1;
                            Save_obj_set_j[0] = -1;
                        }
                        else
                        {
                            Save_obj[Save_obj_set_i[0], Save_obj_set_j[0]].GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.08f, 0.28f);
                            Save_obj[Save_obj_set_i[0], Save_obj_set_j[0]].GetComponent<Qpair_data>().is_lock = false;
                            Save_obj_set_i[0] = -1;
                            Save_obj_set_j[0] = -1;
                        }
                    }
                    else
                    {
                        if(Save_obj_set_i[0] == -1)
                        {
                            Save_obj_set_i[0] = now_i;
                            Save_obj_set_j[0] = now_j;
                            Save_obj[now_i, now_j].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
                            Save_obj[now_i, now_j].GetComponent<Qpair_data>().is_lock = true;
                        }
                    }
                    now_obj = null;
                }
            }
            if (now_obj == null)
            {

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

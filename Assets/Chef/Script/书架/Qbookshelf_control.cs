using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Qbookshelf_control : SerializedMonoBehaviour
{
    private int delay_mode;
    private float delay;
    public int Q_mode;

    public List<GameObject> Save_obj;
    private GameObject now_obj, now_set;
    private int now_i,now_count;

    // Start is called before the first frame update

    void Awake()
    {
        Q_mode = 0;
        delay = 0;
        delay_mode = 0;

        now_count = 0;
        now_set = null;
        for (int i = 0; i < Save_obj.Count; i++)
        {
            if (Save_obj[i] != null)
            {
                Save_obj[i].transform.position = new Vector2(transform.position.x - (525 - 120) + i * 950 / 7, transform.position.y);
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
            for (int i = 0; i < Save_obj.Count; i++)
            {
                if (Save_obj[i] != null)
                {
                    coll = Save_obj[i].GetComponent<BoxCollider2D>();
                    if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                    {
                        if (!Save_obj[i].GetComponent<Qbookshelf_data>().is_lock || Save_obj[i] == now_set)
                        {
                            now_obj = Save_obj[i];
                            now_i = i;
                        }
                    }
                }         
            }
        }

        if (now_obj != null)
        {
            bool is_fail = false;
            coll = Save_obj[now_i].GetComponent<BoxCollider2D>();
            if (!coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                now_obj = null;
            }
            if (now_obj != null)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    if (Save_obj[now_i] == now_set)
                    {
                        now_count -= 1;
                        Save_obj[now_i].GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.08f, 0.28f);
                        now_set.GetComponent<Qbookshelf_data>().is_lock = false;
                        if (Save_obj[now_i].GetComponent<Qbookshelf_data>().last_set != null) { 
                            now_set = Save_obj[now_i].GetComponent<Qbookshelf_data>().last_set;
                            now_set.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                        }
                        else { now_set = null; }
                    }
                    else
                    {
                        if(now_count == 0)
                        {
                            now_count += 1;
                            now_set = Save_obj[now_i];
                            now_set.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                        }
                        else
                        {
                            is_fail = true;
                            for (int i=0;i< Save_obj[now_i].GetComponent<Qbookshelf_data>().book_Tag.Count;i++)
                            {
                                for (int j = 0; j < now_set.GetComponent<Qbookshelf_data>().book_Tag.Count; j++)
                                {
                                    if (Save_obj[now_i].GetComponent<Qbookshelf_data>().book_Tag[i] == now_set.GetComponent<Qbookshelf_data>().book_Tag[j])
                                    {
                                        is_fail = false;
                                        break;
                                    }
                                }
                            }
                            if (!is_fail)
                            {
                                now_count += 1;
                                now_set.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);

                                now_set.GetComponent<Qbookshelf_data>().is_lock = true;
                                Save_obj[now_i].GetComponent<Qbookshelf_data>().last_set=now_set;
                                now_set = Save_obj[now_i];
                                now_set.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

                            }
                        }
                    }
                    now_obj = null;   
                }


                if (is_fail)
                {
                    for (int i = 0; i < Save_obj.Count; i++)
                    {
                            if (Save_obj[i] != null)
                            {
                                Save_obj[i].GetComponent<Qbookshelf_data>().is_lock = false;
                                Save_obj[i].GetComponent<Qbookshelf_data>().last_set = null;
                                Save_obj[i].GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.08f, 0.28f);
                                now_count = 0;
                                now_set = null;
                            }
                        
                    }
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

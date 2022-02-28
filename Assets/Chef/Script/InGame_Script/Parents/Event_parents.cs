using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class Event_parents : SerializedMonoBehaviour
{
    private BoxCollider2D coll;
    private bool draging;


    //private GameObject next_TRI;
    public List<GameObject> next_TRI_L = new List<GameObject>();
    public float time = 0;
    public float time_set = 0;

    [Title("条件触发(自定)")]
    public List<Event_Condition> E_condition=new List<Event_Condition>();
    [Title("下一个触发器廷时触发")]
    public float next_time = 0;
    [HideInInspector]
    public bool next_switch = false;
    private int Script_swirch = 0;
    public int bag_check = -1;    //背包數量

    private float pos_x, pos_y;
    void Awake()
    {

        //gameObject.SetActive(Script_on);
        pos_x = Camera.main.transform.position.x;
        pos_y = Camera.main.transform.position.y;
    }
    void Start()
    {
        if (!Game_admin.game_admin_static.is_tri_vis)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        coll = gameObject.GetComponent<BoxCollider2D>();
        
        Event_Set v_event_set = gameObject.GetComponent<Event_Set>();
        if (v_event_set != null)
        {
            /*
            time = v_event_set.time;
            time_set = time;
            if (v_event_set.next_TRI != null)
            {
                next_TRI = v_event_set.next_TRI;
            }
            */
            if (v_event_set.Start_tri)
            {
                Script_set();
                v_event_set.Start_tri = false;
            }
        }


    }
    
    void Update()
    {
        if (next_switch && Game_admin.Message_mode==false && !Talk_control.talk_mode) {

            Game_admin.Delay = 1;
            if (time_set <= 0)
            {
                Script_set();
                next_switch = !next_switch;
                Game_admin.Delay = 0;
                time_set = time;
            }
            else { time_set -= Time.deltaTime; }

        }

        if (Script_swirch>0)
        {
            if (Script_swirch == 1)
            {
                Script_swirch = 0;
                Game_admin.Script_obj_on = 5;
                if (gameObject.GetComponent<Event_Set>().sort_set == Game_admin.Script_obj_sort)
                {
                    Script_set();
                }
            }
            else
            {
                Script_swirch -= 1;
            }
        }
 
        MDown();
        //Mdrag();
        MUp();

    }

    private void MDown()
    {

        if (coll != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition = new Vector2(mousePosition.x + (pos_x - Camera.main.transform.position.x), mousePosition.y + (pos_y - Camera.main.transform.position.y));
                if (mousePosition.y - pos_y >= -710 && mousePosition.y - pos_y <= 850)
                {
                    if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                    {
                        if (Game_admin.Delay == 0 && Game_admin.Some_mode && Talk_control.talk_mode == false)
                        {
                            draging = true;
                        }
                    }
                }
            }
        }
    }

    private void MUp()
    {
        if (Input.GetMouseButtonUp(0) && coll != null)
        { 
            if (draging)
            {
                draging = false;
                if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    if (Game_admin.Script_obj_on == 0)
                    {
                        Event_Set v_event_set = gameObject.GetComponent<Event_Set>();
                        if (Game_admin.Script_obj == null)
                        {
                            Game_admin.Script_obj_sort = v_event_set.sort_set;
                            Game_admin.Script_obj = gameObject;
                        }
                        if (v_event_set.sort_set > Game_admin.Script_obj_sort)
                        {
                            Game_admin.Script_obj = gameObject;
                            Game_admin.Script_obj_sort = v_event_set.sort_set;

                        }
                        Script_swirch = 1;
                    }
                }
            }
        }
    }

    /*
    private void OnMouseUpAsButton()
    {
        if (Game_admin.Delay == 0 && Game_admin.Some_mode && Talk_control.talk_mode == false)
        {
            Script_set();
        }
    }
    */

    private void Script_set()
    {
        bool EC_return = true;
        if (E_condition.Count > 0)
        {
            EC_return = false;
            bool EC_return_foreach;
            for (int i = 0; i < E_condition.Count; i++)
            {
                EC_return_foreach = true;
                if (E_condition[i] == null) { continue; }
                if (E_condition[i].item_id != null)
                {
                    if (Bag_script.Bag_select == null) { continue; }
                    item_bag_Script sc = Bag_script.Bag_select.GetComponent<item_bag_Script>();
                    if (E_condition[i].item_set)
                    {
                        if (sc.itemName != E_condition[i].item_id.itemName) { continue; }
                    }
                    else
                    {
                        if (sc.itemName == E_condition[i].item_id.itemName) { continue; }
                    }
                }

                if (E_condition[i].is_choose && Bag_script.Bag_select != null) { continue; }

                if (E_condition[i].image_pic.Count > 0)
                {
                    foreach (GameObject key in E_condition[i].image_pic.Keys)
                    {
                        if (key != null && E_condition[i].image_pic[key] != null)
                        {
                            if (E_condition[i].image_set)
                            {
                                if (key.GetComponent<SpriteRenderer>().sprite != E_condition[i].image_pic[key])
                                {
                                    EC_return_foreach = false;
                                    break;
                                }
                            }
                            else
                            {
                                if (key.GetComponent<SpriteRenderer>().sprite == E_condition[i].image_pic[key])
                                {
                                    EC_return_foreach = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (!EC_return_foreach) { continue; }
                }


                if (E_condition[i].image_vis.Count > 0)
                {
                    foreach (GameObject key in E_condition[i].image_vis.Keys)
                    {
                        if (key != null)
                        {
                            if (E_condition[i].image_vis[key])
                            {
                                if (!key.activeSelf)
                                {
                                    EC_return_foreach = false;
                                    break;
                                }
                            }
                            else
                            {
                                if (key.activeSelf)
                                {
                                    EC_return_foreach = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (!EC_return_foreach) { continue; }
                }

                Event_Set v_event_set = null;
                if (E_condition[i].var_obj != null)
                {
                    v_event_set=E_condition[i].var_obj.GetComponent<Event_Set>();
                }

                if (v_event_set != null && E_condition[i].is_var.Count > 0)
                {
                    foreach (string key in E_condition[i].is_var.Keys)
                    {
                        if (v_event_set.var_set.ContainsKey(key))
                        {
                            if (!(v_event_set.var_set[key] == E_condition[i].is_var[key]) && E_condition[i].var_con[key]==0)
                            {
                                EC_return_foreach = false;
                                break;
                            }
                            if (!(v_event_set.var_set[key] > E_condition[i].is_var[key]) && E_condition[i].var_con[key] == 1)
                            {
                                EC_return_foreach = false;
                                break;
                            }
                            if (!(v_event_set.var_set[key] >= E_condition[i].is_var[key]) && E_condition[i].var_con[key] == 2)
                            {
                                EC_return_foreach = false;
                                break;
                            }
                            if (!(v_event_set.var_set[key] < E_condition[i].is_var[key]) && E_condition[i].var_con[key] == 3)
                            {
                                EC_return_foreach = false;
                                break;
                            }
                            if (!(v_event_set.var_set[key] <= E_condition[i].is_var[key]) && E_condition[i].var_con[key] == 4)
                            {
                                EC_return_foreach = false;
                                break;
                            }
                        }
                    }
                }
                if (!EC_return_foreach) { continue; }
                EC_return = true;
                break;
            }
        }



        if (!EC_return) { return; }
        
        if (bag_check != -1)
        {
            int count = 0;

            for (int i = 0; i < Bag_script.item_List.Count; i++)
            {
                if (Bag_script.item_List[i].activeSelf)
                {
                    count++;
                }
            }
            if (count + bag_check > Bag_script.item_List.Count)
            {
                Game_admin.game_admin_static.TipsObj.GetComponent<Animation>().Stop();
                Game_admin.game_admin_static.TipsObj.transform.GetChild(0).GetComponent<Animation>().Stop();
                if (!Game_admin.game_admin_static.TipsObj.activeSelf) { Game_admin.game_admin_static.TipsObj.SetActive(true); }
                Game_admin.game_admin_static.TipsObj.GetComponentInChildren<Text>().text = "已经拿不下了...";
                Game_admin.game_admin_static.TipsObj.GetComponent<Animation>().Play("Black_windows2");
                Game_admin.game_admin_static.TipsObj.transform.GetChild(0).GetComponent<Animation>().Play("Text_windows2");
                //物品欄已滿
                return;
            }
        }
        
        Event_on("Click");
        
    }


    protected virtual void Event_on(string mode)
    {

    }

    protected void Event_send(string mode, Event_interface c)
    {
        if (mode == "Next")
        {
            Event_Invoker.AddCommand(c);
        }
        if (mode == "Click")
        {
            // Game_admin v_obj = new Game_admin();
            //v_obj.Click_end(c);
            Event_Invoker.AddCommand(c);
        }
        c.next_TRI_set(next_TRI_L, next_time);
    }
    protected void Event_send(string mode, Anima_interface c)
    {
        
        if (mode == "Next")
        {
            Event_Invoker.AddCommand(c);
        }
        if (mode == "Click")
        {
            //Game_admin v_obj = new Game_admin();
            //v_obj.Click_end(c);
            Event_Invoker.AddCommand(c);
        }
        c.next_TRI_set(next_TRI_L, next_time);
    }
}
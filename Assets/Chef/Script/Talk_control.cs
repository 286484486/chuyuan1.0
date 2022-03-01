using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class Talk_control : SerializedMonoBehaviour
{
    private float talk_index;
    private float talk_spd = 10;
    private int last_talk_event, other_event;
    private string talk_text,talk_text_last,other_event_arg1, other_event_arg2, other_event_arg3;
    //private string talk_text, talk_type,talk_CV, talk_event, other_event, other_event_arg1, other_event_arg2, other_event_arg3;
    private TalkSaveScript Talk_Script;
    [HideInInspector]
    public static bool talk_mode = false;
    private int talk_loc;
    private float talk_time, Obj_speed, Obj_speed_down;
    private string Obj_speed_mode;

    public GameObject CG_prefab;
    public GameObject canvas_talk,canvas_CG,canvas_tell, canvas_tips;
  
    public Image T_name, T_talk;
    public Text T_talk_text;
    //public string pathExcel;
    //private List<Dictionary<string, string>> G_talk_List = new List<Dictionary<string, string>>();
    private Dictionary<string, int> G_talk_loc = new Dictionary<string, int>();

    private List<GameObject> talk_CG = new List<GameObject>(); //立繪建立

    //public Dictionary<string, Sprite> talk_image_Dict = new Dictionary<string, Sprite>();

    private CG_save_script CG_script;

    private List<string> talk_histroy=new List<string>();

    private AudioSource audioSourecs;

    public Dictionary<string, GameObject> CG_loc_list = new Dictionary<string, GameObject>();

    public int Talk_mode;   //旁白模式

    public static Talk_control TK_static;

    void Awake()
    {
        canvas_CG.SetActive(false);
        canvas_talk.SetActive(false);
        canvas_tell.SetActive(false);
        canvas_tips.SetActive(false);
        CG_script = gameObject.GetComponent<CG_save_script>();
        TK_static = gameObject.GetComponent<Talk_control>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSourecs = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    { 
        Talk_show();
    }


    public void talk_Key(TalkSaveScript key)
    {
        if (key == null) { return; }

        talk_loc = 0;
        talk_time = 0;
        
        /*
        talk_text = "";
        talk_event = "";
        other_event = "";
        */
        Obj_speed = 300;
        Obj_speed_down = 0;
        Obj_speed_mode = "target";
        Talk_mode = 0;
        canvas_CG.SetActive(true);
        canvas_talk.SetActive(true);
        canvas_tell.SetActive(false);
        canvas_tips.SetActive(false);

        Talk_Script = key;
        other_event = 0;
        talk_spd = 10;
        T_talk.GetComponent<RectTransform>().localScale = new Vector2(1, 1);

        talk_Get();


        
    }

    public void talk_Get()
    {
        //Click=0,Next=1,End=2 , Add=3, wait=4


       


        talk_index = 0;



        //other_event = (int)Talk_Script.Talk[talk_loc].Other_Evnet;
        /*
        other_event_arg1 = Talk_Script.Talk[talk_loc].other_event_arg1;
        other_event_arg2 = Talk_Script.Talk[talk_loc].other_event_arg2;
        other_event_arg3 = Talk_Script.Talk[talk_loc].other_event_arg3;
        */


        talk_mode = true;




        if (other_event == 4)
        {
            talk_spd = Convert.ToSingle(other_event_arg1);
        }


        if (other_event == 18)
        {
            bool v_bool = true;
            if (other_event_arg2 == "F" || other_event_arg2 == "f")
            {
                v_bool = false;
            }
            if (CG_script.OBJ_dict.ContainsKey(other_event_arg1))
            {
                Dictionary<GameObject, bool> LG =new Dictionary<GameObject, bool>();
                LG.Add(CG_script.OBJ_dict[other_event_arg1], v_bool);
                Event_interface c = new item_visible_Command(LG);
                Event_Invoker.AddCommand(c);
            }
        }
        if (other_event == 7)
        {
            if (CG_script.OBJ_dict.ContainsKey(other_event_arg1))
            {
                float pos_x, pos_y;
                if(other_event_arg2 == "x")
                {
                    pos_x = CG_script.OBJ_dict[other_event_arg1].GetComponent<Transform>().position.x;
                }
                else { pos_x = Convert.ToSingle(other_event_arg2); }
                if (other_event_arg2 == "y")
                {
                    pos_y = CG_script.OBJ_dict[other_event_arg1].GetComponent<Transform>().position.y;
                }
                else { pos_y = Convert.ToSingle(other_event_arg3); }
                Event_interface c = new item_position_Command(CG_script.OBJ_dict[other_event_arg1], new Vector2(pos_x, pos_y));
                Event_Invoker.AddCommand(c);
            }
        }
        if (other_event == 8)
        {
            if (CG_script.OBJ_dict.ContainsKey(other_event_arg1))
            {
                float pos_x, pos_y;
                if (other_event_arg2 == "x")
                {
                    pos_x = CG_script.OBJ_dict[other_event_arg1].GetComponent<Transform>().position.x;
                }
                else { pos_x = CG_script.OBJ_dict[other_event_arg1].GetComponent<Transform>().position.x+Convert.ToSingle(other_event_arg2); }
                if (other_event_arg2 == "y")
                {
                    pos_y = CG_script.OBJ_dict[other_event_arg1].GetComponent<Transform>().position.y;
                }
                else { pos_y = CG_script.OBJ_dict[other_event_arg1].GetComponent<Transform>().position.y+Convert.ToSingle(other_event_arg3); }
                Event_interface c = new item_position_Command(CG_script.OBJ_dict[other_event_arg1], new Vector2(pos_x, pos_y));
                Event_Invoker.AddCommand(c);
            }
        }
        if (other_event == 9)
        {
            if (CG_script.OBJ_dict.ContainsKey(other_event_arg1))
            {
                Event_interface c = new item_depth_Command(CG_script.OBJ_dict[other_event_arg1], Convert.ToInt32(other_event_arg2));
                Event_Invoker.AddCommand(c);
            }
        }
        if (other_event == 10)
        {
 
            if (other_event_arg1 != "") { Obj_speed = Convert.ToSingle(other_event_arg1); }
            if (other_event_arg2 != "") { Obj_speed_down = Convert.ToSingle(other_event_arg2); }
            if (other_event_arg3 != "") { Obj_speed_mode = other_event_arg3; }
        }
        if (other_event == 11)
        {
            if (CG_script.OBJ_dict.ContainsKey(other_event_arg1))
            {
                float pos_x, pos_y;
                if (other_event_arg2 == "x")
                {
                    pos_x = CG_script.OBJ_dict[other_event_arg1].GetComponent<Transform>().position.x;
                }
                else { pos_x = Convert.ToSingle(other_event_arg2); }
                if (other_event_arg2 == "y")
                {
                    pos_y = CG_script.OBJ_dict[other_event_arg1].GetComponent<Transform>().position.y;
                }
                else { pos_y = Convert.ToSingle(other_event_arg3); }
                Anima_interface c = new Obj_move_ACommand(CG_script.OBJ_dict[other_event_arg1],pos_x,pos_y, Obj_speed, Obj_speed_down, Obj_speed_mode);
                Event_Invoker.AddCommand(c);
            }
        }
        if (other_event == 12)
        {
            Event_interface c = new Obj_stop_Command(CG_script.OBJ_dict[other_event_arg1]);
            Event_Invoker.AddCommand(c);
        }
        if (other_event == 13)
        {
            if (CG_script.CG_dict.ContainsKey(other_event_arg1))
            {
                Dictionary<GameObject, Sprite> LG = new Dictionary<GameObject, Sprite>();
                LG.Add(CG_script.OBJ_dict[other_event_arg1], CG_script.CG_dict[other_event_arg2]);
                Event_interface c = new image_change_Command(LG);
                Event_Invoker.AddCommand(c);

            }
        }
        if(other_event == 14)
        {
            if (CG_script.CG_dict.ContainsKey(other_event_arg1))
            {
                List<GameObject> v_obj = new List<GameObject>();
                v_obj.Add(CG_script.OBJ_dict[other_event_arg1]);
                Event_interface c = new item_switch_Command(v_obj);
                Event_Invoker.AddCommand(c);
            }
        }
        if(other_event== 15)
        {
            if (CG_script.CG_dict.ContainsKey(other_event_arg1))
            {

                Event_interface c = new room_Change_Command(CG_script.OBJ_dict[other_event_arg1], false,0) ;
                Event_Invoker.AddCommand(c);
            }
        }

        if(other_event == 17)
        {
            if (Talk_mode == 0)
            {
                canvas_CG.SetActive(false);
                canvas_talk.SetActive(false);
            }
            if (Talk_mode == 1)
            {
                canvas_tell.SetActive(false);
            }
        }




        talk_text = "";

        for (int i = 0; i < Talk_Script.Talk[talk_loc].Talk_Event_List.Count; i++)
        {
            TalkSaveEvent v_Talk_Event = Talk_Script.Talk[talk_loc].Talk_Event_List[i];
            if (v_Talk_Event.Talk_Event == TalkSaveEvent.Enum_Talk_Event.设置立绘)
            {
                if (v_Talk_Event.CG_set != null)
                {
                    if (talk_CG.Count < 1) { talk_CG.Add(Instantiate(CG_prefab, canvas_CG.GetComponent<Transform>())); }
                    talk_CG[0].GetComponent<Image>().sprite = v_Talk_Event.CG_set;
                    string v_loc_name = "";
                    if (v_Talk_Event.CG_set_loc == TalkSaveEvent.Enum_set_loc.左面) { v_loc_name = "Left"; T_talk.GetComponent<RectTransform>().localScale = new Vector2(1, 1); }
                    if (v_Talk_Event.CG_set_loc == TalkSaveEvent.Enum_set_loc.右面) { v_loc_name = "Right"; T_talk.GetComponent<RectTransform>().localScale = new Vector2(-1, 1); }
                    talk_CG[0].GetComponent<RectTransform>().anchoredPosition = CG_loc_list[v_loc_name].GetComponent<RectTransform>().anchoredPosition;
                    talk_CG[0].GetComponent<RectTransform>().sizeDelta = CG_loc_list[v_loc_name].GetComponent<RectTransform>().sizeDelta;
                    
                    float v_xsc = 1;
                    if (!v_Talk_Event.CG_set_xsc) { v_xsc = -1; }
                    talk_CG[0].GetComponent<RectTransform>().localScale = new Vector2(v_xsc, 1);
                    
                }
            }
            if (v_Talk_Event.Talk_Event == TalkSaveEvent.Enum_Talk_Event.删除立绘)
            {
                if (talk_CG.Count > 0)
                {
                    Destroy(talk_CG[0]);
                    talk_CG.RemoveAt(0);
                }
            }
            if (v_Talk_Event.Talk_Event == TalkSaveEvent.Enum_Talk_Event.文字显示速度)
            {
                talk_spd = v_Talk_Event.text_speed;
            }
            if (v_Talk_Event.Talk_Event == TalkSaveEvent.Enum_Talk_Event.对话模式)
            {
                canvas_CG.SetActive(false);
                canvas_talk.SetActive(false);
                canvas_tips.SetActive(false);
                canvas_tell.SetActive(false);


                if (v_Talk_Event.text_Talk_mode == TalkSaveEvent.Enum_talk_mode.模式1) {
                    canvas_CG.SetActive(true);
                    canvas_talk.SetActive(true);
                    Talk_mode = 0;
                    T_talk_text.text = "";
                }
                if (v_Talk_Event.text_Talk_mode == TalkSaveEvent.Enum_talk_mode.模式2)
                {
                    canvas_tell.SetActive(true);
                    Talk_mode = 1;
                    canvas_tell.GetComponentInChildren<Text>().text = "";
                }
                if (v_Talk_Event.text_Talk_mode == TalkSaveEvent.Enum_talk_mode.模式3)
                {
                    canvas_tips.SetActive(true);
                    Talk_mode = 2;
                    canvas_tips.GetComponentInChildren<Text>().text = "";
                }


            }
            if (v_Talk_Event.Talk_Event == TalkSaveEvent.Enum_Talk_Event.镜头抖动)
            {

                Anima_interface c = new Camera_jitter_Command(v_Talk_Event.camera_jitter_time);
                Event_Invoker.AddCommand(c);
            }
            if (v_Talk_Event.Talk_Event == TalkSaveEvent.Enum_Talk_Event.廷迟对话)
            {
                talk_time = v_Talk_Event.delay_time;
            }
            if (v_Talk_Event.Talk_Event == TalkSaveEvent.Enum_Talk_Event.连接上一句)
            {
                talk_text += talk_text_last;
                talk_index = talk_text.Length;
            }
        }

        
        talk_text += Talk_Script.Talk[talk_loc].TalkInfo;

        if (Talk_Script.Talk[talk_loc].Talk_Style != null)
        {
            T_talk.GetComponentInParent<Image>().sprite = Talk_Script.Talk[talk_loc].Talk_Style;
        }
        if (Talk_Script.Talk[talk_loc].Talk_CV != null)
        {
            audioSourecs.clip = Talk_Script.Talk[talk_loc].Talk_CV;
            audioSourecs.Play();
        }

        talk_histroy.Add(talk_text);
        while (talk_histroy.Count > 15)
        {
            talk_histroy.RemoveAt(0);
        }

        talk_text_last = talk_text;







    }

    private void Talk_show()
    {
       
        if (talk_mode)
        {
            if (talk_time > 0) { talk_time -= 1 * Time.deltaTime; }
            if (talk_time <= 0)
            {
                T_name.GetComponentInChildren<Text>().text = Talk_Script.Talk[talk_loc].TalkName;
                if (talk_index < talk_text.Length)
                {
                    if (Input.GetMouseButtonUp(0) && talk_index != 0 && Game_admin.Some_mode)
                    {
                        talk_index = talk_text.Length;
                    }
                    talk_index += talk_spd * Time.deltaTime;
                    if (Talk_mode == 0)
                    {
                        T_talk_text.text = talk_text.Substring(0, (int)talk_index);
                    }
                    if(Talk_mode == 1)
                    {
                        canvas_tell.GetComponentInChildren<Text>().text = talk_text.Substring(0, (int)talk_index);
                    }
                    if (Talk_mode == 2)
                    {
                        canvas_tips.GetComponentInChildren<Text>().text = talk_text.Substring(0, (int)talk_index);
                    }

                }
                else
                {
                    if (Input.GetMouseButtonUp(0) && Game_admin.Some_mode)
                    {
                        if (talk_loc + 1 == Talk_Script.Talk.Count)
                        {
                            Talk_Hide();
                        }
                        else
                        {
                            talk_loc = talk_loc + 1;
                            talk_Get();
                        }
                    }
                }
            }
        }
    }

    private void Talk_Hide()
    {
        for (int i = 0; i < talk_CG.Count; i++)
        {
            Destroy(talk_CG[i]);
        }
        talk_CG.Clear();
        

        talk_mode = false;
        canvas_CG.SetActive(false);
        canvas_talk.SetActive(false);
        canvas_tips.SetActive(false);
        canvas_tell.SetActive(false);

    }




}

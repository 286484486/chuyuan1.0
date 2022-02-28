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
    private int talk_event,last_talk_event, other_event;
    private string talk_text,other_event_arg1, other_event_arg2, other_event_arg3;
    private Sprite Talk_Style;
    private AudioClip Talk_CV;
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
    //public string pathExcel;
    //private List<Dictionary<string, string>> G_talk_List = new List<Dictionary<string, string>>();
    private Dictionary<string, int> G_talk_loc = new Dictionary<string, int>();

    private Dictionary<string, GameObject> talk_CG = new Dictionary<string, GameObject>(); //立繪建立

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

        #region Excel
        /*
        pathExcel = Application.dataPath + "/Chef/Excel/" + pathExcel + ".xlsx";

        FileInfo fileinfo = new FileInfo(pathExcel);

        using (ExcelPackage exPackage = new ExcelPackage(fileinfo))
        {
            ExcelWorksheet wsheel = exPackage.Workbook.Worksheets[1];
            string v_text = "";
            int i = 2;
            while (true)    //表格1
            {
 
                if (wsheel.Cells[i, 2].Value == null)
                {
                    break;
                }
                if (wsheel.Cells[i, 1].Value != null)
                {  //導入ID位置
                    G_talk_loc.Add(wsheel.Cells[i, 1].Value.ToString(), i);
                }
                Dictionary<string, string> Dict = new Dictionary<string, string>();
                Dict.Add("Name", wsheel.Cells[i, 2].Value.ToString());  //導入名字
                if (wsheel.Cells[i, 3].Value != null) { v_text = wsheel.Cells[i, 3].Value.ToString(); }    //導入對話
                else{
                    if (G_talk_List.Count > 0)
                    {
                        Dictionary<string, string> v_Dict = G_talk_List[G_talk_List.Count - 1];
                        v_text= v_Dict["Talk"];
                    }
                }

                Dict.Add("Talk", v_text);  v_text = "";
                if (wsheel.Cells[i, 4].Value != null) { v_text = wsheel.Cells[i, 4].Value.ToString(); }    //更換樣式
                Dict.Add("Type", v_text); v_text = "";
                if (wsheel.Cells[i, 5].Value != null) { v_text = wsheel.Cells[i, 5].Value.ToString(); }    //更換樣式
                Dict.Add("CV", v_text); v_text = "";
                if (wsheel.Cells[i, 6].Value != null) { v_text = wsheel.Cells[i, 6].Value.ToString(); }    //導入對話事件
                Dict.Add("Talk_event", v_text); v_text = "";
                if (wsheel.Cells[i, 7].Value != null) { v_text = wsheel.Cells[i, 7].Value.ToString(); }    //導入其他事件
                Dict.Add("Other_event", v_text); v_text = "";
                if (wsheel.Cells[i, 8].Value != null) { v_text = wsheel.Cells[i, 8].Value.ToString(); }    //導入參數1
                Dict.Add("arg1", v_text); v_text = "";
                if (wsheel.Cells[i, 9].Value != null) { v_text = wsheel.Cells[i, 9].Value.ToString(); }    //導入參數2
                Dict.Add("arg2", v_text); v_text = "";
                if (wsheel.Cells[i, 10].Value != null) { v_text = wsheel.Cells[i, 10].Value.ToString(); }    //導入參數3
                Dict.Add("arg3", v_text); v_text = "";

                G_talk_List.Add(Dict);



                i++;
            }


        }
        */
        #endregion
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

        Talk_Script = key;
        talk_event =0;
        other_event = 0;

        talk_Get();


        
    }

    public void talk_Get()
    {
        //Click=0,Next=1,End=2 , Add=3, wait=4

        string v_text;
        bool text_bool = true;
       

        last_talk_event = talk_event;
        talk_index = 0;

        if (talk_event == 3)    //add
        {
            if (!((int)Talk_Script.Talk[talk_loc].Talk_Event == 1 || (int)Talk_Script.Talk[talk_loc].Talk_Event == 4))
            {
                talk_index = talk_text.Length;
                talk_text = talk_text + Talk_Script.Talk[talk_loc].TalkInfo;
                text_bool = false;
            }
        }
        if (talk_event == 4)   //wait
        {
            canvas_CG.SetActive(false);
            canvas_talk.SetActive(false);
            canvas_tell.SetActive(false);
        }

        if (other_event == 3)     //Delay
        {
            float f1 = Convert.ToSingle(other_event_arg1);
            talk_time = f1 * Time.deltaTime;
        }
        v_text = Talk_Script.Talk[talk_loc].TalkInfo;
        T_name.GetComponentInChildren<Text>().text = Talk_Script.Talk[talk_loc].TalkName;
        Talk_Style = Talk_Script.Talk[talk_loc].Talk_Style;
        Talk_CV = Talk_Script.Talk[talk_loc].Talk_CV;
        talk_event = (int)Talk_Script.Talk[talk_loc].Talk_Event;
        other_event = (int)Talk_Script.Talk[talk_loc].Other_Evnet;
        other_event_arg1 = Talk_Script.Talk[talk_loc].other_event_arg1;
        other_event_arg2 = Talk_Script.Talk[talk_loc].other_event_arg2;
        other_event_arg3 = Talk_Script.Talk[talk_loc].other_event_arg3;

        talk_mode = true;

        if(Talk_CV != null)
        {
            audioSourecs.clip = Talk_CV;
            audioSourecs.Play();
        }

        if (other_event == 1)
        {
            if (!talk_CG.ContainsKey(other_event_arg1))
            { 
                talk_CG.Add(other_event_arg1, Instantiate(CG_prefab, canvas_CG.GetComponent<Transform>()));
                talk_CG[other_event_arg1].GetComponent<RectTransform>().anchoredPosition = CG_loc_list["Left"].GetComponent<RectTransform>().anchoredPosition;
                talk_CG[other_event_arg1].GetComponent<RectTransform>().sizeDelta = CG_loc_list["Left"].GetComponent<RectTransform>().sizeDelta;
            }
        }
        if (other_event == 2)
        {
            if (CG_script.CG_dict.ContainsKey(other_event_arg2))
            {
                talk_CG[other_event_arg1].GetComponent<Image>().sprite = CG_script.CG_dict[other_event_arg2];
            }
            if (CG_loc_list.ContainsKey(other_event_arg3))
            {
                talk_CG[other_event_arg1].GetComponent<RectTransform>().anchoredPosition = CG_loc_list[other_event_arg3].GetComponent<RectTransform>().anchoredPosition;
                talk_CG[other_event_arg1].GetComponent<RectTransform>().sizeDelta = CG_loc_list[other_event_arg3].GetComponent<RectTransform>().sizeDelta;
            }
        }
        if (other_event == 4)
        {
            talk_spd = Convert.ToSingle(other_event_arg1);
        }
        if (other_event == 6)
        {
            talk_CG[other_event_arg1].GetComponent<RectTransform>().localScale = new Vector2(Convert.ToSingle(other_event_arg2), 1);
        }
        if (other_event == 5)
        {   
            bool v_bool=true;
            if(other_event_arg2 == "F" || other_event_arg2=="f")
            {
                v_bool = false;
            }

            talk_CG[other_event_arg1].GetComponent<Image>().enabled = v_bool;
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
        if (other_event == 16)
        {
            if(other_event_arg1 == "0")
            {
                canvas_CG.SetActive(true);
                canvas_talk.SetActive(true);
                Talk_mode = 0;
                bool v_vis=true;
                if (CG_script.CG_dict.ContainsKey(other_event_arg2))
                {
                    if (other_event_arg2 == "1") { v_vis = false; }
                }

                if (v_vis) { 
                    canvas_tell.SetActive(false);
                    canvas_tips.SetActive(false);
                }
            }
            if (other_event_arg1 == "1")
            {
                
                canvas_tell.SetActive(true);
                Talk_mode = 1;
                bool v_vis = true;
                if (CG_script.CG_dict.ContainsKey(other_event_arg2))
                {
                    if (other_event_arg2 == "1") { v_vis = false; }
                }

                if (v_vis) {
                    canvas_CG.SetActive(false);
                    canvas_talk.SetActive(false);
                    canvas_tips.SetActive(false);
                }
                
            }
            if (other_event_arg1 == "2")
            {

                canvas_tips.SetActive(true);
                Talk_mode = 2;
                bool v_vis = true;
                if (CG_script.CG_dict.ContainsKey(other_event_arg2))
                {
                    if (other_event_arg2 == "1") { v_vis = false; }
                }

                if (v_vis)
                {
                    canvas_CG.SetActive(false);
                    canvas_talk.SetActive(false);
                    canvas_tell.SetActive(false);
                }

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


        if (Talk_Style != null)
        {
            T_talk.GetComponentInParent<Image>().sprite = Talk_Style;
        }

        if (talk_event == 4)
        {
            v_text = "";
        }
        if (talk_event == 1)
        {
            text_bool = false;
        }


        if (text_bool)
        {
            talk_text = v_text;
        }


        if (!(talk_event == 3 || talk_event == 1 || talk_event == 4))
        {
            talk_histroy.Add(talk_text);
            while (talk_histroy.Count > 5)
            {
                talk_histroy.RemoveAt(0);
            }
        }


        if (talk_event == 1)
        {
            talk_event = last_talk_event;
            talk_loc = talk_loc + 1;
            talk_Get();
            
        }
       


    }

    private void Talk_show()
    {
       
        if (talk_mode)
        {
            if (talk_time > 0) { talk_time -= 1 * Time.deltaTime; }
            if (talk_time <= 0)
            {
                if (talk_index < talk_text.Length)
                {
                    if (Input.GetMouseButtonUp(0) && talk_index != 0 && Game_admin.Some_mode)
                    {
                        int i = 0;
                        while (talk_event == 3 && i<100)
                        {
                            talk_loc = talk_loc + 1;
                            talk_Get();
                            talk_time = 0;
                            i++;
                        }
                        talk_index = talk_text.Length;
                    }
                    talk_index += talk_spd * Time.deltaTime;
                    if (Talk_mode == 0)
                    {
                        T_talk.GetComponentInChildren<Text>().text = talk_text.Substring(0, (int)talk_index);
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
                        if (talk_event == 0)
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
                        else
                        {
                            if (talk_event == 2)
                            {
                                Talk_Hide();
                            }
                        }
                    }
                    if(talk_event == 3 || talk_event == 4)
                    {
                        talk_loc = talk_loc + 1;
                        talk_Get();
                    }
                }
            }
        }
    }

    private void Talk_Hide()
    {
        foreach (string key in talk_CG.Keys)
        {
            Destroy(talk_CG[key]);
        }
        talk_CG.Clear();

        talk_mode = false;
        canvas_CG.SetActive(false);
        canvas_talk.SetActive(false);
        canvas_tips.SetActive(false);

    }




}

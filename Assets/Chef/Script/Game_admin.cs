using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Sirenix.OdinInspector;

public class Game_admin : MonoBehaviour
{
    public GameObject Prefab_Audio_set,Prefab_Click_anima, Prefab_Back_obj,Prefab_mini_Game_control;
    public Image Prefab_Get_message_image;
    public Text Prefab_Get_message_text, Prefab_Get_message_nmae;
    public static GameObject Audio_set;    //���ˆ�
    public GameObject Get_message_set; //�@����Ʒ�ˆ�
    public GameObject Check_message_set;    //�鿴��Ʒ�ˆ�
    public GameObject audio_play_object_prefab; //��Ч

    public static GameObject Click_anima;
    public static GameObject Click_object;
    public static int Delay;
    public static bool Some_mode,Stop_mode, Message_mode, wait_mode;
    public static GameObject Back_obj;  //����
    public GameObject Line_control; //����
    public static GameObject mini_Game_control; //С�[���o
    public GameObject Black_windows;    //��Ļ

    private bool Black_on;
    private string Black_mode, Black_mode_change_screen;  //��Ļ�¼�

    public Button_Canvas_Script button_canvas;    //���o����

    private int click_delay_some_mode;

    public static Game_admin game_admin_static;
    public GameObject Back_set_obj; //�O�÷���
    public static GameObject Obj_self; //

    public static GameObject Script_obj;    //���oobj
    public static float Script_obj_sort;   //���o�D��
    public static int Script_obj_on;   //���o
    public static GameObject MP4_obj;   //mp4
    public GameObject Prefab_MP4_obj;  //mp4
    [HideInInspector]
    public static List<GameObject> Back_camera = new List<GameObject>();
    public AudioMixer AudioMixer;   //��Ч����
    public GameObject TipsObj;   //��ʾ��
    [Title("��ʾ������")]
    public bool is_tri_vis; 

    void Awake()
    {
        Obj_self = gameObject;
        game_admin_static = gameObject.GetComponent<Game_admin>();
        Audio_set = Prefab_Audio_set;
        Click_anima = Prefab_Click_anima;
        mini_Game_control = Prefab_mini_Game_control;
        Back_obj = Prefab_Back_obj;
        MP4_obj = Prefab_MP4_obj;
        Delay =0;

        mode_check();

    
        
    }

    public void Click_end(Event_interface c)
    {

        /*
        if (Click_object == null)
        {
            Click_object = Instantiate(Click_anima);
        }
        Click_object.GetComponent<Click_anima_end>().Ievent.Enqueue(c);
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Click_object.GetComponent<Transform>().position =new Vector2(pos.x, pos.y);
        */
        Event_Invoker.AddCommand(c);
    }
    public void Click_end(Anima_interface c)
    {
        /*
        if (Click_object == null)
        {
            Click_object = Instantiate(Click_anima);
        }
        Click_object.GetComponent<Click_anima_end>().IAnima.Add(c);
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Click_object.GetComponent<Transform>().position = new Vector2(pos.x, pos.y);
        */
        Event_Invoker.AddCommand(c);
    }

    void Update()
    {
        Black_mode_set();
        if (click_delay_some_mode > 0)
        {
            if (click_delay_some_mode==1)
            {
                mode_check();
            }

            click_delay_some_mode -=1 ;

        }

        //����c��Ӯ�
        if (Input.GetMouseButtonDown(0))
        {
            if (Game_admin.Delay == 0 && Game_admin.Some_mode && Talk_control.talk_mode == false)
            {
                Click_object = Instantiate(Prefab_Click_anima, Camera.main.transform);
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Click_object.GetComponent<Transform>().position = new Vector2(pos.x, pos.y);
            }
        }

        if (Script_obj_on>0)
        {
            Script_obj_on -= 1;
            if (Script_obj_on == 0) {
                Script_obj = null;
            }
        }

    }

    public static void Set_Open()  //���_�O�òˆ�
    {
        if (wait_mode) { return; }
        if (Message_mode) { return; }

        Audio_set.SetActive(!Audio_set.activeSelf);
        if (Audio_set.activeSelf)
        {     
            Stop_mode = true;
            mode_check();
        }
        else { Stop_mode = false; game_admin_static.click_delay_some_mode = 2; }

       
    }
    public static void Get_message_On(int mode,item_bag_Script sc)
    {

        if (mode == 0)
        {
            GameObject v_message = game_admin_static.Get_message_set;
            Get_Message_Script v_script = v_message.GetComponent<Get_Message_Script>();
            v_script.Get_message_image.sprite = sc.itemImage;
            v_script.Get_message_text.text = sc.itemInfo;
            v_script.Get_message_name.text = sc.itemName;
            v_message.SetActive(true);
        }
        if(mode == 1)
        {
            GameObject v_message = game_admin_static.Check_message_set;
            Get_Message_Script v_script = v_message.GetComponent<Get_Message_Script>();
            v_script.Get_message_image.sprite = sc.itemImage;
            v_script.Get_message_text.text = sc.itemInfo;
            v_script.Get_message_name.text = sc.itemName;
            v_message.SetActive(true);
        }
        Message_mode = true;

        mode_check();
    }
    public static void Get_message_Close()
    {
        if (Stop_mode == false)
        {
            game_admin_static.Get_message_set.SetActive(false);
            game_admin_static.Check_message_set.SetActive(false);
            Message_mode = false;
            mode_check();
        }
    }

    public static void mode_check()
    {
        Some_mode = true;
        if (Stop_mode) { Some_mode = false; }
        if (Message_mode) { Some_mode = false; }
        if (wait_mode) { Some_mode = false; }
        
    }

    public void Back_Camera()
    {
        if (Game_admin.Delay == 0 && Game_admin.Some_mode && Talk_control.talk_mode == false && Back_camera.Count>0)
        {
            Event_interface c = new room_Change_Command(Back_camera[Back_camera.Count - 1], false, 0) ;
            Event_Invoker.AddCommand(c);
            Back_camera.RemoveAt(Back_camera.Count - 1);
            //Debug.Log(Back_camera.Count);
            mini_Game_control.SetActive(false);
            mini_Game_control.GetComponent<mini_Game_set_Script>().Tips_set.SetActive(false);

            if (Back_camera.Count == 0)
            {
                Back_obj.SetActive(false);
            }

        }

    }

    public void Back_Set()
    {
        Line_control.SetActive(false);
        wait_mode = false; 
        game_admin_static.click_delay_some_mode = 2; isHide_button(true);
        Back_set_obj.SetActive(false);
    }

    public void Set_Line()  //���_�����ˆ�
    {
        if (!Some_mode) { return; }
        if (Message_mode) { return; }
        if (Talk_control.talk_mode) { return; }
        if (Delay != 0) { return; }

        Line_control.SetActive(true);
        if (Line_control.activeSelf)
        {
            wait_mode = true;
            mode_check();
            isHide_button(false);
            Back_set_obj.SetActive(true);
        }
        else { wait_mode = false;  game_admin_static.click_delay_some_mode = 2; isHide_button(true); }

        
    }

    public void Rule_Reset()
    {

    }
    public void Rule_Tips()
    {

    }
    public void Rule_Clear()
    {

    }
    public void Rule_text()
    {

    }
    public void Rule_back()
    {

    }

    public void Black_windows_play_change_screen(string mode)
    {
        if (mode != "Title")
        {
            if (!Game_admin.Some_mode) { return; }
        }
        
        Black_windows.SetActive(true);
        Black_windows.GetComponent<Animation>().Play("Black_windows");
        Black_on = true;
        Black_mode = "Change_screen";
        Black_mode_change_screen = mode;
    }

    public void Black_mode_set()
    {
        if (Black_on)
        {

            if (Black_windows.GetComponent<Animation>().isPlaying == false) //�жϸö����Ƿ����ڲ���
            {
                Black_on = false;
                if (Black_mode == "Change_screen")
                {

                    SceneManager.LoadScene(Black_mode_change_screen);
                    Game_admin.wait_mode = false;
                    Game_admin.Stop_mode = false;
                    Talk_control.talk_mode = false;
                    mode_check();
                }
            }
        }
    }

    public void Change_Scene(string v_name)
    {
        SceneManager.LoadScene(v_name); 
    }

    public void isHide_button(bool bool_var)
    {
        button_canvas.music_button.SetActive(bool_var);
        button_canvas.line_button.SetActive(bool_var);
        button_canvas.memory_button.SetActive(bool_var);
    }

    public void Book_enter_sc()
    {
        if (!Game_admin.Some_mode) { return; }
        if (Talk_control.talk_mode) { return; }
        if (Game_admin.Delay != 0) { return; }

        Book_Script.Obj_self.SetActive(true);
        Game_admin.wait_mode = true;
        mode_check();
        gameObject.SetActive(false);
        Bag_script.Bag_script_static.Bag_obj.SetActive(false);
        if (Choose_Menu_Script.Obj_self != null)
        {
            Choose_Menu_Script.Obj_self.SetActive(false);
        }
    }
    public void Memory_enter_sc()
    {
        if (!Game_admin.Some_mode) { return; }
        if (Talk_control.talk_mode) { return; }
        if (Game_admin.Delay != 0) { return; }

        Memory_Script.Obj_self.SetActive(true);
        Game_admin.wait_mode = true;
        mode_check();
        gameObject.SetActive(false);
        Bag_script.Bag_script_static.Bag_obj.SetActive(false);
        if (Choose_Menu_Script.Obj_self != null)
        {
            Choose_Menu_Script.Obj_self.SetActive(false);
        }
    }

    public static void Next_Tri_set(List<GameObject> next_TRI,float next_time)
    {
        Event_interface c = new Empty_Command();
        Event_Invoker.AddCommand(c);
        c.next_TRI_set(next_TRI, next_time);
    }

}

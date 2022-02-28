using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class TalkSaveClass
{
    [Title("…Ë÷√∂‘ª∞")]
    public string TalkName="";
    [TextArea]
    public string TalkInfo;
    public Talk_Event_Enum Talk_Event;
    public Sprite Talk_Style;
    public AudioClip Talk_CV;

    
    public Other_Evnet_Enum Other_Evnet;

    
    [ShowIfGroup("Other_Evnet")]
    [BoxGroup("Other_Evnet/Other_Evnet_arg")]
    public string other_event_arg1="";
    [BoxGroup("Other_Evnet/Other_Evnet_arg")]
    public string other_event_arg2="";
    [BoxGroup("Other_Evnet/Other_Evnet_arg")]
    public string other_event_arg3="";
    

    public enum Talk_Event_Enum
    {
        Click=0,Next=1,End=2 , Add=3, wait=4
    }
    public enum Other_Evnet_Enum
    {
        None=0,CG_create = 1, CG_image = 2, Delay = 3, TextSpeed = 4, CG_visible=5, CG_xscale=6, Obj_position=7,
        Obj_position_add=8, Obj_depth=9, Obj_speed=10, Obj_move=11, Obj_stop=12, Obj_image=13, Obj_switch=14, Room_change=15,
        Talk_mode=16, Talk_vis=17, Obj_visible = 18
    }

 

}

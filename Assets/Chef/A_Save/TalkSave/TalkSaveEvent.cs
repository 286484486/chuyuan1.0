using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[System.Serializable]
public class TalkSaveEvent
{
    [Title("事件")]
    public Enum_Talk_Event Talk_Event;

    [ShowIf("Talk_Event", Enum_Talk_Event.设置立绘)]
    [Title("立绘")]
    public Sprite CG_set;
    [ShowIf("Talk_Event", Enum_Talk_Event.设置立绘)]
    [Title("立绘位置")]
    public Enum_set_loc CG_set_loc;
    [ShowIf("Talk_Event", Enum_Talk_Event.设置立绘)]
    [Title("是否水平翻转立绘")]
    public bool CG_set_xsc=true;

    [ShowIf("Talk_Event", Enum_Talk_Event.文字显示速度)]
    [Title("文字显示速度")]
    public float text_speed = 10;

    [ShowIf("Talk_Event", Enum_Talk_Event.对话模式)]
    [Title("立绘位置")]
    public Enum_talk_mode text_Talk_mode;

    public enum Enum_Talk_Event
    {
        设置立绘,
        文字显示速度,
        删除立绘,
        对话模式
    }

    public enum Enum_set_loc
    {
        左面,
        右面,
    }
    public enum Enum_talk_mode
    {
        模式1,
        模式2,
        模式3
    }

}

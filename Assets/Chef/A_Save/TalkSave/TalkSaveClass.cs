using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class TalkSaveClass
{
    [Title("-----------------------------------------------------设置对话------------------------------------------------------------------")]


    [Title("名字")]
    public string TalkName="";
    [Title("对话內容")]
    [TextArea]
    public string TalkInfo;
    [Title("配音")]
    public AudioClip Talk_CV;
    [Title("对话框")]
    public Sprite Talk_Style;

    [Title("事件")]
    public List<TalkSaveEvent> Talk_Event_List;






}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class TalkSaveClass
{
    [Title("-----------------------------------------------------���öԻ�------------------------------------------------------------------")]


    [Title("����")]
    public string TalkName="";
    [Title("�Ի�����")]
    [TextArea]
    public string TalkInfo;
    [Title("����")]
    public AudioClip Talk_CV;
    [Title("�Ի���")]
    public Sprite Talk_Style;

    [Title("�¼�")]
    public List<TalkSaveEvent> Talk_Event_List;






}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[System.Serializable]
public class TalkSaveEvent
{
    [Title("�¼�")]
    public Enum_Talk_Event Talk_Event;

    [ShowIf("Talk_Event", Enum_Talk_Event.��������)]
    [Title("����")]
    public Sprite CG_set;
    [ShowIf("Talk_Event", Enum_Talk_Event.��������)]
    [Title("����λ��")]
    public Enum_set_loc CG_set_loc;
    [ShowIf("Talk_Event", Enum_Talk_Event.��������)]
    [Title("�Ƿ�ˮƽ��ת����")]
    public bool CG_set_xsc=true;

    [ShowIf("Talk_Event", Enum_Talk_Event.������ʾ�ٶ�)]
    [Title("������ʾ�ٶ�")]
    public float text_speed = 10;

    [ShowIf("Talk_Event", Enum_Talk_Event.�Ի�ģʽ)]
    [Title("����λ��")]
    public Enum_talk_mode text_Talk_mode;
    [ShowIf("Talk_Event", Enum_Talk_Event.��ͷ����)]
    [Title("����ʱ��")]
    public float camera_jitter_time = 1f;
    [ShowIf("Talk_Event", Enum_Talk_Event.͢�ٶԻ�)]
    [Title("͢��ʱ��")]
    public float delay_time = 1f;
    //[ShowIf("Talk_Event", Enum_Talk_Event.�����ôζԻ�)]
    //[Title("������һ��")]

    public enum Enum_Talk_Event
    {
        ��������,
        ������ʾ�ٶ�,
        ɾ������,
        �Ի�ģʽ,
        ��ͷ����,
        ͢�ٶԻ�,
        ������һ��
    }

    public enum Enum_set_loc
    {
        ����,
        ����,
    }
    public enum Enum_talk_mode
    {
        ģʽ1,
        ģʽ2,
        ģʽ3
    }

}

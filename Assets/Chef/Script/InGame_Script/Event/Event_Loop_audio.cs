using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Lofelt.NiceVibrations;

public class Event_Loop_audio : Event_parents
{
    [Title("����ѭ���Ĵ�����")]
    public GameObject loop_obj;
    [Title("����/ֹͣѭ����Ч")]
    public AudioClip loop_se;
    [Title("����/ֹͣѭ���|�X")]
    public HapticClip loop_clip;
    [Title("ģʽ 1Ϊ���� 2Ϊ�ر� 3Ϊ����")]
    public int loop_mode;
    protected override void Event_on(string mode)
    {
        Event_interface c = new Loop_audio_Command(loop_obj, loop_se, loop_clip,loop_mode);
        Event_send(mode, c);
    }
}
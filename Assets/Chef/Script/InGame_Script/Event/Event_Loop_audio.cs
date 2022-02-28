using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Lofelt.NiceVibrations;

public class Event_Loop_audio : Event_parents
{
    [Title("用于循环的触发器")]
    public GameObject loop_obj;
    [Title("播放/停止循环音效")]
    public AudioClip loop_se;
    [Title("播放/停止循环觸覺")]
    public HapticClip loop_clip;
    [Title("模式 1为播放 2为关闭 3为开关")]
    public int loop_mode;
    protected override void Event_on(string mode)
    {
        Event_interface c = new Loop_audio_Command(loop_obj, loop_se, loop_clip,loop_mode);
        Event_send(mode, c);
    }
}
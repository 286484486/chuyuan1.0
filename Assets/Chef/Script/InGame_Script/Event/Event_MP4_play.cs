using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Video;

public class Event_MP4_play : Event_parents
{
    [Title("MP4")]
    [AssetsOnly]
    public VideoClip video_mp4;

    protected override void Event_on(string mode)
    {
        Event_interface c = new MP4_play_Command(video_mp4);
        Event_send(mode, c);
    }
}

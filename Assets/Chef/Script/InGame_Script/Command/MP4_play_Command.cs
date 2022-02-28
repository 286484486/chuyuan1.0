using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MP4_play_Command : Command_Parents, Event_interface
{
    public VideoClip video_mp4;
    public MP4_play_Command(VideoClip video_mp4)
    {
        this.video_mp4 = video_mp4;
    }


    public void Event()
    {
        GameObject MP4_obj=Instantiate(Game_admin.MP4_obj);

        VideoPlayer VP_obj = MP4_obj.GetComponent<MP4_script>().video_obj;
        VP_obj.clip = video_mp4;
        Game_admin.wait_mode = true;
        Game_admin.mode_check();
    }
}

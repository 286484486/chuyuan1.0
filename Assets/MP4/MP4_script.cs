using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MP4_script : MonoBehaviour
{
    public VideoPlayer video_obj;

    public void play_video(VideoPlayer v_video)
    {
        v_video.Play();
    }
    public void End_video()
    {
        Destroy(gameObject);
        Game_admin.wait_mode = false;
        Game_admin.mode_check();
    }
}

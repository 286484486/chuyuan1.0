using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop_audio_Command : Command_Parents, Event_interface
{
    public GameObject loop_obj;
    private AudioClip loop_se;
    public HapticClip loop_clip;
    public int loop_mode;
    public Loop_audio_Command(GameObject loop_obj, AudioClip loop_se, HapticClip loop_clip,int loop_mode)
    {
        this.loop_obj = loop_obj;
        this.loop_se = loop_se;
        this.loop_clip = loop_clip;
        this.loop_mode = loop_mode;
    }

    public void Event()
    {
        if (loop_obj == null) { Debug.Log("沒有触发器"); return; }
        if (loop_se == null) { Debug.Log("沒有音效"); return; }
        bool ok=true;
        if (loop_obj.GetComponent<AudioSource>()== null)
        {
            loop_obj.AddComponent<AudioSource>();
            loop_obj.GetComponent<AudioSource>().outputAudioMixerGroup= Game_admin.game_admin_static.AudioMixer.FindMatchingGroups("Se")[0];
        }
        if(loop_mode == 1)
        {
            loop_obj.GetComponent<AudioSource>().Stop();
            loop_obj.GetComponent<AudioSource>().clip = loop_se;
            loop_obj.GetComponent<AudioSource>().loop = true;
            loop_obj.GetComponent<AudioSource>().Play();
        }
        if (loop_mode == 2)
        {
            loop_obj.GetComponent<AudioSource>().clip = null;
            loop_obj.GetComponent<AudioSource>().loop = false;
            loop_obj.GetComponent<AudioSource>().Stop();
        }
        if (loop_mode == 3)
        {
            if (loop_obj.GetComponent<AudioSource>().clip == null)
            {
                loop_obj.GetComponent<AudioSource>().clip = loop_se;
                loop_obj.GetComponent<AudioSource>().loop = true;
                loop_obj.GetComponent<AudioSource>().Play();
            }
            else
            {
                loop_obj.GetComponent<AudioSource>().clip = null;
                loop_obj.GetComponent<AudioSource>().loop = false;
                loop_obj.GetComponent<AudioSource>().Stop();
            }
        }

        if (loop_clip != null)
        {
            if (loop_mode == 1)
            {
                HapticController.Stop();
                HapticController.Play(loop_clip);
                HapticController.Loop(true);
            }
            if (loop_mode == 2)
            {
                HapticController.Stop();
            }
            if (loop_mode == 3)
            {
                if (ok)
                {
                    HapticController.Play(loop_clip);
                    HapticController.Loop(true);
                }
                else
                {
                    HapticController.Stop();
                }
            }
        }

    }
}

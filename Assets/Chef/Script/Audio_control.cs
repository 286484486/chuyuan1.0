using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio_control : MonoBehaviour
{
    public AudioMixer Mix;
    public Slider BGM_slider;
    public Slider Se_slider;

    //public Toggle[] CV_toggle = new Toggle[4];


    public void AudioUpdata()
    {
        Mix.SetFloat("BGM", BGM_slider.value);
        Mix.SetFloat("Se", Se_slider.value);
    }
    
    /*
    public void ToggleUpdata_script(int index)
    {
        for(int i = 0; i < CV_toggle.Length; i++)
        {
            Debug.Log(i);
            CV_toggle[i].isOn = false;
        }
        CV_toggle[index].isOn = true;
        
    }
    */
    
}


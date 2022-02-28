using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CG_save_script : SerializedMonoBehaviour
{
    [Header("图片放置区域")]
    public Dictionary<string, Sprite> CG_dict = new Dictionary<string, Sprite>();
    //public string[] CG_name;
    //public Sprite[] CG_image;
    /*
    [Header("音频放置区域")]
    public Dictionary<string, AudioClip> CG_audio_dict = new Dictionary<string, AudioClip>();
    //public string[] CG_audio_name;
    //public AudioSource[] CG_audio;
    */
    [Header("物件放置区域")]
    public Dictionary<string, GameObject> OBJ_dict = new Dictionary<string, GameObject>();
    //public string[] OBJ_dict_name;
    //public GameObject[] OBJ;
    void Start()
    {
        Set_Dict();
    }

    
    void Set_Dict()
    {
     /*
        string v_name;
        for (int i = 0; i < CG_image.Length; i++)
        {
            v_name = "";
            if (i < CG_name.Length)
            {
                v_name = CG_name[i];
            }
            if (v_name != "")
            {
                CG_dict.Add(v_name, CG_image[i]);

            }
        }
        for (int i = 0; i < CG_audio.Length; i++)
        {
            v_name = "";
            if (i < CG_name.Length)
            {
                v_name = CG_audio_name[i];
            }
            if (v_name != "")
            {
                CG_audio_dict.Add(v_name, CG_audio[i]);

            }
        }
        for (int i = 0; i < OBJ.Length; i++)
        {
            v_name = "";
            if (i < OBJ_dict_name.Length)
            {
                v_name = OBJ_dict_name[i];
            }
            if (v_name != "")
            {
                OBJ_dict.Add(v_name, OBJ[i]);

            }
        }
     */
    }
    
}

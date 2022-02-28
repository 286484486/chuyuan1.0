using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_play_object_script : MonoBehaviour
{
    public AudioSource Audio_se;
    void Update()
    {
        if (!Audio_se.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}

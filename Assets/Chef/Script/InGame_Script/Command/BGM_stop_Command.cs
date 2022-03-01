using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_stop_Command : Command_Parents, Event_interface
{
    private AudioSource audioSourecs;

    public void Event()
    {
        audioSourecs = Camera.main.GetComponent<AudioSource>();
        audioSourecs.Stop();
        HapticController.Stop();
    }
}

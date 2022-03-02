using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Spine_Play_Command : Command_Parents, Event_interface
{
    public GameObject Spine_obj;
    public string Spine_anime_name;
    public bool Spine_loop;
    public Spine_Play_Command(GameObject Spine_obj,string Spine_anime_name,bool Spine_loop)
    {
        this.Spine_obj = Spine_obj;
        this.Spine_anime_name = Spine_anime_name;
        this.Spine_loop = Spine_loop;
    }
    public void Event()
    {
        if (Spine_obj == null) { return; }
        SkeletonAnimation skeletonAnimation = Spine_obj.GetComponent<SkeletonAnimation>();
        skeletonAnimation.state.SetAnimation(0, Spine_anime_name, Spine_loop);
    }
}

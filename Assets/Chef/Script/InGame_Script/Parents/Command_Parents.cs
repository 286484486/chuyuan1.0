using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Parents : MonoBehaviour
{
    public List<GameObject> next_TRI=new List<GameObject>();
    public float next_time;

    public void next_TRI_set(List<GameObject> next_TRI,float next_time)
    {
        this.next_TRI = next_TRI;
        this.next_time = next_time;
    }

    public void next_TRI_script()
    {
        for (int k = 0; k < next_TRI.Count; k++)
        {
            Event_parents[] Next_p = next_TRI[k].GetComponentsInParent<Event_parents>();
            for (int i=0;i<Next_p.Length;i++) {
                Next_p[i].next_switch = true;
                Next_p[i].time_set = next_time;
                Next_p[i].time = next_time;

            }
        }
    }

}

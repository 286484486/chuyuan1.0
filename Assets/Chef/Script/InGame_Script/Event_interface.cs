using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Event_interface
{
    void Event();
    void next_TRI_script();

    void next_TRI_set(List<GameObject> next_TRI,float next_time);
}

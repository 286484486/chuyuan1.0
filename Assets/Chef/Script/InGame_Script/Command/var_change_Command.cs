using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class var_change_Command : Command_Parents, Event_interface
{
    public GameObject obj;
    public Dictionary<string, int> var_set = new Dictionary<string, int>();
    public bool add;
    public var_change_Command(GameObject obj, Dictionary<string, int> var_set, bool add)
    {
        this.obj = obj;
        this.var_set = var_set;
        this.add = add;
    }
    
    public void Event()
    {
        if (obj == null) { return; }

        Event_Set v_event_set = obj.GetComponent<Event_Set>();
        if (v_event_set == null) { return; }

        foreach (string key in var_set.Keys)
        {
            if (!v_event_set.var_set.ContainsKey(key)) { continue; }
            if (add) 
            {
                v_event_set.var_set[key] += var_set[key];
            }
            else
            {
                v_event_set.var_set[key] = var_set[key];
            }
        }
    }
}

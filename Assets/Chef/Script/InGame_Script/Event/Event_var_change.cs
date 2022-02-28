using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_var_change : Event_parents
{
    [Title("要设置变量的触发器")]
    public GameObject obj;

    [Title("要设置的变量")]
    [DictionaryDrawerSettings(KeyLabel = "变量名", ValueLabel = "变量值")]
    public Dictionary<string, int> var_set = new Dictionary<string, int>();

    [Title("是否为增加变量,否则为设置变量")]
    public bool add;

    protected override void Event_on(string mode)
    {
        
        Event_interface c = new var_change_Command(obj,var_set,add);
        Event_send(mode, c);
    }
}

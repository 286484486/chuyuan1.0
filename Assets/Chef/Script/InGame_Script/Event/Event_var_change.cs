using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_var_change : Event_parents
{
    [Title("Ҫ���ñ����Ĵ�����")]
    public GameObject obj;

    [Title("Ҫ���õı���")]
    [DictionaryDrawerSettings(KeyLabel = "������", ValueLabel = "����ֵ")]
    public Dictionary<string, int> var_set = new Dictionary<string, int>();

    [Title("�Ƿ�Ϊ���ӱ���,����Ϊ���ñ���")]
    public bool add;

    protected override void Event_on(string mode)
    {
        
        Event_interface c = new var_change_Command(obj,var_set,add);
        Event_send(mode, c);
    }
}

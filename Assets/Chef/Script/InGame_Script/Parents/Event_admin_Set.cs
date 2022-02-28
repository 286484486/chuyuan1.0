using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class Event_admin_Set
{

    /*
    [Title("执行该触发器后立刻执行的下一个触发器")]
    [SceneObjectsOnly]
    public GameObject next_TRI;
    */
    /*
    [Title("廷时触发")]
    public float time = 0;
    */
    [Title("建立变量")]
    [Title("变量名")]
    public List<string> var_set_string = new List<string>();
    [Title("变量值")]

    public List<int> var_set = new List<int>();

    [Title("开始时触发事件")]
    public bool Start_tri;

    [Title("图层")]
    public int sort_set = 0;
}

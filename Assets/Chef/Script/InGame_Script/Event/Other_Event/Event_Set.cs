using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Set : SerializedMonoBehaviour
{
    /*
    [Title("执行该触发器后立刻执行的下一个触发器")]
    [SceneObjectsOnly]
    public GameObject next_TRI;
    [Title("廷时触发")]
    public float time = 0;
    */
    [Title("建立变量")]
    [DictionaryDrawerSettings(KeyLabel = "变量名", ValueLabel = "变量值")]
    public Dictionary<string,int> var_set=new Dictionary<string, int>();
    [Title("开始时触发事件")]
    public bool Start_tri;
    [Title("图层")]
    public int sort_set = 0;

}

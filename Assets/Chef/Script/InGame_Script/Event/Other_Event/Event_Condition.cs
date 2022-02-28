using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Condition : SerializedMonoBehaviour
{
    

    //[Header("选择对应物品时才能触发事件")]
    [Title("选择对应物品时才能触发事件")]

    [Title("对应/非对应", HorizontalLine=false)]
    public bool item_set = true;
    [Title("物品", HorizontalLine = false)]
    public ItemSaveScript item_id;

    //[Header("物品状态栏在选择时不触发事件")]
    [Title("物品状态栏在选择时不触发事件")]
    public bool is_choose;

    [Title("变量是否成立", HorizontalLine = false)]
    [Title("触发器")]
    public GameObject var_obj;
    [DictionaryDrawerSettings(KeyLabel = "变量名", ValueLabel = "变量值")]
    public Dictionary<string, int> is_var = new Dictionary<string, int>();
    [Title("条件判定")]
    public Dictionary<string, int> var_con = new Dictionary<string, int>();

    //[Header("指定物件的图片为特定图片时触发事件")]
    [Title("指定物件的图片为特定图片时触发事件")]
    //[Header("特定/非特定")]
    [Title("特定/非特定", HorizontalLine = false)]
    public bool image_set = true;

    [Title("物品", HorizontalLine = false)]
    [DictionaryDrawerSettings(KeyLabel = "物件", ValueLabel = "图片")]
    public Dictionary<GameObject,Sprite> image_pic=new Dictionary<GameObject,Sprite>();

    //[Header("指定物件是否显示时触发事件")]
    [Title("指定物件是否显示时触发事件")]
    [DictionaryDrawerSettings(KeyLabel = "物件", ValueLabel = "显示")]
    public Dictionary<GameObject, bool> image_vis = new Dictionary<GameObject, bool>();
    // Start is called before the first frame update
    void Start()
    {
        
    }


}

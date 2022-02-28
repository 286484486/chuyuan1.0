using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;



public class Event_admin_condition: SerializedMonoBehaviour
{

    [Title("设置条件")]
    public bool condition_bool;
    
    [ShowIf("condition_bool")]
    [Title("选择对应物品时才能触发事件")]
    public bool item_set_bool;
    [ShowIfGroup("@item_set_bool && condition_bool")]
    [BoxGroup("@item_set_bool && condition_bool/选择对应物品时才能触发事件")]
    [Title("对应/非对应", HorizontalLine = false)]
    public bool item_set = true;
    [ShowIfGroup("@item_set_bool && condition_bool")]
    [BoxGroup("@item_set_bool && condition_bool/选择对应物品时才能触发事件")]
    [Title("物品", HorizontalLine = false)]
    public ItemSaveScript item_id;

    [ShowIf("condition_bool")]
    [Title("物品状态栏在选择时不触发事件")]
    public bool is_choose;

    [ShowIf("condition_bool")]
    [Title("变量是否成立")]
    public bool is_var_bool;
    [ShowIfGroup("@is_var_bool && condition_bool")]
    [BoxGroup("@is_var_bool && condition_bool/变量是否成立")]
    [Title("触发器", HorizontalLine = false)]
    public GameObject var_obj;
    [ShowIfGroup("@is_var_bool && condition_bool")]
    [BoxGroup("@is_var_bool && condition_bool/变量是否成立")]
    [Title("变量名", HorizontalLine = false)]
    public List<string> is_var_string = new List<string>();
    [ShowIfGroup("@is_var_bool && condition_bool")]
    [BoxGroup("@is_var_bool && condition_bool/变量是否成立")]
    [Title("变量", HorizontalLine = false)]
    public List<int> is_var = new List<int>();
    [Title("条件判定")]
    public List<Enum_var_set> var_con_get= new List<Enum_var_set>();
    public enum Enum_var_set
    {
        等于,
        大于,
        大于等于,
        小于,
        小于等于
    }


    [ShowIf("condition_bool")]
    [Title("指定物件的图片为特定图片时触发事件")]
    public bool image_set_bool;
    [ShowIfGroup("@image_set_bool && condition_bool")]
    [BoxGroup("@image_set_bool && condition_bool/指定物件的图片为特定图片时触发事件")]
    [Title("特定/非特定", HorizontalLine = false)]
    public bool image_set = true;
    [ShowIfGroup("@image_set_bool && condition_bool")]
    [BoxGroup("@image_set_bool && condition_bool/指定物件的图片为特定图片时触发事件")]
    [Title("物件", HorizontalLine = false)]
    public List<GameObject> image_pic_obj=new List<GameObject>();
    [ShowIfGroup("@image_set_bool && condition_bool")]
    [BoxGroup("@image_set_bool && condition_bool/指定物件的图片为特定图片时触发事件")]
    [Title("图片", HorizontalLine = false)]
    public List<Sprite> image_pic=new List<Sprite>();
    /*
    [DictionaryDrawerSettings(KeyLabel = "物件", ValueLabel = "图片")]
    public Dictionary<GameObject, Sprite> image_pic;
    */

    [ShowIf("condition_bool")]
    [Title("指定物件是否显示时触发事件")]
    public bool image_vis_bool;
    [ShowIfGroup("@image_vis_bool && condition_bool")]
    [BoxGroup("@image_vis_bool && condition_bool/指定物件是否显示时触发事件")]
    [Title("物件", HorizontalLine = false)]
    public List<GameObject> image_vis_obj = new List<GameObject>();
    [ShowIfGroup("@image_vis_bool && condition_bool")]
    [BoxGroup("@image_vis_bool && condition_bool/指定物件是否显示时触发事件")]
    [Title("图片", HorizontalLine = false)]
    public List<bool> image_vis = new List<bool>();

    /*
    [DictionaryDrawerSettings(KeyLabel = "物件", ValueLabel = "显示")]
    public Dictionary<GameObject, bool> image_vis = new Dictionary<GameObject, bool>();
    */
}

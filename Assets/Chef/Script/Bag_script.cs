using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag_script : MonoBehaviour
{
    public static List<GameObject> item_List=new List<GameObject>(); //獲取物品列表
    public List<GameObject> item_List_Prefab = new List<GameObject>();
    //public Transform Grid; 
    public static GameObject Bag_select;   //物品欄選擇
    public GameObject Check_button_obj; //查看物品
    public static Bag_script Bag_script_static;
    public static GameObject Obj_self;
    public GameObject Bag_obj;
    void Start()
    {
        Obj_self = gameObject;
        Bag_script_static = gameObject.GetComponent<Bag_script>();
        item_List.Clear();
        Bag_select = new GameObject();
        

        for (int i = 0; i < item_List_Prefab.Count; i++)
        {
            /*
            item_List.Add(Instantiate(PrefabBag, Grid));
            //item_List[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-155+78*i, -280);
            */
            item_List.Add(item_List_Prefab[i]);
            item_List[i].SetActive(false);
        }
        Check_button_obj.SetActive(false);
        
        Bag_select = null;
    } 
    void Update()
    {

    }

    public static void phoneitem_Reset()   //刷新物品欄狀態
    {
        bool v_ok=false;
        for (var i = 0; i < item_List.Count; i++)
        {
            //item_List[i].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
            item_List[i].GetComponent<item_bag_Script>().item_choose.SetActive(false);
            item_List[i].GetComponent<item_bag_Script>().item_choose_name.SetActive(false);
            Bag_script_static.Check_button_obj.SetActive(false);
            if (item_List[i] == Bag_select)
            {
                item_List[i].GetComponent<item_bag_Script>().item_choose.SetActive(true);
                item_List[i].GetComponent<item_bag_Script>().item_choose_name.SetActive(true);
                v_ok = true;
            }

        }
        if (v_ok) { Bag_script_static.Check_button_obj.SetActive(true); }
        
    }

    public void item_show()
    {
        item_bag_Script sc = Bag_select.GetComponent<item_bag_Script>();
        Game_admin.Get_message_On(1,sc);
    }
}

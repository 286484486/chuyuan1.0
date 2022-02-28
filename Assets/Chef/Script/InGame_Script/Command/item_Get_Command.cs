using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_Get_Command : Command_Parents, Event_interface
{
    List<ItemSaveScript> item;
    GameObject obj;
    public item_Get_Command(List<ItemSaveScript> item,GameObject obj)
    {
        this.item = item;
        this.obj = obj;
    }

    public void Event()
    {
        //Bag_script v_gm = GameObject.Find("Bag_control").GetComponent<Bag_script>();
        //Debug.Log(Game_admin.item_List);
        int count=0;

        for (int i = 0; i < Bag_script.item_List.Count; i++)
        {
            if (Bag_script.item_List[i].activeSelf)
            {
                count++;
            }
        }

        if (count + item.Count > Bag_script.item_List.Count)
        {
            Game_admin.game_admin_static.TipsObj.GetComponent<Animation>().Stop();
            Game_admin.game_admin_static.TipsObj.transform.GetChild(0).GetComponent<Animation>().Stop();
            if (!Game_admin.game_admin_static.TipsObj.activeSelf) { Game_admin.game_admin_static.TipsObj.SetActive(true); }
            Game_admin.game_admin_static.TipsObj.GetComponentInChildren<Text>().text = "已經拿不下了...";
            Game_admin.game_admin_static.TipsObj.GetComponent<Animation>().Play("Black_windows2");
            Game_admin.game_admin_static.TipsObj.transform.GetChild(0).GetComponent<Animation>().Play("Text_windows2");
            //物品欄已滿
            return;
        }

        for(int j = 0; j < item.Count; j++)
        {
            for(int i = 0; i < Bag_script.item_List.Count; i++)
            {
                if (!Bag_script.item_List[i].activeSelf)
                {
                    Bag_script.item_List[i].SetActive(!Bag_script.item_List[i].activeSelf);
                    Bag_script.item_List[i].GetComponent<item_bag_Script>().item_image.sprite = item[j].itemImage;
                    item_bag_Script sc = Bag_script.item_List[i].GetComponent<item_bag_Script>();
                    sc.itemImage = item[j].itemImage;
                    sc.itemName = item[j].itemName;
                    sc.itemInfo = item[j].itemInfo;
                    sc.item_choose_name.GetComponentInChildren<Text>().text = sc.itemName;
                    Game_admin.Get_message_On(0,sc);
                    break;
                }
                
            }
        }
        if (obj != null)
        {
            Destroy(obj);
        }
        Bag_script.Bag_select = null;
        Bag_script.phoneitem_Reset();

    }

}

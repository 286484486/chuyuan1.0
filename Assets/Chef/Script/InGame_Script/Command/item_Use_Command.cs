using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_Use_Command : Command_Parents, Event_interface
{
    GameObject obj;
    public item_Use_Command(GameObject obj)
    {
        this.obj = obj;
    }

    public void Event()
    {
        if (obj != null)
        {
            Bag_script.Bag_select = null;
            obj.SetActive(false);
            for (int i = 0; i < Bag_script.item_List.Count; i++)
            {
                if (!Bag_script.item_List[i].activeSelf && i < Bag_script.item_List.Count-1)
                {
                    Bag_script.item_List[i].SetActive(Bag_script.item_List[i + 1].activeSelf);
                    Bag_script.item_List[i+1].SetActive(false);
                    Bag_script.item_List[i].GetComponent<item_bag_Script>().item_image.sprite = Bag_script.item_List[i+1].GetComponent<item_bag_Script>().item_image.sprite;
                    item_bag_Script sc = Bag_script.item_List[i].GetComponent<item_bag_Script>();
                    item_bag_Script sc2 = Bag_script.item_List[i+1].GetComponent<item_bag_Script>();
                    sc.itemImage = sc2.itemImage;
                    sc.itemName = sc2.itemName;
                    sc.itemInfo = sc2.itemInfo;
                    sc.item_choose_name.GetComponentInChildren<Text>().text = sc2.item_choose_name.GetComponentInChildren<Text>().text;
                }
            }
            Bag_script.phoneitem_Reset();
        }
    }
}

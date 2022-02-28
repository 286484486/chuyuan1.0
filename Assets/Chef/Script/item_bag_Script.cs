using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_bag_Script:MonoBehaviour
{
    [HideInInspector]
    public string itemName;
    [HideInInspector]
    public Sprite itemImage;
    [HideInInspector]
    public string itemInfo;
    public GameObject item_choose;
    public GameObject item_choose_name;
    public Image item_image;

    public void button_Click()
    {
        if (Game_admin.Delay == 0 && Game_admin.Some_mode && Talk_control.talk_mode == false)
        {
            Event_interface c = new item_Bag_Click_Command(gameObject);
            Event_Invoker.AddCommand(c);
        }
    }
}

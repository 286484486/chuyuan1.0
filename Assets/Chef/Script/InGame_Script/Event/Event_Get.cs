using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;


public class Event_Get : Event_parents
{
    [Title("获得物品")]
    [AssetsOnly]
    public List<ItemSaveScript> itemSaveScript=new List<ItemSaveScript>();
    protected override void Event_on(string mode)
    {
        Event_interface c = new item_Get_Command(itemSaveScript,gameObject);
        Event_send(mode,c);
    }
}

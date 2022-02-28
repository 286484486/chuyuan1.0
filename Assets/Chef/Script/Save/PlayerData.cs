using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int Title_choose_id;

    public PlayerData()
    {
        Title_choose_id = Choose_Menu_Script.Obj_self.GetComponent<Choose_Menu_Script>().choose_id;
    }
}

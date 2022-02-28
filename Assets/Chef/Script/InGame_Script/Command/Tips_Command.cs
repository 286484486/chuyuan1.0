using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips_Command : Command_Parents, Event_interface
{
    public string tips_text;
    public Tips_Command(string tips_text)
    {
        this.tips_text = tips_text;

    }


    public void Event()
    {
        Game_admin.game_admin_static.TipsObj.GetComponent<Animation>().Stop();
        Game_admin.game_admin_static.TipsObj.transform.GetChild(0).GetComponent<Animation>().Stop();
        if (!Game_admin.game_admin_static.TipsObj.activeSelf) { Game_admin.game_admin_static.TipsObj.SetActive(true); }
        Game_admin.game_admin_static.TipsObj.GetComponentInChildren<Text>().text = tips_text;
        Game_admin.game_admin_static.TipsObj.GetComponent<Animation>().Play("Black_windows2");
        Game_admin.game_admin_static.TipsObj.transform.GetChild(0).GetComponent<Animation>().Play("Text_windows2");
    }

}

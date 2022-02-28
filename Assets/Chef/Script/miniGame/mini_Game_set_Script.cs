using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mini_Game_set_Script : MonoBehaviour
{
    public GameObject reset,skil,rule,Tips_set;
    public GameObject rule_p;   //ÒŽ„tÕfÃ÷
    public int room_mini_game_index;    //Ð¡ß[‘ò¾ŽÌ–
    private int click_delay;

    void Update()
    {
        if (click_delay > 0)
        {
            click_delay -= 1;
        }

        if (click_delay == 0)
        {
            if (rule_p.activeSelf)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    rule_p.SetActive(false);
                }
            }
        }
    }

    public void rule_p_Open()
    {
        click_delay = 2;
        rule_p.SetActive(true);
    }

    public void room_mini_game_index_script()
    {
        if (room_mini_game_index == 0)
        {
            rule_p.GetComponentInChildren<Text>().text = "ÒŽ„tÕfÃ÷0";
        }
    }

}

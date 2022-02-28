using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory_Script : MonoBehaviour
{
    public static GameObject Obj_self;
    void Awake()
    {
        Obj_self = gameObject;

        gameObject.SetActive(false);
    }
    public void Back_sc()
    {

        gameObject.SetActive(false);
        Game_admin.wait_mode = false;
        Game_admin.Obj_self.SetActive(true);
        Game_admin.mode_check();
        Bag_script.Bag_script_static.Bag_obj.SetActive(true);
        if (Choose_Menu_Script.Obj_self != null)
        {
            Choose_Menu_Script.Obj_self.SetActive(true);
        }
    }
}

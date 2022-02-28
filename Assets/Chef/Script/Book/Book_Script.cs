using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book_Script : MonoBehaviour
{
    public static GameObject Obj_self;
    public GameObject Text_message_obj, life_obj, die_obj,name_obj,lock_obj;
    public Image obj_book_CG;
    public Text obj_text_show_die,obj_text_show_life,obj_text_name, obj_text_message_age, obj_text_message_brith, obj_text_message_hobby, obj_text_message_die_reason, obj_text_message_food_fav;

    private int page;
    public List<Book_Save> Book_Save = new List<Book_Save>();
    public static List<bool> Book_unlock = new List<bool>();
    void Awake()
    {
        page = 0;
        Obj_self = gameObject;

        gameObject.SetActive(false);

        for (int i = 0; i < Book_Save.Count; i++)
        {
            Book_unlock.Add(true);
        }

        if (Book_Save.Count>0) { 
            CG_change(2);
        }
    }

    // Update is called once per frame
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

    public void CG_change(int v_mode)
    {
        if (Book_Save.Count<=0) { return; }
        if (v_mode==0)
        {
            if (page >=Book_Save.Count-1)
            {
                page = 0;
            }
            else
            {
                page += 1;
            }
        }
        if (v_mode==1)
        {
            if (page <= 0)
            {
                page = Book_Save.Count - 1;
            }
            else {
                page -= 1;
            }
        }

        if (Book_unlock[page])
        {
            Text_message_obj.SetActive(true);
            life_obj.SetActive(true); 
            die_obj.SetActive(true);
            name_obj.SetActive(true);
            lock_obj.SetActive(false);
            obj_book_CG.sprite = Book_Save[page].CG_spr;
            obj_text_show_die.text = Book_Save[page].die_text;
            obj_text_show_life.text = Book_Save[page].life_text;
            obj_text_name.text = Book_Save[page].name_text;
            obj_text_message_age.text = Book_Save[page].message_text;
            obj_text_message_brith.text = Book_Save[page].birth_text;
            obj_text_message_hobby.text = Book_Save[page].hobby_text;
            obj_text_message_die_reason.text = Book_Save[page].die_reason_text;
            obj_text_message_food_fav.text = Book_Save[page].food_fav_text;
        }
        else
        {
            Text_message_obj.SetActive(false);
            life_obj.SetActive(false);
            die_obj.SetActive(false);
            name_obj.SetActive(false);
            lock_obj.SetActive(true);
            obj_book_CG.sprite = Book_Save[page].CG_spr_lock;
        }
    }

    public void CG_talk_sc()
    {
        if (Book_unlock[page])
        {

        }
    }

}

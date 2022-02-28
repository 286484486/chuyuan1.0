using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Choose_Menu_Script : MonoBehaviour
{
    public Transform choose_obj;
    public List<Transform> choose_List = new List<Transform>();
    private List<float> choose_loc = new List<float>();
    public int choose_id;
    public static GameObject Obj_self;

    // Start is called before the first frame update

    void Awake()
    {
        Obj_self = gameObject;
        for (int i = 0; i < choose_List.Count; i++)
        {
            if (choose_List[i] == null) { continue; }
            choose_List[i].GetComponentInChildren<Choose_Mask_Script>().choose_id=i;
            choose_loc.Add(choose_List[i].GetComponent<RectTransform>().anchoredPosition[1]);
           
        }

    }
    void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        choose_id=data.Title_choose_id;
        if (choose_id >= 0)
        {
            Click_choose(choose_List[choose_id].GetComponent<Choose_Story>().BGP_obj);
        }

        lock_check();
    }

    // Update is called once per frame
    void Update()
    {
        Choose_Move();
    }

    public void Click_choose(Transform obj)
    {
        
        if (!Game_admin.Some_mode) { return; }
        if (choose_obj != null)
        {
            choose_obj.GetComponent<Choose_Mask_Script>().mode = false;
        }
        choose_obj = obj;
        choose_obj.GetComponent<Choose_Mask_Script>().mode = true;
        choose_id = choose_obj.GetComponent<Choose_Mask_Script>().choose_id;
        SaveSystem.SavePlayer();
    }

    public void Click_Stroy(string screen)
    {
        if (!Game_admin.Some_mode) { return; }
        SceneManager.LoadScene(screen);
    }

    public void Choose_Move()
    {

        for(int i = 0; i < choose_List.Count; i++)
        {

            
            if (choose_List[i] == null) { continue; }
            float y_set = choose_loc[i];
            if (i > choose_id && choose_id!=-1) { y_set= choose_loc[i] - 250; }    

            RectTransform rtran = choose_List[i].GetComponent<RectTransform>();
            float rtran_y = rtran.anchoredPosition[1];

            if (rtran.anchoredPosition[1] != y_set)
            {
                float v_spd = 10 * Time.deltaTime;
                if (v_spd > 1) { v_spd = 1; }
                rtran_y += (y_set-rtran_y) * v_spd;
                choose_List[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(rtran.anchoredPosition[0], rtran_y);

                if (Mathf.Abs(rtran.anchoredPosition[1] - y_set) < 2f)
                {
                    choose_List[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(rtran.anchoredPosition[0], y_set);
                }
            }

        }
    }


    public void lock_check()
    {
        Choose_Story v_story;
        for (int i = 0; i < choose_List.Count; i++)
        {
            if (choose_List[i] == null) { continue; }
            v_story = choose_List[i].GetComponent<Choose_Story>();
            if (v_story.is_unlock)
            {
                v_story.Title_obj.GetComponent<Image>().sprite = v_story.Title_unlock;
                v_story.BGP_obj.GetComponent<Image>().sprite = v_story.BGP_unlock;
                if (v_story.is_clear)
                {
                    v_story.CG_obj.GetComponent<Image>().sprite = v_story.CG_unlock;
                }
                else { v_story.CG_obj.GetComponent<Image>().sprite = v_story.CG_lock; }
                v_story.Card_obj.GetComponent<Image>().enabled = false;
            }

            if (!v_story.is_unlock)
            {
                v_story.Title_obj.GetComponent<Image>().sprite = v_story.Title_lock;
                v_story.BGP_obj.GetComponent<Image>().sprite = v_story.BGP_lock;
                v_story.CG_obj.GetComponent<Image>().sprite = v_story.CG_lock;
                v_story.Card_obj.GetComponent<Image>().enabled = true;
            }
        }
    }

}

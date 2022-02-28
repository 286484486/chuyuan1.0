using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Qshao_control : SerializedMonoBehaviour
{
    private int delay_mode;
    private float delay;
    public int Q_mode;
    
    public bool is_lock;

    public List<GameObject> set_obj,move_obj, finish_obj,spr_obj;
    private List<float> move_obj_y=new List<float>();
    private List<float> finish_obj_y = new List<float>();
    public bool move_mode;



    // Start is called before the first frame update

    void Awake()
    {
        Q_mode = 0;
        delay = 0;
        delay_mode = 0;
        is_lock = true;
        for (int i = 0; i < move_obj.Count; i++)
        {
            move_obj[i].transform.position = set_obj[i].transform.position;
            if (i >= finish_obj_y.Count-1) { 
                finish_obj_y.Add(0);
                move_obj_y.Add(0); 
            }
            finish_obj_y[i] = finish_obj[i].transform.position.y - set_obj[i].transform.position.y;
            move_obj_y[i] = 0;
        }
        
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!is_lock) { return; }

        for (int i = 0; i < move_obj.Count; i++)
        {
            if (!move_obj[i].activeSelf) {  continue; }
            if (move_mode)
            {
                move_obj_y[i] -= (1100 / 1) * Time.deltaTime;
                if (move_obj_y[i] <= -550)
                {
                    move_obj_y[i] = -550;
                    move_mode = false;
                }
            }
            else
            {
            move_obj_y[i] += (1100 / 1) * Time.deltaTime;
            if (move_obj_y[i] >= 550)
            {
                move_obj_y[i] = 550;
                move_mode = true;
            }
            }
            move_obj[i].transform.position = new Vector2(set_obj[i].transform.position.x, set_obj[i].transform.position.y + move_obj_y[i]);
        }

        if (Input.GetMouseButtonDown(0) && Game_admin.Some_mode)
        {
            BoxCollider2D coll;
            for (int i = 0; i < move_obj.Count; i++)
            {
                if (!move_obj[i].activeSelf) { continue; }
                coll = set_obj[i].GetComponent<BoxCollider2D>();
                if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    if (Mathf.Abs(move_obj_y[i] - finish_obj_y[i]) <= 30)
                    {
                        spr_obj[i].GetComponent<SpriteRenderer>().sprite = spr_obj[i].GetComponent<Qshao_set>().finish_spr;
                        move_obj[i].SetActive(false);
                        finish_obj[i].SetActive(false);
                        Face_reset();
                    }
                }
            
            }
        }

        if (Input.GetMouseButtonUp(0))
        {


        }

    }



    public void Face_reset()
    {
        bool finish = false;

        finish = true;
        for (int i = 0; i < move_obj.Count; i++)
        {
            if (move_obj[i].activeSelf) { finish = false; break; }
        }
        if (finish)
        {
            Q_mode = 1;
            delay_mode = 0;
            delay = 2;
        }
    }
}

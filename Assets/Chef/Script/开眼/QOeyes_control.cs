using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QOeyes_control : MonoBehaviour
{
    public List<GameObject> ring_obj = new List<GameObject>();
    private int now_loc;
    private int delay_mode;
    private float delay;
    public int Q_mode;
    public static bool Lock;


    public GameObject Eye_obj;


    // Start is called before the first frame update
    void Start()
    {
        Q_mode = 0;
        delay = 0;
        delay_mode = 0;
        now_loc = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Set_Q_mode();
    }


    public void Set_Click(int v_click)
    {
        if (v_click == now_loc)
        {
            now_loc += 1;
        }
        else { 
            now_loc = 0; 
            for(int i = 0; i < ring_obj.Count; i++)
            {
                ring_obj[i].GetComponent<QOeyes_click>().locking = false;
            }
        }
        if (now_loc >= ring_obj.Count)
        {
            Lock = true;
        }
    }

    public void Set_Q_mode()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            if (Q_mode == 0)
            {
                if (delay <= 0 && delay_mode == 0)
                {
                    now_loc = 0;
                    delay = 1;
                    delay_mode = 1;
                }
            }
        }

    }
}

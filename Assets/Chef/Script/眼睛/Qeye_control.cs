using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Sirenix.OdinInspector;

public class Qeye_control : MonoBehaviour
{
    public List<bool> Watch_dir = new List<bool>();
    private int now_loc;
    private int delay_mode;
    private float delay;
    public int Q_mode;
    public static bool Lock;

    public Sprite Spr_Left, Spr_normal, Spr_Right;

    public GameObject Eye_obj;

    private List<bool> Set_dir = new List<bool>();

    public SkeletonAnimation skeletonAnimation;
    // Start is called before the first frame update


    [Title("完成后立刻执行的触发器")]
    [SceneObjectsOnly]
    public List<GameObject> next_TRI = new List<GameObject>();
    [Title("下一个触发器廷时触发")]
    public float next_time = 0;
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

    private void OnMouseUpAsButton()
    {
        if (!Lock && Q_mode==0)
        {
            //skeletonAnimation.state.SetAnimation(0, "zhizhu-pa", false);
            delay = 1;
            Lock = true;
        }
    }

    public void Set_Click(bool v_click)
    {
        if (!v_click) { skeletonAnimation.state.SetAnimation(0, "左灯", false); }
        else { skeletonAnimation.state.SetAnimation(0, "右灯", false); }
        bool v_clear=false;
        Set_dir.Add(v_click);
        while (Set_dir.Count > Watch_dir.Count)
        {
            Set_dir.RemoveAt(0);
        }
        //if (Set_dir.Count == Watch_dir.Count)
        //{
            v_clear = true;
            for (int i = 0; i < Set_dir.Count; i++)
            {
                if (Set_dir[i]!=Watch_dir[i])
                {
                    v_clear = false;
                    skeletonAnimation.state.SetAnimation(0, "3mengsuozhengdong", false);
                    delay = 1;
                    delay_mode = 6;
                    Lock = true;
                break;
                }
            }
        //}
        if(Set_dir.Count != Watch_dir.Count) { v_clear = false; }
        if (v_clear)
        {
            Lock = true;
            delay = 1;
            delay_mode = 4;
            
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
                    Set_dir.Clear();
                }
                if (delay <= 0 && delay_mode == 1)
                {
                 
                     delay = 1;
                    delay_mode = 2;
                    if (!Watch_dir[now_loc])
                    {
                        skeletonAnimation.state.SetAnimation(0, "2眼睛-左", false);
                    }
                    else
                    {
                        skeletonAnimation.state.SetAnimation(0, "2眼睛-右", false);
                    }


                }
                if (delay <= 0 && delay_mode == 2)
                {
                    
                    if (now_loc+1>=Watch_dir.Count) {
                        delay = 0;
                        delay_mode = 0;
                        Lock = false;
                    }
                    else {
                        now_loc += 1;
                        delay = 0.5f;
                        delay_mode = 1;
                    }
                  
                }
                if(delay<=0 && delay_mode == 4)
                {
                    delay = 1;
                    delay_mode = 5;
                    skeletonAnimation.state.SetAnimation(0, "5pa", false);

                }
                if(delay<=0 && delay_mode == 6)
                {
                    delay = 0;
                    delay_mode = 0;
                    Set_dir.Clear();
                    Lock = false;
                }

                if (delay <= 0 && delay_mode == 5)
                {
                    Finish_Tri();

                }
            }
        }
    
    }

    public void Finish_Tri()
    {
        Game_admin.Next_Tri_set(next_TRI, next_time);
    }

}

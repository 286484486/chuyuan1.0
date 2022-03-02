using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Video;
public class Event_admin : SerializedMonoBehaviour
{
    
    [Title("设置事件")]
    public List<Event_admin_Class> Event_get;


    [Title("基础设置")]
    public Event_admin_Set Event_base;

    //private List<Event_Condition> v_Condetion=new List<Event_Condition>();

    void Awake()
    {
        Event_Set Event_Script = gameObject.AddComponent<Event_Set>();


        for (int j = 0; j < Event_base.var_set_string.Count; j++)
        {
            Event_Script.var_set.Add(Event_base.var_set_string[j], Event_base.var_set[j]);
        }

        Event_Script.Start_tri = Event_base.Start_tri;
        Event_Script.sort_set = Event_base.sort_set;

        

        for (int i = 0; i < Event_get.Count; i++)
        {
            Event_parents Event_p = null;

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.获取物件)
            {
                
               var Script = gameObject.AddComponent<Event_Get>();
                Script.bag_check = 0;
                for (int j = 0; j < Event_get[i].itemSaveScript.Count; j++)
                {
                    Script.itemSaveScript.Add(Event_get[i].itemSaveScript[j]);
                    Script.bag_check++;
                }
                for (int j = 0; j < i; j++)
                {
                    if (Event_get[j].Event_get == Event_admin_Class.Enum_Script.使用物品)
                    {
                        Script.bag_check--;
                    }
                }
                Event_p = Script;
            }
            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.开关)
            {
                var Script = gameObject.AddComponent<Event_switch>();
                for (int j = 0; j < Event_get[i].Switch_obj.Count; j++)
                {
                    Script.obj.Add(Event_get[i].Switch_obj[j]);
                }
                Event_p = Script;
            }

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.显示_隐藏)
            {
                var Script = gameObject.AddComponent<Event_visible>();
                for (int j = 0; j < Event_get[i].visible_obj.Count; j++)
                {
                    if (Event_get[i].visible_obj[j] != null)
                    {
                        Script.obj.Add(Event_get[i].visible_obj[j], Event_get[i].visible_obj_bool[j]);
                    }
                }
                Event_p = Script;
            }

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.切换房间)
            {
                var Script = gameObject.AddComponent<room_Change_script>();
                Script.room_index = Event_get[i].room_index;
                Script.room_back = Event_get[i].room_back;
                Script.room_mini_game = Event_get[i].room_mini_game;
                Script.room_mini_game_index = Event_get[i].room_mini_game_index;

                Event_p = Script;
            }

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.使用物品)
            {
                var Script = gameObject.AddComponent<Event_use>();

                Event_p = Script;
            }

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.对话)
            {
                var Script = gameObject.AddComponent<Event_Talk>();
                Script.key = Event_get[i].Talk_key;

                Event_p = Script;
            }

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.删除)
            {
                var Script = gameObject.AddComponent<Event_Destroy>();
                Script.obj = Event_get[i].Destroy_obj;

                Event_p = Script;
            }

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.更改图片)
            {
                var Script = gameObject.AddComponent<Event_image_change>();
                for (int j = 0; j < Event_get[i].image_change_obj.Count; j++)
                {
                    Script.obj.Add(Event_get[i].image_change_obj[j], Event_get[i].image_change_pic[j]);
                }
                Event_p = Script;
            }

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.设置变量)
            {
                var Script = gameObject.AddComponent<Event_var_change>();

                Script.obj = Event_get[i].var_set_obj;

                for (int j = 0; j < Event_get[i].var_set_string.Count; j++)
                {
                    Script.var_set.Add(Event_get[i].var_set_string[j], Event_get[i].var_set[j]);
                }

                Script.add = Event_get[i].var_set_add;

                Event_p = Script;
            }

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.播放动画)
            {
                var Script = gameObject.AddComponent<Event_Animation>(); 

                for (int j = 0; j < Event_get[i].Event_animation_obj.Count; j++)
                {
                    Script.obj.Add(Event_get[i].Event_animation_obj[j], Event_get[i].Event_animation_string_id[j]);
                }

                Script.anime_mode = Event_get[i].anime_mode;

                Event_p = Script;
            }

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.缩放摄像头)
            {
                var Script = gameObject.AddComponent<Event_Camera_size>();

                Script.obj = Event_get[i].Camera_obj;
                Script.is_add = Event_get[i].Camera_is_add;
                Script.size = Event_get[i].Camera_size;
                Script.Obj_speed = Event_get[i].Camera_Obj_speed;
                Script.size_mode = Event_get[i].Camera_size_mode;

                Script.is_sizeport = Event_get[i].is_sizeport;
                Script.is_sizeport_x = Event_get[i].is_sizeport_x;
                Script.is_sizeport_y = Event_get[i].is_sizeport_y;

                Event_p = Script;
            }

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.移动物件)
            {
                var Script = gameObject.AddComponent<Event_move>();

                Script.obj = Event_get[i].Move_obj;
                Script.is_add = Event_get[i].Move_is_add;
                Script.pos_x = Event_get[i].Move_pos_x;
                Script.pos_y = Event_get[i].Move_pos_y;
                Script.Obj_speed = Event_get[i].Move_Obj_speed;
                Script.Obj_speed_down = Event_get[i].Move_Obj_speed_down;

                Event_p = Script;
            }

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.播放音效)
            {
                var Script = gameObject.AddComponent<Event_Audio_play>();

                Script.auidio_se = Event_get[i].auidio_se;
                Script.clip = Event_get[i].audio_clip;
                Script.auidio_once = Event_get[i].auidio_once;

                Event_p = Script;
            }

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.播放背景音)
            {
                var Script = gameObject.AddComponent<Event_BGM_play>();

                Script.audio_BGM = Event_get[i].audio_BGM;
                Script.clip = Event_get[i].audio_BGM_clip;

                Event_p = Script;
            }
            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.关闭背景音)
            {
                var Script = gameObject.AddComponent<Event_BGM_stop>();


                Event_p = Script;
            }

            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.切换场景)
            {
                var Script = gameObject.AddComponent<Event_Scenes_change>();

                Script.name = Event_get[i].scenes_change;

                Event_p = Script;
            }
            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.播放MP4)
            {
                var Script = gameObject.AddComponent<Event_MP4_play>();

                Script.video_mp4 = Event_get[i].video_mp4;

                Event_p = Script;
            }
            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.循环音效)
            {
                var Script = gameObject.AddComponent<Event_Loop_audio>();

                Script.loop_obj = Event_get[i].loop_obj;
                Script.loop_se = Event_get[i].loop_se;
                Script.loop_clip = Event_get[i].loop_clip;
                Script.loop_mode = Event_get[i].loop_mode;

                Event_p = Script;
            }
            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.展现提示框)
            {
                var Script = gameObject.AddComponent<Event_Tips>();

                Script.tips_text = Event_get[i].tips_text;

                Event_p = Script;
            }
            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.空事件)
            {
                var Script = gameObject.AddComponent<Event_Empty>();

                Event_p = Script;
            }
            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.返回上一个房间)
            {
                var Script = gameObject.AddComponent<Event_room_back>();

                Event_p = Script;
            }
            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.镜头抖动)
            {
                var Script = gameObject.AddComponent<Event_Camera_jitter>();

                Script.camera_jitter_time = Event_get[i].camera_jitter_time;

                Event_p = Script;
            }
            if (Event_get[i].Event_get == Event_admin_Class.Enum_Script.播放Spine动画)
            {
                var Script = gameObject.AddComponent<Event_Spine_Play>();

                Script.Spine_obj = Event_get[i].Spine_obj;
                Script.Spine_anime_name = Event_get[i].Spine_anime_name;
                Script.Spine_loop = Event_get[i].Spine_loop;

                Event_p = Script;
            }


            if (Event_p != null)
            {
                if (Event_get[i].Condition_on_bool)
                {
                    /*
                    if (Event_get[i].Condition_index.Count == 0)
                    {
                        for (int j = 0; j < v_Condetion.Count; j++)
                        {
                            Event_p.E_condition.Add(v_Condetion[j]);
                        }
                    }
                    else
                    {
                        
                        for(int j=0;j< Event_get[i].Condition_index.Count; j++)
                        {
                            if (Event_get[i].Condition_index[j] >= 0 && Event_get[i].Condition_index[j] < v_Condetion.Count)
                            {
                                Event_p.E_condition.Add(v_Condetion[Event_get[i].Condition_index[j]]);
                            }
                        }
                        
                    }
                    */
                    for (int k = 0; k < Event_get[i].Condition_index.Count; k++)
                    {
                        var sc = Event_get[i].Condition_index[k];
                        if (sc != null)
                        {
                            var Script = gameObject.AddComponent<Event_Condition>();
                            if (sc.item_set_bool)
                            {
                                Script.item_set = sc.item_set;
                                Script.item_id = sc.item_id;
                            }

                            Script.is_choose = sc.is_choose;

                            if (sc.is_var_bool)
                            {
                                Script.var_obj = sc.var_obj;
                                for (int j = 0; j < sc.is_var_string.Count; j++)
                                {
                                    Script.is_var.Add(sc.is_var_string[j], sc.is_var[j]);
                                    if (sc.var_con_get[j] == Event_admin_condition.Enum_var_set.等于)
                                    {
                                        Script.var_con.Add(sc.is_var_string[j], 0);
                                    }
                                    if (sc.var_con_get[j] == Event_admin_condition.Enum_var_set.大于)
                                    {
                                        Script.var_con.Add(sc.is_var_string[j], 1);
                                    }
                                    if (sc.var_con_get[j] == Event_admin_condition.Enum_var_set.大于等于)
                                    {
                                        Script.var_con.Add(sc.is_var_string[j], 2);
                                    }
                                    if (sc.var_con_get[j] == Event_admin_condition.Enum_var_set.小于)
                                    {
                                        Script.var_con.Add(sc.is_var_string[j], 3);
                                    }
                                    if (sc.var_con_get[j] == Event_admin_condition.Enum_var_set.小于等于)
                                    {
                                        Script.var_con.Add(sc.is_var_string[j], 4);
                                    }
                                }
                            }

                            if (sc.image_set_bool)
                            {
                                Script.image_set = sc.image_set;
                                for (int j = 0; j < sc.image_pic_obj.Count; j++)
                                {
                                    Script.image_pic.Add(sc.image_pic_obj[j], sc.image_pic[j]);
                                }
                            }

                            if (sc.image_vis_bool)
                            {
                                for (int j = 0; j < sc.image_vis_obj.Count; j++)
                                {
                                    Script.image_vis.Add(sc.image_vis_obj[j], sc.image_vis[j]);
                                }
                            }

                            Event_p.E_condition.Add(Script);

                            Destroy(Event_get[i].Condition_index[k].gameObject);
                        }

                        
                    }
                }
            }

            if (Event_p != null)
            {
                Event_p.next_TRI_L = Event_get[i].next_TRI;
                Event_p.next_time = Event_get[i].next_time;

            }


        }


        Destroy(gameObject.GetComponent<Event_admin>());

    }




}

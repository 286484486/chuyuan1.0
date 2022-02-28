using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Video;
using Lofelt.NiceVibrations;

[System.Serializable]
public class Event_admin_Class
{
    [Title("...................................................................分隔.........................................................................")]
    [Title("设置事件")]
    public Enum_Script Event_get;
    [ShowIf("Event_get", Enum_Script.获取物件)]
    [Title("获得物品")]
    [AssetsOnly]
    public List<ItemSaveScript> itemSaveScript;

    [ShowIf("Event_get", Enum_Script.开关)]
    [Title("物件隐藏时显示,显示时隐藏")]
    [SceneObjectsOnly]
    public List<GameObject> Switch_obj;

    [ShowIf("Event_get", Enum_Script.显示_隐藏)]
    [Title("设置的物件隐藏或显示")]
    [Title("物件")]
    [SceneObjectsOnly]
    public List<GameObject> visible_obj = new List<GameObject>();
    [ShowIf("Event_get", Enum_Script.显示_隐藏)]
    [Title("显示")]
    public List<bool> visible_obj_bool = new List<bool>();

    [ShowIf("Event_get", Enum_Script.切换房间)]
    [Title("场景id")]
    [SceneObjectsOnly]
    public GameObject room_index;
    // Start is called before the first frame update
    [ShowIf("Event_get", Enum_Script.切换房间)]
    [Title("设置返回键返回的场景id")]
    [SceneObjectsOnly]
    public GameObject room_back;
    [ShowIf("Event_get", Enum_Script.切换房间)]
    [Title("是否开启小游戏按钮")]
    public bool room_mini_game;
    [ShowIf("Event_get", Enum_Script.切换房间)]
    [Title("小游戏编号")]
    public int room_mini_game_index;

    [ShowIf("Event_get", Enum_Script.对话)]
    [Title("对话")]
    public TalkSaveScript Talk_key;

    [ShowIf("Event_get", Enum_Script.删除)]
    [Title("要删除的物件")]
    [SceneObjectsOnly]
    public List<GameObject> Destroy_obj;

    [ShowIf("Event_get", Enum_Script.更改图片)]
    [Title("要更改的物件")]
    public List<GameObject> image_change_obj = new List<GameObject>();
    [ShowIf("Event_get", Enum_Script.更改图片)]
    [Title("图片")]
    public List<Sprite> image_change_pic = new List<Sprite>();

    [ShowIf("Event_get", Enum_Script.设置变量)]
    [Title("要设置变量的触发器")]
    public GameObject var_set_obj;
    [ShowIf("Event_get", Enum_Script.设置变量)]
    [Title("要设置的变量名")]
    public List<string> var_set_string = new List<string>();
    [ShowIf("Event_get", Enum_Script.设置变量)]
    [Title("要设置的变量值")]
    public List<int> var_set = new List<int>();
    [ShowIf("Event_get", Enum_Script.设置变量)]
    [Title("是否为增加变量,否则为设置变量")]
    public bool var_set_add;

    [ShowIf("Event_get", Enum_Script.播放动画)]
    [Title("物件")]
    [SceneObjectsOnly]
    public List<GameObject> Event_animation_obj = new List<GameObject>();
    [ShowIf("Event_get", Enum_Script.播放动画)]
    [Title("动画id")]
    public List<string> Event_animation_string_id = new List<string>();
    [ShowIf("Event_get", Enum_Script.播放动画)]
    [Title("动画模式参数")]
    public string anime_mode;

    [ShowIf("Event_get", Enum_Script.缩放摄像头)]
    [Title("要缩放的摄像头")]
    [SceneObjectsOnly]
    public GameObject Camera_obj;
    [ShowIf("Event_get", Enum_Script.缩放摄像头)]
    [Title("是否相对大小")]
    public bool Camera_is_add;
    [ShowIf("Event_get", Enum_Script.缩放摄像头)]
    [Title("大小")]
    public float Camera_size;
    [ShowIf("Event_get", Enum_Script.缩放摄像头)]
    [Title("缩放速度")]
    public float Camera_Obj_speed = 100;
    [ShowIf("Event_get", Enum_Script.缩放摄像头)]
    [Title("缩放中心点")]
    public bool is_sizeport;
    [ShowIf("@is_sizeport && Event_get == Enum_Script.缩放摄像头")]
    [ShowIfGroup("@is_sizeport")]
    [BoxGroup("@is_sizeport/缩放中心点")]
    [Title("缩放中心点x")]
    public float is_sizeport_x;
    [ShowIf("@is_sizeport && Event_get == Enum_Script.缩放摄像头")]
    [ShowIfGroup("@is_sizeport")]
    [BoxGroup("@is_sizeport/缩放中心点")]
    [Title("缩放中心点y")]
    public float is_sizeport_y;
    [ShowIf("Event_get", Enum_Script.缩放摄像头)]
    [Title("缩放模式")]
    public bool Camera_size_mode;

    [ShowIf("Event_get", Enum_Script.移动物件)]
    [Title("要移动的物件")]
    [SceneObjectsOnly]
    public GameObject Move_obj;
    [ShowIf("Event_get", Enum_Script.移动物件)]
    [Title("相对坐标")]
    public bool Move_is_add;
    [ShowIf("Event_get", Enum_Script.移动物件)]
    [Title("坐标x")]
    public float Move_pos_x;
    [ShowIf("Event_get", Enum_Script.移动物件)]
    [Title("坐标y")]
    public float Move_pos_y;
    [ShowIf("Event_get", Enum_Script.移动物件)]
    [Title("移动速度")]
    public float Move_Obj_speed = 100;
    [ShowIf("Event_get", Enum_Script.移动物件)]
    [Title("速度衰减")]
    public float Move_Obj_speed_down = 0;
    [ShowIf("Event_get", Enum_Script.播放音效)]
    [Title("播放音效")]
    public AudioClip auidio_se;
    [ShowIf("Event_get", Enum_Script.播放音效)]
    [Title("播放觸覺")]
    public HapticClip audio_clip;
    [ShowIf("Event_get", Enum_Script.播放音效)]
    [Title("音效只使用一次")]
    public bool auidio_once;
    [ShowIf("Event_get", Enum_Script.播放背景音)]
    [Title("播放背景音")]
    public AudioClip audio_BGM;
    [ShowIf("Event_get", Enum_Script.播放背景音)]
    [Title("播放觸覺")]
    public HapticClip audio_BGM_clip;

    [ShowIf("Event_get", Enum_Script.切换场景)]
    [Title("场景名")]
    [SceneObjectsOnly]
    public string scenes_change;

    [ShowIf("Event_get", Enum_Script.播放MP4)]
    [Title("MP4")]
    [AssetsOnly]
    public VideoClip video_mp4;
    [ShowIf("Event_get", Enum_Script.循环音效)]
    [Title("用于循环的触发器")]
    public GameObject loop_obj;
    [ShowIf("Event_get", Enum_Script.循环音效)]
    [Title("音效")]
    public AudioClip loop_se;
    [ShowIf("Event_get", Enum_Script.循环音效)]
    [Title("觸覺")]
    public HapticClip loop_clip;
    [ShowIf("Event_get", Enum_Script.循环音效)]
    [Title("模式 1为播放 2为关闭 3为开关")]
    public int loop_mode=3;

    [ShowIf("Event_get", Enum_Script.展现提示框)]
    [Title("文本")]
    [TextArea]
    public string tips_text;

    [ShowIf("Event_get", Enum_Script.空事件)]
    [Title("直接触发不发生任何事的事件,可用於Next_TRI上")]
    [ShowIf("Event_get", Enum_Script.返回上一个房间)]
    [Title("返回上一个房间")]

    [Title("条件触发")]
    public bool Condition_on_bool = true;
    [ShowIf("Condition_on_bool")]
    [Title("条件触发器")]
    public List<Event_admin_condition> Condition_index=new List<Event_admin_condition>();

    [Title("下一个触发器")]
    public bool next_on_bool;
    [ShowIf("next_on_bool")]
    [Title("执行该触发器后立刻执行的下一个触发器")]
    [SceneObjectsOnly]
    public List<GameObject> next_TRI=new List<GameObject>();
    [ShowIf("next_on_bool")]
    [Title("下一个触发器廷时触发")]
    public float next_time = 0;

    public enum Enum_Script
    {
        获取物件,
        开关,
        显示_隐藏,
        切换房间,
        使用物品,
        对话,
        删除,
        更改图片,
        设置变量,
        播放动画,
        缩放摄像头,
        移动物件,
        播放音效,
        播放背景音,
        切换场景,
        播放MP4,
        循环音效,
        展现提示框,
        空事件,
        返回上一个房间

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Video;
using Lofelt.NiceVibrations;

[System.Serializable]
public class Event_admin_Class
{
    [Title("...................................................................�ָ�.........................................................................")]
    [Title("�����¼�")]
    public Enum_Script Event_get;
    [ShowIf("Event_get", Enum_Script.��ȡ���)]
    [Title("�����Ʒ")]
    [AssetsOnly]
    public List<ItemSaveScript> itemSaveScript;

    [ShowIf("Event_get", Enum_Script.����)]
    [Title("�������ʱ��ʾ,��ʾʱ����")]
    [SceneObjectsOnly]
    public List<GameObject> Switch_obj;

    [ShowIf("Event_get", Enum_Script.��ʾ_����)]
    [Title("���õ�������ػ���ʾ")]
    [Title("���")]
    [SceneObjectsOnly]
    public List<GameObject> visible_obj = new List<GameObject>();
    [ShowIf("Event_get", Enum_Script.��ʾ_����)]
    [Title("��ʾ")]
    public List<bool> visible_obj_bool = new List<bool>();

    [ShowIf("Event_get", Enum_Script.�л�����)]
    [Title("����id")]
    [SceneObjectsOnly]
    public GameObject room_index;
    // Start is called before the first frame update
    [ShowIf("Event_get", Enum_Script.�л�����)]
    [Title("���÷��ؼ����صĳ���id")]
    [SceneObjectsOnly]
    public GameObject room_back;
    [ShowIf("Event_get", Enum_Script.�л�����)]
    [Title("�Ƿ���С��Ϸ��ť")]
    public bool room_mini_game;
    [ShowIf("Event_get", Enum_Script.�л�����)]
    [Title("С��Ϸ���")]
    public int room_mini_game_index;

    [ShowIf("Event_get", Enum_Script.�Ի�)]
    [Title("�Ի�")]
    public TalkSaveScript Talk_key;

    [ShowIf("Event_get", Enum_Script.ɾ��)]
    [Title("Ҫɾ�������")]
    [SceneObjectsOnly]
    public List<GameObject> Destroy_obj;

    [ShowIf("Event_get", Enum_Script.����ͼƬ)]
    [Title("Ҫ���ĵ����")]
    public List<GameObject> image_change_obj = new List<GameObject>();
    [ShowIf("Event_get", Enum_Script.����ͼƬ)]
    [Title("ͼƬ")]
    public List<Sprite> image_change_pic = new List<Sprite>();

    [ShowIf("Event_get", Enum_Script.���ñ���)]
    [Title("Ҫ���ñ����Ĵ�����")]
    public GameObject var_set_obj;
    [ShowIf("Event_get", Enum_Script.���ñ���)]
    [Title("Ҫ���õı�����")]
    public List<string> var_set_string = new List<string>();
    [ShowIf("Event_get", Enum_Script.���ñ���)]
    [Title("Ҫ���õı���ֵ")]
    public List<int> var_set = new List<int>();
    [ShowIf("Event_get", Enum_Script.���ñ���)]
    [Title("�Ƿ�Ϊ���ӱ���,����Ϊ���ñ���")]
    public bool var_set_add;

    [ShowIf("Event_get", Enum_Script.���Ŷ���)]
    [Title("���")]
    [SceneObjectsOnly]
    public List<GameObject> Event_animation_obj = new List<GameObject>();
    [ShowIf("Event_get", Enum_Script.���Ŷ���)]
    [Title("����id")]
    public List<string> Event_animation_string_id = new List<string>();
    [ShowIf("Event_get", Enum_Script.���Ŷ���)]
    [Title("����ģʽ����")]
    public string anime_mode;

    [ShowIf("Event_get", Enum_Script.��������ͷ)]
    [Title("Ҫ���ŵ�����ͷ")]
    [SceneObjectsOnly]
    public GameObject Camera_obj;
    [ShowIf("Event_get", Enum_Script.��������ͷ)]
    [Title("�Ƿ���Դ�С")]
    public bool Camera_is_add;
    [ShowIf("Event_get", Enum_Script.��������ͷ)]
    [Title("��С")]
    public float Camera_size;
    [ShowIf("Event_get", Enum_Script.��������ͷ)]
    [Title("�����ٶ�")]
    public float Camera_Obj_speed = 100;
    [ShowIf("Event_get", Enum_Script.��������ͷ)]
    [Title("�������ĵ�")]
    public bool is_sizeport;
    [ShowIf("@is_sizeport && Event_get == Enum_Script.��������ͷ")]
    [ShowIfGroup("@is_sizeport")]
    [BoxGroup("@is_sizeport/�������ĵ�")]
    [Title("�������ĵ�x")]
    public float is_sizeport_x;
    [ShowIf("@is_sizeport && Event_get == Enum_Script.��������ͷ")]
    [ShowIfGroup("@is_sizeport")]
    [BoxGroup("@is_sizeport/�������ĵ�")]
    [Title("�������ĵ�y")]
    public float is_sizeport_y;
    [ShowIf("Event_get", Enum_Script.��������ͷ)]
    [Title("����ģʽ")]
    public bool Camera_size_mode;

    [ShowIf("Event_get", Enum_Script.�ƶ����)]
    [Title("Ҫ�ƶ������")]
    [SceneObjectsOnly]
    public GameObject Move_obj;
    [ShowIf("Event_get", Enum_Script.�ƶ����)]
    [Title("�������")]
    public bool Move_is_add;
    [ShowIf("Event_get", Enum_Script.�ƶ����)]
    [Title("����x")]
    public float Move_pos_x;
    [ShowIf("Event_get", Enum_Script.�ƶ����)]
    [Title("����y")]
    public float Move_pos_y;
    [ShowIf("Event_get", Enum_Script.�ƶ����)]
    [Title("�ƶ��ٶ�")]
    public float Move_Obj_speed = 100;
    [ShowIf("Event_get", Enum_Script.�ƶ����)]
    [Title("�ٶ�˥��")]
    public float Move_Obj_speed_down = 0;
    [ShowIf("Event_get", Enum_Script.������Ч)]
    [Title("������Ч")]
    public AudioClip auidio_se;
    [ShowIf("Event_get", Enum_Script.������Ч)]
    [Title("�����|�X")]
    public HapticClip audio_clip;
    [ShowIf("Event_get", Enum_Script.������Ч)]
    [Title("��Чֻʹ��һ��")]
    public bool auidio_once;
    [ShowIf("Event_get", Enum_Script.���ű�����)]
    [Title("���ű�����")]
    public AudioClip audio_BGM;
    [ShowIf("Event_get", Enum_Script.���ű�����)]
    [Title("�����|�X")]
    public HapticClip audio_BGM_clip;

    [ShowIf("Event_get", Enum_Script.�л�����)]
    [Title("������")]
    [SceneObjectsOnly]
    public string scenes_change;

    [ShowIf("Event_get", Enum_Script.����MP4)]
    [Title("MP4")]
    [AssetsOnly]
    public VideoClip video_mp4;
    [ShowIf("Event_get", Enum_Script.ѭ����Ч)]
    [Title("����ѭ���Ĵ�����")]
    public GameObject loop_obj;
    [ShowIf("Event_get", Enum_Script.ѭ����Ч)]
    [Title("��Ч")]
    public AudioClip loop_se;
    [ShowIf("Event_get", Enum_Script.ѭ����Ч)]
    [Title("�|�X")]
    public HapticClip loop_clip;
    [ShowIf("Event_get", Enum_Script.ѭ����Ч)]
    [Title("ģʽ 1Ϊ���� 2Ϊ�ر� 3Ϊ����")]
    public int loop_mode=3;

    [ShowIf("Event_get", Enum_Script.չ����ʾ��)]
    [Title("�ı�")]
    [TextArea]
    public string tips_text;

    [ShowIf("Event_get", Enum_Script.���¼�)]
    [Title("ֱ�Ӵ����������κ��µ��¼�,�����Next_TRI��")]
    [ShowIf("Event_get", Enum_Script.������һ������)]
    [Title("������һ������")]

    [Title("��������")]
    public bool Condition_on_bool = true;
    [ShowIf("Condition_on_bool")]
    [Title("����������")]
    public List<Event_admin_condition> Condition_index=new List<Event_admin_condition>();

    [Title("��һ��������")]
    public bool next_on_bool;
    [ShowIf("next_on_bool")]
    [Title("ִ�иô�����������ִ�е���һ��������")]
    [SceneObjectsOnly]
    public List<GameObject> next_TRI=new List<GameObject>();
    [ShowIf("next_on_bool")]
    [Title("��һ��������͢ʱ����")]
    public float next_time = 0;

    public enum Enum_Script
    {
        ��ȡ���,
        ����,
        ��ʾ_����,
        �л�����,
        ʹ����Ʒ,
        �Ի�,
        ɾ��,
        ����ͼƬ,
        ���ñ���,
        ���Ŷ���,
        ��������ͷ,
        �ƶ����,
        ������Ч,
        ���ű�����,
        �л�����,
        ����MP4,
        ѭ����Ч,
        չ����ʾ��,
        ���¼�,
        ������һ������

    }



}

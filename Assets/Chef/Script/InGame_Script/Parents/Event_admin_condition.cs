using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;



public class Event_admin_condition: SerializedMonoBehaviour
{

    [Title("��������")]
    public bool condition_bool;
    
    [ShowIf("condition_bool")]
    [Title("ѡ���Ӧ��Ʒʱ���ܴ����¼�")]
    public bool item_set_bool;
    [ShowIfGroup("@item_set_bool && condition_bool")]
    [BoxGroup("@item_set_bool && condition_bool/ѡ���Ӧ��Ʒʱ���ܴ����¼�")]
    [Title("��Ӧ/�Ƕ�Ӧ", HorizontalLine = false)]
    public bool item_set = true;
    [ShowIfGroup("@item_set_bool && condition_bool")]
    [BoxGroup("@item_set_bool && condition_bool/ѡ���Ӧ��Ʒʱ���ܴ����¼�")]
    [Title("��Ʒ", HorizontalLine = false)]
    public ItemSaveScript item_id;

    [ShowIf("condition_bool")]
    [Title("��Ʒ״̬����ѡ��ʱ�������¼�")]
    public bool is_choose;

    [ShowIf("condition_bool")]
    [Title("�����Ƿ����")]
    public bool is_var_bool;
    [ShowIfGroup("@is_var_bool && condition_bool")]
    [BoxGroup("@is_var_bool && condition_bool/�����Ƿ����")]
    [Title("������", HorizontalLine = false)]
    public GameObject var_obj;
    [ShowIfGroup("@is_var_bool && condition_bool")]
    [BoxGroup("@is_var_bool && condition_bool/�����Ƿ����")]
    [Title("������", HorizontalLine = false)]
    public List<string> is_var_string = new List<string>();
    [ShowIfGroup("@is_var_bool && condition_bool")]
    [BoxGroup("@is_var_bool && condition_bool/�����Ƿ����")]
    [Title("����", HorizontalLine = false)]
    public List<int> is_var = new List<int>();
    [Title("�����ж�")]
    public List<Enum_var_set> var_con_get= new List<Enum_var_set>();
    public enum Enum_var_set
    {
        ����,
        ����,
        ���ڵ���,
        С��,
        С�ڵ���
    }


    [ShowIf("condition_bool")]
    [Title("ָ�������ͼƬΪ�ض�ͼƬʱ�����¼�")]
    public bool image_set_bool;
    [ShowIfGroup("@image_set_bool && condition_bool")]
    [BoxGroup("@image_set_bool && condition_bool/ָ�������ͼƬΪ�ض�ͼƬʱ�����¼�")]
    [Title("�ض�/���ض�", HorizontalLine = false)]
    public bool image_set = true;
    [ShowIfGroup("@image_set_bool && condition_bool")]
    [BoxGroup("@image_set_bool && condition_bool/ָ�������ͼƬΪ�ض�ͼƬʱ�����¼�")]
    [Title("���", HorizontalLine = false)]
    public List<GameObject> image_pic_obj=new List<GameObject>();
    [ShowIfGroup("@image_set_bool && condition_bool")]
    [BoxGroup("@image_set_bool && condition_bool/ָ�������ͼƬΪ�ض�ͼƬʱ�����¼�")]
    [Title("ͼƬ", HorizontalLine = false)]
    public List<Sprite> image_pic=new List<Sprite>();
    /*
    [DictionaryDrawerSettings(KeyLabel = "���", ValueLabel = "ͼƬ")]
    public Dictionary<GameObject, Sprite> image_pic;
    */

    [ShowIf("condition_bool")]
    [Title("ָ������Ƿ���ʾʱ�����¼�")]
    public bool image_vis_bool;
    [ShowIfGroup("@image_vis_bool && condition_bool")]
    [BoxGroup("@image_vis_bool && condition_bool/ָ������Ƿ���ʾʱ�����¼�")]
    [Title("���", HorizontalLine = false)]
    public List<GameObject> image_vis_obj = new List<GameObject>();
    [ShowIfGroup("@image_vis_bool && condition_bool")]
    [BoxGroup("@image_vis_bool && condition_bool/ָ������Ƿ���ʾʱ�����¼�")]
    [Title("ͼƬ", HorizontalLine = false)]
    public List<bool> image_vis = new List<bool>();

    /*
    [DictionaryDrawerSettings(KeyLabel = "���", ValueLabel = "��ʾ")]
    public Dictionary<GameObject, bool> image_vis = new Dictionary<GameObject, bool>();
    */
}

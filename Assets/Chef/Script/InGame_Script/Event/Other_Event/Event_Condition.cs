using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Condition : SerializedMonoBehaviour
{
    

    //[Header("ѡ���Ӧ��Ʒʱ���ܴ����¼�")]
    [Title("ѡ���Ӧ��Ʒʱ���ܴ����¼�")]

    [Title("��Ӧ/�Ƕ�Ӧ", HorizontalLine=false)]
    public bool item_set = true;
    [Title("��Ʒ", HorizontalLine = false)]
    public ItemSaveScript item_id;

    //[Header("��Ʒ״̬����ѡ��ʱ�������¼�")]
    [Title("��Ʒ״̬����ѡ��ʱ�������¼�")]
    public bool is_choose;

    [Title("�����Ƿ����", HorizontalLine = false)]
    [Title("������")]
    public GameObject var_obj;
    [DictionaryDrawerSettings(KeyLabel = "������", ValueLabel = "����ֵ")]
    public Dictionary<string, int> is_var = new Dictionary<string, int>();
    [Title("�����ж�")]
    public Dictionary<string, int> var_con = new Dictionary<string, int>();

    //[Header("ָ�������ͼƬΪ�ض�ͼƬʱ�����¼�")]
    [Title("ָ�������ͼƬΪ�ض�ͼƬʱ�����¼�")]
    //[Header("�ض�/���ض�")]
    [Title("�ض�/���ض�", HorizontalLine = false)]
    public bool image_set = true;

    [Title("��Ʒ", HorizontalLine = false)]
    [DictionaryDrawerSettings(KeyLabel = "���", ValueLabel = "ͼƬ")]
    public Dictionary<GameObject,Sprite> image_pic=new Dictionary<GameObject,Sprite>();

    //[Header("ָ������Ƿ���ʾʱ�����¼�")]
    [Title("ָ������Ƿ���ʾʱ�����¼�")]
    [DictionaryDrawerSettings(KeyLabel = "���", ValueLabel = "��ʾ")]
    public Dictionary<GameObject, bool> image_vis = new Dictionary<GameObject, bool>();
    // Start is called before the first frame update
    void Start()
    {
        
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Set : SerializedMonoBehaviour
{
    /*
    [Title("ִ�иô�����������ִ�е���һ��������")]
    [SceneObjectsOnly]
    public GameObject next_TRI;
    [Title("͢ʱ����")]
    public float time = 0;
    */
    [Title("��������")]
    [DictionaryDrawerSettings(KeyLabel = "������", ValueLabel = "����ֵ")]
    public Dictionary<string,int> var_set=new Dictionary<string, int>();
    [Title("��ʼʱ�����¼�")]
    public bool Start_tri;
    [Title("ͼ��")]
    public int sort_set = 0;

}

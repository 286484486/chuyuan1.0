using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class Event_admin_Set
{

    /*
    [Title("ִ�иô�����������ִ�е���һ��������")]
    [SceneObjectsOnly]
    public GameObject next_TRI;
    */
    /*
    [Title("͢ʱ����")]
    public float time = 0;
    */
    [Title("��������")]
    [Title("������")]
    public List<string> var_set_string = new List<string>();
    [Title("����ֵ")]

    public List<int> var_set = new List<int>();

    [Title("��ʼʱ�����¼�")]
    public bool Start_tri;

    [Title("ͼ��")]
    public int sort_set = 0;
}

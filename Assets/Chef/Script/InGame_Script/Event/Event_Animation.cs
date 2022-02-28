using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_Animation : Event_parents
{
    [Title("���õ�������ŵĶ���id")]
    [DictionaryDrawerSettings(KeyLabel = "���", ValueLabel = "����id")]
    [SceneObjectsOnly]
    public Dictionary<GameObject, string> obj = new Dictionary<GameObject, string>();
    [Title("����ģʽ����")]
    public string anime_mode;
    //[Header("���ػ���ʾ")]
    //public List<bool> obj_bool;

    protected override void Event_on(string mode)
    {
        Event_interface c = new Animation_Command(obj,anime_mode);
        Event_send(mode, c);
    }
}

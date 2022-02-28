using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Event_image_change : Event_parents
{
    /*
    [Header("Ҫ����ͼƬ�����")]
    [SceneObjectsOnly]
    public List<GameObject> obj;
    [Header("�ĳ�ʲôͼƬ")]
    public List<Sprite> obj_change;
    */
    [Title("Ҫ����ͼƬ�����   �ĳ�ʲôͼƬ")]
    [DictionaryDrawerSettings(KeyLabel = "���", ValueLabel = "ͼƬ")]
    public Dictionary<GameObject, Sprite> obj = new Dictionary<GameObject, Sprite>();
    protected override void Event_on(string mode)
    {
        Event_interface c = new image_change_Command(obj);
        Event_send(mode, c);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class Book_Save
{
    [Title("չ��")]
    public bool Showit=true;
    [ShowIf("Showit")]
    [Title("���iCG")]
    public Sprite CG_spr;
    [Title("δ���iCG")]
    public Sprite CG_spr_lock;
    [ShowIf("Showit")]
    [Title("����")]
    public string name_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("��Ϣ")]
    public string message_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("����")]
    public string birth_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("�ۺ�")]
    public string hobby_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("����")]
    public string die_reason_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("ϲ�gʳ��")]
    public string food_fav_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("��ǰ")]
    public string life_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("����")]
    public string die_text;
}

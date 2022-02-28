using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class Book_Save
{
    [Title("展开")]
    public bool Showit=true;
    [ShowIf("Showit")]
    [Title("解鎖CG")]
    public Sprite CG_spr;
    [Title("未解鎖CG")]
    public Sprite CG_spr_lock;
    [ShowIf("Showit")]
    [Title("名字")]
    public string name_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("信息")]
    public string message_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("生日")]
    public string birth_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("愛好")]
    public string hobby_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("死因")]
    public string die_reason_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("喜歡食物")]
    public string food_fav_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("生前")]
    public string life_text;
    [ShowIf("Showit")]
    [TextArea]
    [Title("死后")]
    public string die_text;
}

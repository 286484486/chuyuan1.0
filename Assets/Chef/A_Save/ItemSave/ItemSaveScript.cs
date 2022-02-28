using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewItem",menuName ="ASave/NewItem")]
public class ItemSaveScript : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    [TextArea]
    public string itemInfo;
}

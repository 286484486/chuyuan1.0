using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "NewTalk", menuName = "ASave/NewTalk")]
public class TalkSaveScript : SerializedScriptableObject
{
    public List<TalkSaveClass> Talk;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk_Command : Command_Parents, Event_interface
{
    TalkSaveScript key;
    Talk_control TK;
    public Talk_Command(TalkSaveScript key,Talk_control TK)
    {
        this.key = key;
        this.TK = TK;
    }

    
    public void Event()
    {
        TK.talk_Key(key);
    }

}

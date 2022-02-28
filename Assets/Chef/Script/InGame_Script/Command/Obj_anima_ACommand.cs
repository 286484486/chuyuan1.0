using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_anima_ACommand : Command_Parents, Anima_interface
{
    string anima_name;
    public Obj_anima_ACommand(string anima_name)
    {
        this.anima_name = anima_name;
    }

    public void Anima(int i)
    {
        if (anima_name == "target")
        {

        }
    }
}
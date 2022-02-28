using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Invoker : MonoBehaviour
{
    static Queue<Event_interface> commandBuffer;
    static List<Anima_interface> AnimaBuffer;
    static Queue<Event_interface> commandBuffer_set;
    
    public static string text_command;

    void Awake()
    {
        commandBuffer = new Queue<Event_interface>();
        AnimaBuffer = new List<Anima_interface>();
        commandBuffer_set = new Queue<Event_interface>();
        text_command = "";
    }

    // Start is called before the first frame update
    public static void AddCommand(Event_interface command)
    {
        commandBuffer.Enqueue(command);
    }
    public static void AddCommand(Anima_interface command)
    {
        AnimaBuffer.Add(command);
    }
    public static void RemoveACommnad(int i)
    {
        Anima_interface c = AnimaBuffer[i];
        c.next_TRI_script();
        AnimaBuffer.RemoveAt(i);
        if (AnimaBuffer.Count == 0) { Game_admin.Delay = 0; }

    }


    // Update is called once per frame
    void Update()
    {
        if (commandBuffer_set.Count > 0)
        {
            
            Event_interface c = commandBuffer_set.Dequeue();
            c.Event();
            c.next_TRI_script();

        }
        if (commandBuffer.Count > 0)
        { 
            Event_interface c = commandBuffer.Dequeue();
            commandBuffer_set.Enqueue(c);

        }
        if (AnimaBuffer.Count > 0)
        {
            Game_admin.Delay = 1;
            for (int i = 0; i < AnimaBuffer.Count; i++)
            {

                Anima_interface c = AnimaBuffer[i];
                c.Anima(i);
            }
            
        }
        
        if (text_command != "")
        {
            text_command = "";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_anima_end : MonoBehaviour
{
    public Queue<Event_interface> Ievent=new Queue<Event_interface>();
    public List<Anima_interface> IAnima=new List<Anima_interface>();
    
    public void click_end()
    {
        while (Ievent.Count > 0)
        {
            Event_Invoker.AddCommand(Ievent.Dequeue());
            
        }
        for (int i = 0; i < IAnima.Count; i++)
        {
            Event_Invoker.AddCommand(IAnima[i]);
        }
        IAnima.Clear();
        Game_admin.Delay = 0;
        Destroy(gameObject);
    }
    public void Delay_set()
    {
       // Game_admin.Delay = 1;

    }
    
    public void Destroy_sc()
    {
        Destroy(gameObject);
    }

}

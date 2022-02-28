using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qeye_click : MonoBehaviour
{
    public bool click_bool;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        if (!Qeye_control.Lock)
        {

            gameObject.transform.parent.GetComponent<Qeye_control>().Set_Click(click_bool);
        }
    }
}

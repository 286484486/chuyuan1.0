using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qoni_Face_change : MonoBehaviour
{
    public bool[] control_b = new bool[4];
    public bool locking;
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
        if (locking) { return; }
        for (int i = 0; i < control_b.Length; i++)
        {
            if (control_b[i])
            {
                Qoni_control v_Con = gameObject.transform.parent.GetComponent<Qoni_control>();
                int v_count=v_Con.Face_obj[i].GetComponent<Qoni_image>().Face_image.Count;
                if (v_Con.Face[i] < v_count - 1) {
                    v_Con.Face[i] += 1;
                }
                else { v_Con.Face[i] = 0; }
            }
        }
        gameObject.transform.parent.GetComponent<Qoni_control>().Face_reset();

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QOeyes_click : MonoBehaviour
{
    [HideInInspector]
    public bool locking;

    public int num;



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
        if (!QOeyes_control.Lock && !locking)
        {
            gameObject.transform.parent.GetComponent<QOeyes_control>().Set_Click(num);
        }
    }
}

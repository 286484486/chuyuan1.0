using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qshao_set : MonoBehaviour
{
    public Sprite finish_spr,first_spr;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = first_spr;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

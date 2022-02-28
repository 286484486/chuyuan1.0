using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qtree_control : MonoBehaviour
{
    private int delay_mode;
    private float delay;
    public int Q_mode;
    public int[] Face = new int[4];
    public GameObject[] Face_C = new GameObject[4];
    public GameObject[] Face_obj = new GameObject[4];
    public int[] Face_Finish = new int[4];
    public int Face_max=3;
    // Start is called before the first frame update

    void Awake()
    {
        Q_mode = 0;
        delay = 0;
        delay_mode = 0;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Face_reset()
    {
        bool finish = true;

        for (int i = 0; i < Face.Length; i++)
        {
            if (Face[i] != Face_Finish[i]) { finish = false; }
        }

        if (finish)
        {
            for (int i = 0; i < Face_C.Length; i++)
            {
                Face_C[i].GetComponent<Qtree_move>().locking = true;
            }
            Q_mode = 1;
            delay_mode = 0;
            delay = 2;
        }
    }
}

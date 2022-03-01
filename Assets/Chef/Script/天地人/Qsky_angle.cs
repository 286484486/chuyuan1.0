using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qsky_angle : MonoBehaviour
{
    public float angle_set, angle_set_now;
    // Start is called before the first frame update
    void Start()
    {
        angle_set = gameObject.transform.localEulerAngles.z;
        angle_set_now = angle_set;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localEulerAngles.z != angle_set)
        {
            float v_spd = 5 * Time.deltaTime;
            float pos_z = angle_set_now;
            if (v_spd > 1) { v_spd = 1; }
            pos_z += (angle_set - pos_z) * v_spd;
            if (Mathf.Abs(angle_set - pos_z) < 1f)
            {
                pos_z = angle_set;
                while (angle_set >= 360) { angle_set -= 360; }
                while (angle_set < 0) { angle_set += 360; }
                while (angle_set_now >= 360) { angle_set_now -= 360; }
                while (angle_set_now < 0) { angle_set_now += 360; }
            }
            gameObject.transform.rotation = Quaternion.AngleAxis(pos_z, Vector3.forward);
            angle_set_now = pos_z;
        }       
    }

    public void Lock(float angle)
    {
        angle_set = angle;
    }
}

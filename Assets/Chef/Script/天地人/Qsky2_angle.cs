using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Qsky2_angle : MonoBehaviour
{
    public float angle_set, angle_set_now;

    public GameObject obj1, obj2, obj3;

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
            float angle_add = (angle_set - pos_z) * v_spd;
            pos_z += angle_add;
            if (Mathf.Abs(angle_set - pos_z) < 1f)
            {
                pos_z = angle_set;
                angle_add = (angle_set - pos_z);
                while (angle_set >= 360) { angle_set -= 360; }
                while (angle_set < 0) { angle_set += 360; }
                while (angle_set_now >= 360) { angle_set_now -= 360; }
                while (angle_set_now < 0) { angle_set_now += 360; }
              
            }
            Angle_set_sc(angle_add);
            //gameObject.transform.rotation = Quaternion.AngleAxis(pos_z, Vector3.forward);
            //obj1.transform.rotation = Quaternion.AngleAxis(obj1.transform.localEulerAngles.z + angle_add, Vector3.forward);
            angle_set_now = pos_z;
        }       
    }

    public void Lock(float angle)
    {
        angle_set = angle;
    }

    public void Angle_set_sc(float angle_add)
    {
        gameObject.transform.rotation = Quaternion.AngleAxis(gameObject.transform.localEulerAngles.z + angle_add, Vector3.forward);
        obj1.transform.rotation = Quaternion.AngleAxis(obj1.transform.localEulerAngles.z + angle_add, Vector3.forward);
        obj2.transform.rotation = Quaternion.AngleAxis(obj2.transform.localEulerAngles.z - angle_add/5, Vector3.forward);
        obj3.transform.rotation = Quaternion.AngleAxis(obj3.transform.localEulerAngles.z + angle_add / 10, Vector3.forward);
    }
}

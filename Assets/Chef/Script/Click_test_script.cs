using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_test_script : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("鼠标按下时调用一次");
    }

    private void OnMouseEnter()
    {
        Debug.Log("鼠标进入物体时调用一次");
    }

    private void OnMouseDrag()
    {
        Debug.Log("鼠标按住拖拽时调用");
    }

    private void OnMouseExit()
    {
        Debug.Log("鼠标退出物体时调用一次");
    }

    private void OnMouseOver()
    {
        Debug.Log("鼠标在物体中时一直调用");
    }

    private void OnMouseUp()
    {
        Debug.Log("鼠标点击抬起时调用一次，及时不在物体内抬起也可以触发");
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("只有在物体内点击并且在物体内抬起时才会调用");
    }

}

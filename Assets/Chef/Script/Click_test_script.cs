using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_test_script : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("��갴��ʱ����һ��");
    }

    private void OnMouseEnter()
    {
        Debug.Log("����������ʱ����һ��");
    }

    private void OnMouseDrag()
    {
        Debug.Log("��갴ס��קʱ����");
    }

    private void OnMouseExit()
    {
        Debug.Log("����˳�����ʱ����һ��");
    }

    private void OnMouseOver()
    {
        Debug.Log("�����������ʱһֱ����");
    }

    private void OnMouseUp()
    {
        Debug.Log("�����̧��ʱ����һ�Σ���ʱ����������̧��Ҳ���Դ���");
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("ֻ���������ڵ��������������̧��ʱ�Ż����");
    }

}

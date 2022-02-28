using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;
using System.IO;



public class Excel_Load : MonoBehaviour
{
    public string pathExcel;
    private List<Dictionary<string, string>> G_talk_List = new List<Dictionary<string, string>>();
    // Start is called before the first frame update
    void Start()
    {
        pathExcel = Application.dataPath + "/Excel/" + pathExcel;

        FileInfo fileinfo = new FileInfo(pathExcel);

        using (ExcelPackage exPackage = new ExcelPackage(fileinfo))
        {
            ExcelWorksheet wsheel = exPackage.Workbook.Worksheets[1];
            Debug.Log(wsheel.Cells[2, 2].Value.ToString());
            for (int i = 0; i < 5; i++)
            {

            }


        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
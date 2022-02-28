using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_Mask_Script : MonoBehaviour
{
    public bool mode;
    private float y_set = 343;
    public int choose_id;
    public RectTransform paper;
    private float paper_y, Mask_2_y, paper_y_set;
    public RectTransform Mask_2_obj;
    public GameObject effort_obj;
    // Start is called before the first frame update
    void Start()
    {
        paper_y = paper.anchoredPosition[1] - gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition[1];
        Mask_2_y = Mask_2_obj.parent.GetComponent<RectTransform>().anchoredPosition[1] - gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition[1];
        paper_y_set = paper.anchoredPosition[1] - Mask_2_obj.parent.GetComponent<RectTransform>().anchoredPosition[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (mode) { y_set = 5; effort_obj.SetActive(true); }
        else { y_set = 500; effort_obj.SetActive(false); }

        RectTransform rtran = gameObject.transform.parent.GetComponent<RectTransform>();
        float rtran_y = rtran.anchoredPosition[1];

        if (rtran.anchoredPosition[1] != y_set)
        {
            Transform v_parents = gameObject.transform.parent;
            Transform v_parents_Mask2 = Mask_2_obj.transform.parent;
            gameObject.transform.SetParent(gameObject.transform.parent.parent);
            Mask_2_obj.transform.SetParent(Mask_2_obj.parent.parent);

            float v_spd = 10 * Time.deltaTime;

            if (v_spd > 1) { v_spd = 1; }
            rtran_y += (y_set - rtran_y) * v_spd;
            v_parents.GetComponent<RectTransform>().anchoredPosition = new Vector2(rtran.anchoredPosition[0], rtran_y);

            if (Mathf.Abs(rtran.anchoredPosition[1] - y_set) < 2f)
            {
                v_parents.GetComponent<RectTransform>().anchoredPosition = new Vector2(rtran.anchoredPosition[0], y_set);
            }

            paper.anchoredPosition = new Vector2(paper.anchoredPosition[0], v_parents.GetComponent<RectTransform>().anchoredPosition[1] + paper_y);
            v_parents_Mask2.GetComponent<RectTransform>().anchoredPosition = new Vector2(v_parents_Mask2.GetComponent<RectTransform>().anchoredPosition[0], v_parents.GetComponent<RectTransform>().anchoredPosition[1] + Mask_2_y);
            //paper.anchoredPosition = new Vector2(paper.anchoredPosition[0],v_parents.GetComponent<RectTransform>().anchoredPosition[1] + paper_y_set);

            gameObject.transform.SetParent(v_parents);
            Mask_2_obj.transform.SetParent(v_parents_Mask2);
        }




    }
}

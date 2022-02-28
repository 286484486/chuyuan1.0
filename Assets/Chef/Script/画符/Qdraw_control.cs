using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Qdraw_control : MonoBehaviour
{

	public GameObject linePrefab;
	public LayerMask cantDrawOverLayer;
	//int cantDrawOverLayerIndex;

	[Space(30f)]
	public Gradient lineColor;
	public float linePointsMinDistance;
	public float lineWidth;

	private Transform parents_set;
	private float pos_x, pos_y;

	private int draw_mode; //畫畫模式
	private List<Line> Line_obj = new List<Line>();   //畫出的線條
	public List<Line> Set_obj = new List<Line>();   //線條記錄點
	public GameObject Earse; //半透明圓

	public Vector2 mousePosition_First;

	public Transform loc_prefab;

	Line currentLine;

	Camera cam;

	void Awake() {
		pos_x = loc_prefab.transform.position.x;
		pos_y = loc_prefab.transform.position.y;
		Earse.SetActive(false);
	}

	void Start()
	{
		cam = Camera.main;
		//cantDrawOverLayerIndex = LayerMask.NameToLayer ( "CantDrawOver" );


	}

	void OnDisable()
	{
		//gameObject.transform.parent.SetParent(Camera.main.transform);
		currentLine = null;
	}


	void Update()
	{
		if (Input.GetMouseButtonDown(0) && Game_admin.Some_mode)
		{
			if (draw_mode == 0)
			{
				
				BeginDraw();
			}
		}

		if (currentLine != null)
		{
			Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
			Earse.transform.position = mousePosition;
			Draw();
		}


		if (Input.GetMouseButtonUp(0))
		{
			
			EndDraw();
		}


	}

	// Begin Draw ----------------------------------------------
	void BeginDraw()
	{
		if (Line_obj.Count > 1000) { return; }
		currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

		currentLine.SetLineColor(lineColor);
		currentLine.SetPointsMinDistance(linePointsMinDistance);
		currentLine.SetLineWidth(lineWidth);
		mousePosition_First = cam.ScreenToWorldPoint(Input.mousePosition);
		mousePosition_First = new Vector2(mousePosition_First.x + (pos_x - Camera.main.transform.position.x), mousePosition_First.y + (pos_y - Camera.main.transform.position.y));


		//gameObject.transform.parent.SetParent(parents_set);
		//gameObject.transform.parent.position = new Vector2(pos_x, pos_y); 
	}

	void ContinueDraw()
	{
		if (Line_obj.Count > 1000) { return; }
		currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

		currentLine.SetLineColor(lineColor);
		currentLine.SetPointsMinDistance(linePointsMinDistance);
		currentLine.SetLineWidth(lineWidth);
	}

	// Draw ----------------------------------------------------
	void Draw()
	{
		Earse.SetActive(true);
		Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

		//Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )
		//RaycastHit2D hit = Physics2D.CircleCast ( mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer );

		//mousePosition = new Vector2(mousePosition.x + (pos_x - Camera.main.transform.position.x), mousePosition.y + (pos_y - Camera.main.transform.position.y));
		if (mousePosition.x - pos_x < -1000 || mousePosition.x - pos_x > 1000 || mousePosition.y - pos_y < -1200 || mousePosition.y - pos_y > 1200
		)
		{
			EndDraw();
		}

		if (currentLine != null)
		{
			if (mousePosition.x - pos_x < -500 || mousePosition.x - pos_x > 500 || mousePosition.y - pos_y < -700 || mousePosition.y - pos_y > 690
			|| mousePosition_First.x - pos_x < -500 || mousePosition_First.x - pos_x > 500 || mousePosition_First.y - pos_y < -700 || mousePosition_First.y - pos_y > 690
			)
			{
				EndDraw();
				mousePosition_First = mousePosition;
				ContinueDraw();

			}
		}
		/*
		if (currentLine.pointsCount >= 999
		)
		{
			currentLine.AddPoint(mousePosition);
			EndDraw();
			mousePosition_First = mousePosition;
			ContinueDraw();

		}
		*/

		if (currentLine != null)
		{
			currentLine.AddPoint(mousePosition);
		}
	}
	// End Draw ------------------------------------------------
	void EndDraw()
	{
		Earse.SetActive(false);
		if (currentLine != null)
		{
			if (currentLine.pointsCount < 2)
			{
				//If line has one point
				Destroy(currentLine.gameObject);
				currentLine = null;
			}
			else
			{
				//Add the line to "CantDrawOver" layer
				//currentLine.gameObject.layer = cantDrawOverLayerIndex;

				Line_obj.Add(currentLine);
				currentLine = null;
			}
			//gameObject.transform.parent.SetParent(Camera.main.transform);
		}
	}


	void Clear_draw()
	{
		if (Input.GetMouseButton(0))
		{
			Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
			//mousePosition = new Vector2(mousePosition.x + (pos_x - Camera.main.transform.position.x), mousePosition.y + (pos_y - Camera.main.transform.position.y));
			Earse.transform.position = mousePosition;
			for (int i = 0; i < Set_obj.Count; i++)
			{
				EdgeCollider2D coll = Set_obj[i].GetComponent<EdgeCollider2D>();
				if (coll.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
				{
					Destroy(Set_obj[i].gameObject);
					Set_obj.RemoveAt(i);
				}
			}
		}
	}

	public void Line_Clear()
	{
		for (int i = 0; i < Line_obj.Count; i++)
		{
			if (Line_obj[i] != null)
			{
				Destroy(Line_obj[i].gameObject);
			}
		}
		Line_obj.Clear();

	}

}

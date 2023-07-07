using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;


using System.Linq;


public class AllMenuElementsCreator: MonoBehaviour
{
	[SerializeField]
	private MainMenuController _MainMenuController;
	[SerializeField]
	private CreateMenuElement _CreateMenuElement;

	//public bool allObjectPlaced = false;
	public UnityAction MyAction;
	
	[SerializeField] private int numberOfRects = 1;

	[Space(20)]
	[SerializeField] private RectTransform imagePrefab;
	[SerializeField] private RectTransform buttonPrefab;
	[SerializeField] private RectTransform panel;

	public List<RectTransform> spawnedRects = new List<RectTransform>();
	public bool canPlaceNewRect = true;
	public RectTransform currentRectTransform;






	void Start()
	{

	}
	
	void Update()
	{
		//Debug.Log("Update()");
		//if (allObjectPlaced)
		//{
		//	enabled = false;
		//	return;
		//}

			

		if (canPlaceNewRect)
		{
			//Debug.Log("canPlaceNewRect");
			RectTransform rectTransform = Instantiate(buttonPrefab, panel.transform);
			currentRectTransform = rectTransform;

			currentRectTransform = SetRandomSize(currentRectTransform);
			currentRectTransform = SetRandomPosition(currentRectTransform);
			

			canPlaceNewRect = false;
		}
		else
		{
			//Debug.Log("!canPlaceNewRect");
			if (IsRectIntersectingOther(currentRectTransform))
			{
				currentRectTransform = SetRandomSize(currentRectTransform);
				currentRectTransform = SetRandomPosition(currentRectTransform);
			}
			else
			{

				spawnedRects.Add(currentRectTransform);
				canPlaceNewRect = true;
				numberOfRects++;
				//Вызвать ивент обновления UI
				_MainMenuController.UpdateUI(numberOfRects);
				
				_CreateMenuElement?.InstallContent(
					currentRectTransform.gameObject, numberOfRects);
				
				//InstallContent(spawnedRects.Last().gameObject,numberOfRects);

			}
		}        

	}
	


	private RectTransform SetRandomSize(RectTransform rectTransform)
	{
		float randomSizeX = Random.Range(50f, 200f);
		float randomSizeY = Random.Range(50f, 200f);
		rectTransform.sizeDelta = new Vector2(randomSizeX, randomSizeY);
		return rectTransform;
	}

	private RectTransform SetRandomPosition(RectTransform rectTransform)
	{
		float halfPanelWidth = panel.rect.width / 2f;
		float halfPanelHeight = panel.rect.height / 2f;

		float randomPosX = Random.Range(-halfPanelWidth, halfPanelWidth);
		float randomPosY = Random.Range(-halfPanelHeight, halfPanelHeight);

		rectTransform.anchoredPosition = new Vector2(randomPosX, randomPosY);
		return rectTransform;
	}

	private bool IsRectIntersectingOther(RectTransform rectTransform)
	{
		foreach (RectTransform childRectTransform in spawnedRects)
		{
			if (childRectTransform.Equals( rectTransform))
				continue;

			if (RectIntersects(rectTransform, childRectTransform))
			{
				return true;
			}
		}

		return false;
	}

	private bool RectIntersects(RectTransform rectTransform1, RectTransform rectTransform2)
	{

		return RectTransformExtensions.Overlaps(rectTransform1,rectTransform2);
	
	}
	

	private void RemoveComponent<T>() where T : Component
	{
		T component = GetComponent<T>();
        
		if (component != null)
		{
			Destroy(component);
		}
	}


}

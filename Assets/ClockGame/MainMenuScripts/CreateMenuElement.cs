using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;


public class CreateMenuElement : MonoBehaviour
{
	[SerializeField]
	private MainMenuController _MainMenuController;

	public void InstallContent(GameObject gameObject, int objectNumber)
	
	{
		if (objectNumber < 7)
		{
			InstallImage(gameObject,objectNumber);
		}
		if (objectNumber == 7)		
			InstallButton(gameObject, "Play", _MainMenuController.PlayClicked);
		if (objectNumber == 8)		
			InstallButton(gameObject, "Settings", _MainMenuController.SettingsClicked);
		if (objectNumber == 9)		
			InstallButton(gameObject, "Exit", _MainMenuController.ExitClicked);
		//if (objectNumber > 9)
		//	allObjectPlaced = true;
			
	}
	
	
	private void InstallImage(GameObject gameObject, int objectNumber)
	{
		Sprite sprite = Resources.Load<Sprite>("image-" + (objectNumber+1)); // Assuming your sprites are named "Image1", "Image2", etc.

		// Set the sprite of the image
		gameObject.GetComponent<Image>().sprite = sprite;
		gameObject.GetComponent<Image>().color = Color.white;
		
		
		//if (gameObject.GetComponentInChildren<Text>() != null)
		//{
		//	while (transform.childCount > 0) {
		//		DestroyImmediate(transform.GetChild(0).gameObject);
		//	}

		//}
		
		gameObject.GetComponentInChildren<Text>().text = "";



	}
	
	private void InstallButton(GameObject gameObject, string buttonText, UnityEngine.Events.UnityAction buttonAction)
	{
		// Set the button text
		gameObject.GetComponentInChildren<Text>().text = buttonText;

		// Add a button click listener
		gameObject.GetComponent<Button>().onClick.AddListener(buttonAction);
	}


}

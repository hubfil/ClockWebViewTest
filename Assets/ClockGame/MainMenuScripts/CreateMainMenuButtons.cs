using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EasyButtons;

public class CreateMainMenuButtons : MonoBehaviour
{
	public GameObject buttonPrefab; // Prefab for the button
	public Transform buttonParent; // Parent transform to hold the buttons

	private void Start()
	{
		GenerateButton();
	}
	
	[Button]
	public void GenerateButton()
	{
		CreateButton("Play", new Vector2(0, 0), PlayClicked);
		CreateButton("Settings", new Vector2(0, -50), SettingsClicked);
		CreateButton("Exit", new Vector2(0, -100), ExitClicked);
	}

	private void CreateButton(string buttonText, Vector2 buttonPosition, UnityEngine.Events.UnityAction buttonAction)

	//private void CreateButton(string buttonText, Vector2 buttonPosition,Vector2 buttonSize, UnityEngine.Events.UnityAction buttonAction)
	{
		buttonPosition = new Vector2(Random.Range(-100f, 100f), Random.Range(-100f, 100f));
		Vector2 buttonSize = new Vector2(Random.Range(50f, 200f), Random.Range(30f, 100f));
		
		// Instantiate the button prefab
		GameObject buttonObject = Instantiate(buttonPrefab, buttonParent);

		// Set the position of the button
		buttonObject.GetComponent<RectTransform>().anchoredPosition = buttonPosition;

		buttonObject.GetComponent<RectTransform>().sizeDelta = buttonSize;

		// Set the button text
		buttonObject.GetComponentInChildren<TextMeshProUGUI>().text = buttonText;

		// Add a button click listener
		buttonObject.GetComponent<Button>().onClick.AddListener(buttonAction);
	
		buttonObject.name = buttonText;
	}

	private void PlayClicked()
	{
		Debug.Log("Play clicked!");
	}

	private void SettingsClicked()
	{
		Debug.Log("Settings clicked!");
	}

	private void ExitClicked()
	{
		Debug.Log("Exit clicked!");
	}
}
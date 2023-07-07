using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MainMenuController : MonoBehaviour
{
	
	
	[SerializeField] TextMeshProUGUI numberOfRectsUI;


	public void PlayClicked()
	{
		Debug.Log("Play clicked!");
	}

	public void SettingsClicked()
	{
		Debug.Log("Settings clicked!");
	}

	public void ExitClicked()
	{
		Debug.Log("Exit clicked!");
	}
	
	public void UpdateUI(int numberOfRects)
	{
		numberOfRectsUI.text = numberOfRects.ToString("D2");

	}
}

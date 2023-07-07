using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockView : MonoBehaviour
{
	
	public int hourValue, minuteValue, secondValue;
	
	[SerializeField]
	private TextMeshProUGUI TextUI;
	
	protected void Update()
	{
		TextUI.text = 
			hourValue.ToString("D2") + " : " + 
			minuteValue.ToString("D2") + " : " + 
			secondValue.ToString("D2");

	}
 
}

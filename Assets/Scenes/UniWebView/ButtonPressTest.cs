using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;


public class ButtonPressTest : MonoBehaviour
{
    public Button myButton;
	public TextMeshProUGUI buttonText;
	
	public UniWebView _UniWebView;
	

    private void Start()
	{
		myButton = gameObject.GetComponent<Button>();
		buttonText = myButton.GetComponentInChildren<TextMeshProUGUI>();
    	
    	
        myButton.onClick.AddListener(() =>
        {
	        
	        //buttonText.text = buttonText.text + 

		        toggleObjectActivity(_UniWebView.gameObject);

        });
        
        
	
	}
	private void toggleObjectActivity(GameObject targetObject)

	{
		// Check if the targetObject is active
		if (targetObject.activeSelf)
		{
			// Deactivate the targetObject if it's active
			targetObject.SetActive(false);
		}
		else
		{
			// Activate the targetObject if it's inactive
			targetObject.SetActive(true);
		}
	
	}
}
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
	public Text valueText;
	public int currentValue = 1;

	public Button myButton;
	
	public UniWebView _UniWebView;
	

	private void Start()
	{
		myButton = gameObject.GetComponent<Button>();
    	
    	
		myButton.onClick.AddListener(() =>
		{
	        
			//buttonText.text = buttonText.text + 

			OnToggleButtonClicked();

		});
        
        
	
	}


	public void OnToggleButtonClicked()
	{
		if (currentValue == 1)
		{
			currentValue = 10;
		}
		else if (currentValue == 10)
		{
			currentValue = 100;
		}
		else
		{
			currentValue = 1;
		}

  

		//valueText.text = currentValue.ToString();
	}
}
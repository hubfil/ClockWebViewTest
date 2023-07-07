using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebViewUI : MonoBehaviour
{
	[SerializeField]
	private UniWebView _UniWebView;
	
	
	[Space (20)]
	[SerializeField]
	private Button _toggleButton,
				 _backButton,
				_forwardButton,
				_buttButton;
				
	[Space (20)]
	[SerializeField]			
	private bool isShown;
				 
	private void Start()
	{
		StartCoroutine(WaitForSecondsCoroutine());
		
		isShown = _UniWebView.isActiveAndEnabled;
		_toggleButton.onClick.AddListener(() =>
		{
			if(isShown)
			{
				_UniWebView.Hide();
			}
			else
			{
				_UniWebView.Show();
			}
			isShown = !isShown;
		});
		
		_backButton.onClick.AddListener(() =>
		{
			_UniWebView.GoBack();
		});
		
		_forwardButton.onClick.AddListener(() =>
		{
			_UniWebView.GoForward();
			_UniWebView.Load("http://radioclock.narod.ru/mobile/mobile_s.html");

		});
		
		_buttButton.onClick.AddListener(() =>
		{
			Debug.Log(Random.Range(0,10).ToString("D2"));
		});
	}			 


	private IEnumerator WaitForSecondsCoroutine()
	{
		yield return new WaitForSeconds(5f);
        
		// Code to execute after waiting for 5 seconds
		Debug.Log("Waited for 5 seconds!");
		_UniWebView.Hide();
	}

}

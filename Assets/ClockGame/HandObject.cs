using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandObject : MonoBehaviour
{
	public string handName;
	public Image handImage;
	public float handPosition;
	public float handSpeed;
	//sound
	
	
	public void handMove(float _position)
	{
		//transform handPosition > rotation z
		handImage.GetComponent<RectTransform>().localRotation = Quaternion.EulerAngles(0,0,handPosition);		
		//sound
	}
	

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class HandScriptableObject : ScriptableObject 
{
	
	 #if UNITY_EDITOR
	[MenuItem("Assets/Create/New hand", false, 1)]
	public static void CreateHand() {
		HandScriptableObject data = ScriptableObject.CreateInstance<HandScriptableObject>();
		AssetDatabase.CreateAsset(data, "Assets/New hand.asset");
		AssetDatabase.Refresh();
	}
	 #endif

	
	[SerializeField]
	private string handName;
	[SerializeField]
	private string description;
	[SerializeField]
	public Image handImage;


	public void handMove(float _position)
	{
		//transform handPosition > rotation z
		handImage.GetComponent<RectTransform>().localRotation = Quaternion.EulerAngles(0,0,_position);		
		//sound
	}
}

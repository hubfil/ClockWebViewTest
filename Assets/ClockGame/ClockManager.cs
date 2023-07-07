using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour
{
	public float rotate;
	
	[SerializeField]
	private HingeJoint hourHand;
	[SerializeField]
	private HingeJoint minuteHand;
	[SerializeField]
	private HingeJoint secondsHand;
	
	
	public bool isGoing = true;

	
	
    void Start()
    {
	    Application.targetFrameRate = 30;
    }

    void Update()
	{
		
		
	}

    	
}


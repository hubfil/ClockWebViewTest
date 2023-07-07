using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;
using System;


public class AlarmManagerTest : MonoBehaviour
{
	public ClockView _ClockView;
	public ToggleButton _ToggleButton;
	
	
	private const float
	hoursToDegrees = 360f / 12f,
	minutesToDegrees = 360f / 60f,
	secondsToDegrees = 360f / 60f;
	
	//public Transform hoursHand, minutesHand, secondsHand;

	//public GameObject AlarmCenter;
	//public GameObject AlarmHand;
	////public UnityEngine.UI.Text AlarmText;
	//public HingeJoint AlarmHinge;
	
	
	[SerializeField]
	private float hours, minutes, seconds;
	[SerializeField]
	private Transform hoursHand, minutesHand, secondsHand;
	[SerializeField]
	private HingeJoint hoursHinge, minutesHinge, secondsHinge;
	public bool isGoing = true;


	void Start()
    {
	    Application.targetFrameRate = 30;
    }
    
	void UpdateTime()
	{
		TimeSpan timespan = DateTime.Now.TimeOfDay;

		//hoursHinge = (float)timespan.TotalHours;
		//minutesHinge = (float)timespan.TotalMinutes;
		seconds = (float)timespan.TotalSeconds;
		
	}

    void Update()
	{
		if (isGoing)
		{
			seconds += Time.deltaTime*_ToggleButton.currentValue;
			if (seconds > 60)
			{
				seconds -= 60;
				minutes += 1;
			}
			if (minutes > 60)
			{
				minutes -= 60;
				hours += 1;
			}
			
			hoursHand.localRotation =
				Quaternion.Euler(0f, 0f, hours * -hoursToDegrees);
			minutesHand.localRotation =
				Quaternion.Euler(0f, 0f, minutes * -minutesToDegrees);
			secondsHand.localRotation = Quaternion.Euler(
				0f, 0f, seconds * -secondsToDegrees);
		}
		
		if (!isGoing)
		{
			seconds = (secondsHinge.angle + 180f) * 100f/ (180f * 3.1416f) ;
			seconds = seconds * 60f/ 63.8f;
		}
	    //AlarmText.text = "A" + Vector3.Distance(AlarmCenter.transform.position, AlarmHand.transform.position);
		float timeSeconds;
		timeSeconds = (secondsHinge.angle + 180f) * 100/ (180 * 3.1416f);
		timeSeconds = timeSeconds * 60f/ 63.8f;
		_ClockView.hourValue = (int)hours;
		_ClockView.minuteValue = (int)minutes;
		_ClockView.secondValue = (int)timeSeconds;
    }
    
}

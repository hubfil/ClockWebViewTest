using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TimeManager : MonoBehaviour
{
	 
	private TimeSpan timespan;
	private float hours, minutes, seconds;

	
	public float GetTime()
	{
		return timespan.Seconds;
	}
	
    void Start()
    {
	    timespan = DateTime.Now.TimeOfDay;
    }

    void Update()
    {
	    seconds += Time.deltaTime;
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
    }
}

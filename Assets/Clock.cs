using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {

	public Text timeRemaining;
	private TimeManager timeManager;

	// Use this for initialization
	void Start () {
		timeManager = FindObjectOfType<TimeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timeManager.getRemainingTime() >= 0f) {
			timeRemaining.text = timeManager.getTime ();
		} else {
			timeRemaining.text = "LOSE!";
		}
	}
}

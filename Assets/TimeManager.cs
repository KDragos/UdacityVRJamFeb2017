﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class TimeManager : UnityEngine.MonoBehaviour {

	// This script will be responsible for tracking the time left in the game. It will start a timer when the first person goes through a portal.

	private float remainingTime = 900f; // 15 minutes.
	private PhotonView myPhotonView;
	private bool gameInProgress = false;

	// Use this for initialization
	void Start () {
		myPhotonView = gameObject.GetComponent<PhotonView> ();
		StartGameTimer ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void startTimer() {
		// myPhotonView.RPC( "StartGameTimer", PhotonTargets.AllBuffered);
		this.myPhotonView.RPC ("StartGameTimer", PhotonTargets.All);
		StartGameTimer ();
	}

	[PunRPC]
	void StartGameTimer() {
		remainingTime = (float)(remainingTime - PhotonNetwork.time);
		StartCoroutine ("GameCountdown");
	}

	IEnumerator GameCountdown() {
		while (remainingTime > 0f) {
			yield return new WaitForEndOfFrame ();
			remainingTime -= Time.deltaTime;
			gameInProgress = true;
		}
		if(remainingTime <= 0f) {
			gameInProgress = false;
			// call end of game method for lose screen and restart game. 
		}
	}

	public float getRemainingTime(){
		return this.remainingTime;
	}

	public string getTime() {

		int minutes = Mathf.FloorToInt(remainingTime / 60F);
		int seconds = Mathf.FloorToInt(remainingTime - minutes * 60);
		string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
		return niceTime;
	}
}
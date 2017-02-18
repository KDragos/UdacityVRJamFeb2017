using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
	public GameObject teleportLocation;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		// Move player to the teleportLocation;
		this.player.transform.position = teleportLocation.transform.position;
		// Deactivate the current teleporter so only one player can go through.
		gameObject.SetActive(false);

	}

}

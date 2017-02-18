using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToOtherTime : MonoBehaviour {
	public GameObject otherTeleporterSpawnPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider coll) {
		if (!coll.GetComponent<Teleportable> ().teleported) {
			coll.GetComponent<Teleportable> ().teleported = true;
			coll.transform.position = otherTeleporterSpawnPoint.transform.position;
		}
	}
}

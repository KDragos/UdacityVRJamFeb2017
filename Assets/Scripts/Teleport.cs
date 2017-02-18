using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class Teleport : MonoBehaviour {

    private GameObject ObjectAttachJoint;
    private NVRAttachJoint attachJointScript;

	// Use this for initialization
	void Start () {

        attachJointScript = GameObject.Find("ObjectAttachJoint").GetComponent<NVRAttachJoint>();
    }

    // Update is called once per frame
    void Update () {

        // Check if object is attached and can be teleported or not
        if (attachJointScript.IsAttached && attachJointScript.AttachedItem.gameObject.tag == "TeleportItem") {
            // Disappear Effects
            // TODO
            // 1. Destory 
            iTween.FadeTo(attachJointScript.AttachedItem.gameObject, 0, 5);
        }

	}
}

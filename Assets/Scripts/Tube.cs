using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float angle = this.transform.localEulerAngles.z;

        if (angle == 180 || angle == -180)
        {

            Debug.Log("Pour!!!!");
        }
            //angle -= 360;

        //if (angle > -7.5f)
        //{
        //    if (angle < -0.2f)
        //    {
        //        Rigidbody.AddForceAtPosition(-this.transform.right * ForceMagic, OnButton.position);
        //    }
        //    else if ((angle > -0.2f && angle < -0.1f) || angle > 0.1f)
        //    {
        //        SetRotation(true);
        //    }
        //}
        //else if (angle < -7.5f)
        //{
        //    if (angle > -14.8f)
        //    {
        //        Rigidbody.AddForceAtPosition(-this.transform.right * ForceMagic, OffButton.position);
        //    }
        //    else if ((angle < -14.8f && angle > -14.9f) || angle < -15.1)
        //    {
        //        SetRotation(false);
        //    }
        //}
    }
}

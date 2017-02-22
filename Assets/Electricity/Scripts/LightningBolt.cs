using UnityEngine;
using System.Collections;

public class LightningBolt : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{		
		Material newMat = this.GetComponent<Renderer>().material;
		newMat.SetFloat("_StartSeed",Random.value*1000);
        this.GetComponent<Renderer>().material = newMat;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}


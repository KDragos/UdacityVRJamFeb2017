using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedsDetection : MonoBehaviour {

    public GameObject firstSeed;
    public GameObject secondSeed;
    //public GameObject thirdSeed;
    //public GameObject fourthSeed;

    private Vector3 firstPos;
    private Vector3 secondPos;
    //private Vector3 thirdPos;
    //private Vector3 fourthPos;

    // Use this for initialization
    void Start () {
        firstPos = firstSeed.transform.position;
        secondPos = secondSeed.transform.position;
        //thirdPos = thirdSeed.transform.position;
        //fourthPos = fourthSeed.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.name.Contains("First") && other.tag == "Seed")
        {
            GameObject obj = GameObject.Instantiate(firstSeed, new Vector3(0, 0, 0), Quaternion.identity);
            obj.transform.parent = GameObject.Find("Plant Station").transform;
            obj.transform.localPosition = firstSeed.transform.position;
        }

        if (other.gameObject.name.Contains("Second") && other.tag == "Seed")
        {
            GameObject obj = GameObject.Instantiate(secondSeed, new Vector3(0, 0, 0), Quaternion.identity);
            obj.transform.parent = GameObject.Find("Plant Station").transform;
            obj.transform.localPosition = secondSeed.transform.position;
        }
    }
}

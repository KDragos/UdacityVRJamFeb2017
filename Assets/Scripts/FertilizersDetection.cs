using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertilizersDetection : MonoBehaviour {

    public GameObject firstFertilizer;
    public GameObject secondFertilizer;
    //public GameObject thirdFertilizer;
    //public GameObject fourthFertilizer;

    private Vector3 firstPos;
    private Vector3 secondPos;
    //private Vector3 thirdPos;
    //private Vector3 fourthPos;

    // Use this for initialization
    void Start () {
        firstPos = firstFertilizer.transform.position;
        secondPos = secondFertilizer.transform.position;
        //thirdPos = thirdFertilizer.transform.position;
        //fourthPos = fourthFertilizer.transform.position;
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name.Contains("First") && other.tag == "Fertilizer")
        {
            GameObject obj = GameObject.Instantiate(firstFertilizer, new Vector3(0, 0, 0), Quaternion.identity);
            obj.transform.parent = GameObject.Find("Plant Station").transform;
            obj.transform.localPosition = firstFertilizer.transform.position;
        }

        if (other.gameObject.name.Contains("Second") && other.tag == "Fertilizer")
        {
            GameObject obj = GameObject.Instantiate(secondFertilizer, new Vector3(0, 0, 0), Quaternion.identity);
            obj.transform.parent = GameObject.Find("Plant Station").transform;
            obj.transform.localPosition = secondFertilizer.transform.position;
        }
    }

}

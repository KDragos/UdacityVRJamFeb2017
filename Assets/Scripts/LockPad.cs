using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;
using UnityEngine.UI;

public class LockPad : MonoBehaviour {

    public NVRButton one;
    public NVRButton two;
    public NVRButton three;
    public NVRButton four;
    public NVRButton confirm;
    public NVRButton clear;
    public Canvas textField;

    private string inputString;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        updateTextField();
    }

    private void updateTextField() {

        if (one.ButtonDown)
        {
            inputString += "1 ";
            textField.GetComponentInChildren<Text>().text = inputString;
        }

        if (two.ButtonDown)
        {
            inputString += "2 ";
            textField.GetComponentInChildren<Text>().text = inputString;
        }

        if (three.ButtonDown)
        {
            inputString += "3 ";
            textField.GetComponentInChildren<Text>().text = inputString;
        }

        if (four.ButtonDown)
        {
            inputString += "4 ";
            textField.GetComponentInChildren<Text>().text = inputString;
        }

        if (confirm.ButtonDown) {
            if (inputString.Equals("1 2 3 4 "))
            {
                textField.GetComponentInChildren<Image>().color = Color.green;
            }
            else {
                StartCoroutine(displayWrongEffect());
            }
        }

        if (clear.ButtonDown) {
            inputString = "";
            textField.GetComponentInChildren<Text>().text = inputString;
        }
    }

    private IEnumerator displayWrongEffect() {
        textField.GetComponentInChildren<Image>().color = Color.red;
        yield return new WaitForSeconds(1f);
        inputString = "";
        textField.GetComponentInChildren<Text>().text = inputString;
        textField.GetComponentInChildren<Image>().color = new Color(r: 255, g: 255, b: 255, a: 100);
    }
}

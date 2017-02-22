using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricBar : MonoBehaviour {

    public RectTransform powerTransform;
    public float CurrentHeadPower
    {
        get { return currentHeadPower; }
        set {
            currentHeadPower = value;
            HandleHeadth();
        }
    }
    public float CurrentColorPower
    {
        get { return currentColorPower; }
        set
        {
            currentColorPower = value;
            HandleHeadth();
        }
    }
    public float CurrentTailPower
    {
        get { return currentTailPower; }
        set
        {
            currentTailPower = value;
            HandleHeadth();
        }
    }

    public Text powerText;
    public Image visualPower;

    private float cachedY;
    private float cachedZ;
    private float minXValue;
    private float maxXValue;
    private float currentHeadPower;
    private float currentColorPower;
    private float currentTailPower;
    private int maxPower;

    // Use this for initialization
    void Start () {
        cachedY = powerTransform.position.y;
        cachedZ = powerTransform.position.z;
        maxXValue = powerTransform.position.x;
        minXValue = powerTransform.position.x - powerTransform.rect.width;
        maxPower = 100;
        currentHeadPower = 0f;
        currentColorPower = 0f;
        currentTailPower = 0f;
        HandleHeadth();

    }
	
	// Update is called once per frame
	void Update () {

    }

    private void HandleHeadth() {

        float curPower = currentHeadPower + currentColorPower + currentTailPower;

        powerText.text = "Power: " + (int)curPower;

        float currentXValue = MapValues(curPower, 0, maxPower, minXValue, maxXValue);

        powerTransform.position = new Vector3(currentXValue, cachedY, cachedZ);

        if (curPower > maxPower / 2)
        {
            visualPower.color = new Color32((byte)MapValues(curPower, maxPower/2, maxPower, 255, 0), 255, 0, 255);
        }
        else {
            visualPower.color = new Color32(255, (byte)MapValues(curPower, 0, maxPower/2, 0, 255), 0, 255);
        }
    }

    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax) {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}

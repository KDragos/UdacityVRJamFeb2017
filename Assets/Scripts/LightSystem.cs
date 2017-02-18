using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class LightSystem : MonoBehaviour {

    public NVRSwitch nvrSwitch;
    public GameObject invisiableChart;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nvrSwitch.CurrentState)
        {
            RenderSettings.ambientIntensity = 1;
            RenderSettings.reflectionIntensity = 1;
            invisiableChart.GetComponent<Animator>().Play("Default");
        }
        else {
            RenderSettings.ambientIntensity = 0;
            RenderSettings.reflectionIntensity = 0;
            invisiableChart.GetComponent<Animator>().Play("ChartAppear");
        }
    }

}

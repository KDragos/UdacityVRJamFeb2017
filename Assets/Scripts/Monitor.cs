using System.Collections;
using System.Collections.Generic;
using NewtonVR;
using UnityEngine;

public class Monitor : MonoBehaviour {

    public NVRButton Button;
    public GameObject MonitorContent;
    public GameObject IndicatorLight;
    public GameObject PowerAdapter;

    private NVRAttachPoint attachPointScript;

    private void Start()
    {
        attachPointScript = PowerAdapter.GetComponent<NVRAttachPoint>();
    }

    private void Update()
    {
        if (attachPointScript.IsAttached)
        {
            Material greenMaterial = Resources.Load("Materials/greenlight", typeof(Material)) as Material;
            IndicatorLight.GetComponent<Renderer>().material = greenMaterial;
        }

        if (Button.ButtonDown && attachPointScript.IsAttached)
        {
            Material contentMaterial = Resources.Load("Materials/monitorcontent", typeof(Material)) as Material;
            MonitorContent.GetComponent<Renderer>().material = contentMaterial;
        }
    }
}

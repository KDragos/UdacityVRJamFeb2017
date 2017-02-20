using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class KnobControl : MonoBehaviour { 

    public NVRInteractableItem headKnob;
    public NVRInteractableItem colorKnob;
    public NVRInteractableItem tailKnob;

    public TextMesh headText;
    public TextMesh colorText;
    public TextMesh tailText;

    public ParticleSystem headParticle;
    public ParticleSystem colorParticle;
    public ParticleSystem tailParticle;

    public GameObject eel;

    private int lastHeadAngle = 360;
    private int lastColorAngle = 360;
    private int lastTailAngle = 360;

    private void Awake()
    {
        
    }

    private void Update()
    {

        int headKnobAngle = (int)headKnob.transform.localEulerAngles.y;
        int colorKnobAngle = (int)colorKnob.transform.localEulerAngles.y;
        int tailKnobAngle = (int)tailKnob.transform.localEulerAngles.y;

        updateKnobText(headKnobAngle, colorKnobAngle, tailKnobAngle);

        updateParticleSystem(headKnobAngle, colorKnobAngle, tailKnobAngle);

    }

    private void updateKnobText(int headAngle, int colorAngle, int tailAngle) {

        if (headAngle == 0)
        {
            headText.text = 0.ToString();
        }
        else
        {
            headText.text = ((360 - headAngle) / 36).ToString();
        }

        if (colorAngle == 0)
        {
            colorText.text = 0.ToString();
        }
        else
        {
            colorText.text = ((360 - colorAngle) / 36).ToString();
        }

        if (tailAngle == 0)
        {
            tailText.text = 0.ToString();
        }
        else
        {
            tailText.text = ((360 - tailAngle) / 36).ToString();
        }

    }

    private void updateParticleSystem(int headAngle, int colorAngle, int tailAngle) {

        if (headAngle != lastHeadAngle)
        {
            headParticle.Play();
            lastHeadAngle = headAngle;
        }
        else {
            headParticle.Stop();
            if (headParticle.isStopped)
            {
                StartCoroutine(updateEelHead(headAngle));
            }
        }

        if (colorAngle != lastColorAngle)
        {
            colorParticle.Play();
            lastColorAngle = colorAngle;
        }
        else
        {
            colorParticle.Stop();
            if (colorParticle.isStopped)
            {
                StartCoroutine(updateEelColor(colorAngle));
            }
        }

        if (tailAngle != lastTailAngle)
        {
            tailParticle.Play();
            lastTailAngle = tailAngle;
        }
        else
        {
            tailParticle.Stop();
        }
    }

    private IEnumerator updateEelHead(float headAngle)
    {
        int head = (int)((360 - headAngle) / 36);

        yield return new WaitForSeconds(1);

        switch (head)
        {
            case 0:
                eel.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                break;
            case 1:
                eel.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                break;
            case 2:
                eel.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                break;
            case 3:
                eel.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                break;
            case 4:
                eel.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                break;
            case 5:
                eel.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                break;
            case 6:
                eel.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                break;
            case 7:
                eel.transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);
                break;
            case 8:
                eel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 9:
                eel.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
                break;
        }
    }

    private IEnumerator updateEelColor(float colorAngle) {
        int color = (int)((360 - colorAngle) / 36);
        yield return new WaitForSeconds(1);

        switch (color)
        {
            case 0:
                eel.GetComponent<Renderer>().material.color = Color.cyan;
                break;
            case 1:
                eel.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 2:
                eel.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 3:
                eel.GetComponent<Renderer>().material.color = Color.black;
                break;
            case 4:
                eel.GetComponent<Renderer>().material.color = Color.white;
                break;
            case 5:
                eel.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 6:
                eel.GetComponent<Renderer>().material.color = Color.gray;
                break;
            case 7:
                eel.GetComponent<Renderer>().material.color = Color.grey;
                break;
            case 8:
                eel.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 9:
                eel.GetComponent<Renderer>().material.color = Color.magenta;
                break;
        }
    }

    private IEnumerator updateEelTail(float tailAngle)
    {
        int tail = (int)((360 - tailAngle) / 36);

        yield return new WaitForSeconds(1);
    }
}

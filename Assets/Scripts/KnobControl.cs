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
    public GameObject electricBar;

    private int lastHeadAngle = 360;
    private int lastColorAngle = 360;
    private int lastTailAngle = 360;

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
                updateEelHead(headAngle);
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
                updateEelColor(colorAngle);
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
            if(tailParticle.isStopped)
            {
                updateEelTail(tailAngle);
            }
        }
    }

    private void updateEelHead(float headAngle)
    {
        int head = (int)((360 - headAngle) / 36);

        //yield return new WaitForSeconds(1);

        switch (head)
        {
            case 0:
                eel.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                if (electricBar.GetComponent<ElectricBar>().CurrentHeadPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentHeadPower -= 0.1f;
                }
                break;
            case 1:
                eel.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                if (electricBar.GetComponent<ElectricBar>().CurrentHeadPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentHeadPower -= 0.1f;
                }
                break;
            case 2:
                eel.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                if (electricBar.GetComponent<ElectricBar>().CurrentHeadPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentHeadPower -= 0.1f;
                }
                break;
            case 3:
                eel.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                if (electricBar.GetComponent<ElectricBar>().CurrentHeadPower < 33) {
                    electricBar.GetComponent<ElectricBar>().CurrentHeadPower += 0.1f;
                }
                break;
            case 4:
                eel.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                if (electricBar.GetComponent<ElectricBar>().CurrentHeadPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentHeadPower -= 0.1f;
                }
                break;
            case 5:
                eel.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                if (electricBar.GetComponent<ElectricBar>().CurrentHeadPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentHeadPower -= 0.1f;
                }
                break;
            case 6:
                eel.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                if (electricBar.GetComponent<ElectricBar>().CurrentHeadPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentHeadPower -= 0.1f;
                }
                break;
            case 7:
                eel.transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);
                if (electricBar.GetComponent<ElectricBar>().CurrentHeadPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentHeadPower -= 0.1f;
                }
                break;
            case 8:
                eel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                if (electricBar.GetComponent<ElectricBar>().CurrentHeadPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentHeadPower -= 0.1f;
                }
                break;
            case 9:
                eel.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
                if (electricBar.GetComponent<ElectricBar>().CurrentHeadPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentHeadPower -= 0.1f;
                }
                break;
        }
    }

    private void updateEelColor(float colorAngle) {
        int color = (int)((360 - colorAngle) / 36);
        //yield return new WaitForSeconds(1);

        switch (color)
        {
            case 0:
                eel.GetComponent<Renderer>().material.color = Color.cyan;
                if (electricBar.GetComponent<ElectricBar>().CurrentColorPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentColorPower -= 0.1f;
                }
                break;
            case 1:
                eel.GetComponent<Renderer>().material.color = Color.red;
                if (electricBar.GetComponent<ElectricBar>().CurrentColorPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentColorPower -= 0.1f;
                }
                break;
            case 2:
                eel.GetComponent<Renderer>().material.color = Color.blue;
                if (electricBar.GetComponent<ElectricBar>().CurrentColorPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentColorPower -= 0.1f;
                }
                break;
            case 3:
                eel.GetComponent<Renderer>().material.color = Color.black;
                if (electricBar.GetComponent<ElectricBar>().CurrentColorPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentColorPower -= 0.1f;
                }
                break;
            case 4:
                eel.GetComponent<Renderer>().material.color = Color.white;
                if (electricBar.GetComponent<ElectricBar>().CurrentColorPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentColorPower -= 0.1f;
                }
                break;
            case 5:
                eel.GetComponent<Renderer>().material.color = Color.yellow;
                if (electricBar.GetComponent<ElectricBar>().CurrentColorPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentColorPower -= 0.1f;
                }
                break;
            case 6:
                eel.GetComponent<Renderer>().material.color = Color.green;
                if (electricBar.GetComponent<ElectricBar>().CurrentColorPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentColorPower -= 0.1f;
                }
                break;
            case 7:
                eel.GetComponent<Renderer>().material.color = Color.gray;
                if (electricBar.GetComponent<ElectricBar>().CurrentColorPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentColorPower -= 0.1f;
                }
                break;
            case 8:
                eel.GetComponent<Renderer>().material.color = Color.grey;
                if (electricBar.GetComponent<ElectricBar>().CurrentColorPower < 33)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentColorPower += 0.1f;
                }
                break;
            case 9:
                eel.GetComponent<Renderer>().material.color = Color.magenta;
                if (electricBar.GetComponent<ElectricBar>().CurrentColorPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentColorPower -= 0.1f;
                }
                break;
        }
    }

    private void updateEelTail(float tailAngle)
    {
        int tail = (int)((360 - tailAngle) / 36);

        //yield return new WaitForSeconds(1);

        switch (tail)
        {
            case 0:
                if (electricBar.GetComponent<ElectricBar>().CurrentTailPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentTailPower -= 0.1f;
                }
                break;
            case 1:
                if (electricBar.GetComponent<ElectricBar>().CurrentTailPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentTailPower -= 0.1f;
                }
                break;
            case 2:
                if (electricBar.GetComponent<ElectricBar>().CurrentTailPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentTailPower -= 0.1f;
                }
                break;
            case 3:
                if (electricBar.GetComponent<ElectricBar>().CurrentTailPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentTailPower -= 0.1f;
                }
                break;
            case 4:
                if (electricBar.GetComponent<ElectricBar>().CurrentTailPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentTailPower -= 0.1f;
                }
                break;
            case 5:
                if (electricBar.GetComponent<ElectricBar>().CurrentTailPower < 34)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentTailPower += 0.1f;
                }
                break;
            case 6:
                if (electricBar.GetComponent<ElectricBar>().CurrentTailPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentTailPower -= 0.1f;
                }
                break;
            case 7:
                if (electricBar.GetComponent<ElectricBar>().CurrentTailPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentTailPower -= 0.1f;
                }
                break;
            case 8:
                if (electricBar.GetComponent<ElectricBar>().CurrentTailPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentTailPower -= 0.1f;
                }
                break;
            case 9:
                if (electricBar.GetComponent<ElectricBar>().CurrentTailPower > 0)
                {
                    electricBar.GetComponent<ElectricBar>().CurrentTailPower -= 0.1f;
                }
                break;
        }
    }
}

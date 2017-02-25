using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class PlantSystem : MonoBehaviour {

    public NVRButton fireButton;
    public ParticleSystem fireParticle;
    public GameObject firstPastPlant;
    public GameObject firstPot;
    public GameObject firstSeed;
    public GameObject firstFertilizer;
    public GameObject firstWaterTube;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (firstPot.GetComponent<FirstPotScript>().isCorrectSeedAndFertilizer() == FirstPotScript.Status.Correct) {
            foreach (GameObject obj in firstPot.GetComponent<FirstPotScript>().getObjectsInPot()) {
                Destroy(obj);
            }
            firstPot.GetComponent<FirstPotScript>().deleteSeedAndFertilizerInObjects();
            StartCoroutine(growLittlePlant());
        }

        // Press Button and Play Fire Particle
        if (fireButton.ButtonDown && firstPastPlant.activeSelf)
        {
            StartCoroutine(destoryLittlePlant());
        }
    }

    private IEnumerator growLittlePlant()
    {
        firstWaterTube.GetComponentsInChildren<ParticleSystem>()[0].Play();
        firstWaterTube.GetComponentsInChildren<ParticleSystem>()[1].Play();

        yield return new WaitForSeconds(2);

        if (firstWaterTube.GetComponentsInChildren<ParticleSystem>()[0].isPlaying) {
            firstWaterTube.GetComponentsInChildren<ParticleSystem>()[0].Stop();
            firstWaterTube.GetComponentsInChildren<ParticleSystem>()[1].Stop();
            firstPastPlant.SetActive(true);
        }
    }

    private IEnumerator destoryLittlePlant() {
        fireParticle.Play();

        yield return new WaitForSeconds(2);

        if (fireParticle.isPlaying) {
            fireParticle.Stop();
            firstPastPlant.SetActive(false);
        }
    }
}

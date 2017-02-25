using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class FirstPotScript : MonoBehaviour {

    public NVRButton firstFireButton;
    public ParticleSystem firstFireParticle;
    public GameObject firstPastPlant;
    public GameObject firstWaterTube;
    public GameObject firstFuturePlant;

    public enum Status { Empty, Correct, Wrong};
    private List<GameObject> objects = new List<GameObject>();
    private int seedPos = 0;
    private int fertilizerPos = 0;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(objects.Count);

        if (isCorrectSeedAndFertilizer() == Status.Correct)
        {
            foreach (GameObject obj in objects)
            {
                Destroy(obj);
            }
            emptyObjectsInObjects();
            StartCoroutine(growLittlePlant());
        }else if (isCorrectSeedAndFertilizer() == Status.Wrong)
        {
            foreach (GameObject obj in objects)
            {
                Destroy(obj);
            }
            emptyObjectsInObjects();
            StartCoroutine(growLittlePlant());
        }

        // Press Button and Play Fire Particle
        if (firstFireButton.ButtonDown)
        {
            StartCoroutine(destoryLittlePlant());
        }

    }

    public Status isCorrectSeedAndFertilizer()
    {
        if (objects.Count == 0) {
            return Status.Empty;
        }

        int count = 0;
        bool hasSeed = false;
        bool hasFertilizer = false;
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject tempObj = objects[i];
            if (tempObj.name.Contains("FirstSeed") && !hasSeed)
            {
                count++;
                seedPos = i;
                hasSeed = true;
            }else if (tempObj.name.Contains("Seed") && !hasSeed) 
            {
                count += 5;
                seedPos = i;
                hasSeed = true;
            }

            if (tempObj.name.Contains("FirstFertilizer") && !hasFertilizer)
            {
                count++;
                fertilizerPos = i;
                hasFertilizer = true;
            }
            else if (tempObj.name.Contains("Fertilizer") && !hasFertilizer)
            {
                count += 5;
                fertilizerPos = i;
                hasFertilizer = true;
            }

            if (count == 2 || count == 7 || count == 10)
            {
                break;
            }
        }

        if (count == 2) {
            return Status.Correct;
        } else if (count == 3 || count == 4) {
            return Status.Wrong;
        }

        return Status.Empty;
    }

    public List<GameObject> getObjectsInPot() {
        return objects;
    }

    public void emptyObjectsInObjects() {
        objects.Clear();
    }

    public void deleteSeedAndFertilizerInObjects() {
        objects.RemoveAt(seedPos);
        objects.RemoveAt(fertilizerPos);
    }

    private IEnumerator growLittlePlant()
    {
        firstWaterTube.GetComponentsInChildren<ParticleSystem>()[0].Play();
        firstWaterTube.GetComponentsInChildren<ParticleSystem>()[1].Play();

        yield return new WaitForSeconds(2);

        if (firstWaterTube.GetComponentsInChildren<ParticleSystem>()[0].isPlaying)
        {
            firstWaterTube.GetComponentsInChildren<ParticleSystem>()[0].Stop();
            firstWaterTube.GetComponentsInChildren<ParticleSystem>()[1].Stop();
            firstPastPlant.SetActive(true);
        }
    }

    private IEnumerator destoryLittlePlant()
    {
    
        firstFireParticle.Play();

        yield return new WaitForSeconds(2);

        if (firstFireParticle.isPlaying)
        {
            firstFireParticle.Stop();
            if (firstPastPlant.activeSelf)
            {
                firstPastPlant.SetActive(false);
            }
            foreach (GameObject obj in objects)
            {
                Destroy(obj);
            }
            emptyObjectsInObjects();
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Seed" || other.tag == "Fertilizer") {
    //        if (!objects.Contains(other.gameObject)) {
    //            objects.Add(other.gameObject);
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Seed" || other.tag == "Fertilizer")
        {
            if (!objects.Contains(other.gameObject))
            {
                objects.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject temp = objects[i];
            if (temp.Equals(other.gameObject))
            {
                objects.RemoveAt(i);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGen : MonoBehaviour
{
    bool inSac = true;
    public GameObject carObjLeft;
    public GameObject carObjRight;
    bool generating = false;
    bool lerpFog = false;

    static float t = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!inSac && !generating)
        {
            StartCoroutine(CarTimer());
        }
        if (lerpFog)
        {
            LerpFog();
        }
    }

    void GenerateACar() {
        int dir = Random.Range(0, 2);
        if (dir == 1) {
            GameObject newCar = Instantiate(carObjLeft);
            newCar.transform.position = new Vector3(0, 1.2f, transform.position.z + 100f);
            newCar.GetComponent<CarMove>().dir = dir;
        }
        else
        {
            GameObject newCar = Instantiate(carObjRight);
            newCar.transform.position = new Vector3(0, 1.2f, transform.position.z + 100f);
            newCar.GetComponent<CarMove>().dir = dir;
        }
        
        generating = false;
    }

    IEnumerator CarTimer()
    {
        generating = true;
        int waitTime = Random.Range(5, 15);
        yield return new WaitForSeconds(waitTime);
        GenerateACar();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "sac")
        {
            inSac = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "sac")
        {
            inSac = true;
        }
        if (other.gameObject.name == "WalZone")
        {
            inSac = true;
            //Camera.main.farClipPlane = 100f;
            //RenderSettings.fogDensity = 0.01f;
            lerpFog = true;
        }
    }

    void LerpFog() {
        float currFog = RenderSettings.fogDensity;
        t += 0.1f * Time.deltaTime;
        RenderSettings.fogDensity = Mathf.Lerp(currFog, 0.01f, t);
        Debug.Log(RenderSettings.fogDensity);
        if (RenderSettings.fogDensity <= 0.015f)
        {
            lerpFog = false;
        }
    }
}

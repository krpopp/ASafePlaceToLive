using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullDistant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = GetComponent<Camera>();
        float[] distances = new float[32];
        distances[6] = 300;
        camera.layerCullDistances = distances;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

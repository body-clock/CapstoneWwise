using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensityFlicker : MonoBehaviour
{
    public float timeScale;

    private Light myLight;
    private float t = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * timeScale;

        myLight.intensity = Mathf.PerlinNoise(t, transform.position.y);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoomTrigger : MonoBehaviour
{

    public GameObject loom;

    private Vector3 startPos;

    public Vector3 endPos;

    private float t;

    public float emergeTime;

    private bool emerging;

    private bool fullyLit;
    public int numLights;

    public bool[] lights;
    public PathPillar[] path;


    
    // Start is called before the first frame update
    void Start()
    {
        startPos = loom.transform.position;
        lights = new bool[numLights];
    }

    // Update is called once per frame
    void Update()
    {
        fullyLit = true;
        for (int i = 0; i < numLights; i++)
        {
            if (!lights[i])
            {
                fullyLit = false;
                break;
            }
        }


        if (emerging)
        {
            t += Time.deltaTime / emergeTime;

            loom.transform.position = Vector3.Lerp(startPos, endPos, t);
        }

        if (Vector3.Distance(loom.transform.position, endPos) < 0.1f)
        {
            Destroy(transform.gameObject);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player") && fullyLit)
        {
            emerging = true;
            for (int i = 0; i < path.Length; i++)
            {
                path[i].readyToEmerge = true;
            }
        }
    }
    
}

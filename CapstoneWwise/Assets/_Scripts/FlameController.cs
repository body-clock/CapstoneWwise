using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{

    private Camera activeCam;

    private Vector3 startPos;

    void Start()
    {
        activeCam = Camera.main;
        startPos = transform.forward;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(activeCam.transform.position);
    }
}

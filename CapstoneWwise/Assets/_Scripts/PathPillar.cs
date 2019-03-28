using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPillar : MonoBehaviour
{

    private Vector3 startPos;

    private Vector3 endPos;

    private float t;

    public float emergeTime;

    private bool emerging;

    public bool readyToEmerge;
    
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x, startPos.y + 6.25f, startPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (emerging)
        {
            t += Time.deltaTime / emergeTime;

            transform.position = Vector3.Lerp(startPos, endPos, t);
        }
        
        if (Vector3.Distance(transform.position, endPos) < 0.1f)
        {
            emerging = false;
        }
    }
    
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player") && readyToEmerge)
        {
            emerging = true;
        }
    }
}

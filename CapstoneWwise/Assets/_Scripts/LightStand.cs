using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStand : MonoBehaviour
{

    public bool isLit;
    public bool canLight;

    public GameObject myLight;
    public LoomTrigger nextLoomTrigger;
    public TestAnimation objAnim;

    public int idx;

    public AK.Wwise.Event Candle_Strike_Event;

    // Update is called once per frame
    void Update()
    {
        if (!isLit && canLight && Input.GetKeyDown(KeyCode.E))
        {
            myLight.SetActive(true);
            Candle_Strike_Event.Post(gameObject);
            isLit = true;
            nextLoomTrigger.lights[idx] = true;
            StartCoroutine(objAnim.startAnimation());
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            canLight = true;
            
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            canLight = false;
        }
    }
}

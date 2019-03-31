using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Loom1Completion : MonoBehaviour
{
    public bool ready;

    public FirstPersonController playerController;

    public Transform[] cutPositions;
    public float[] cutWaitTimes;

    public Transform[] flowPositions;
    public float[] flowLerpTimes;
    public AnimationCurve[] flowCurves;


    public GameObject playerCam;
    private Camera thisCam;

    void Start()
    {
        thisCam = GetComponent<Camera>();
        thisCam.enabled = false;
    }
    
    void Update()
    {
        if (ready)
        {
            thisCam.enabled = true;
            StartCoroutine(CameraCutscene());
            ready = false;
        }
    }

    IEnumerator CameraCutscene()
    {
        playerController.canWalk = false;
        playerCam.SetActive(false);

        for (int i = 0; i < cutPositions.Length; i++)
        {
            CameraCut(cutPositions[i]);
            yield return new WaitForSeconds(cutWaitTimes[i]);
        }
        CameraCut(flowPositions[0]);

        for (int i = 1; i < flowPositions.Length; i++)
        {
            float t = 0f;
            Transform startPos = flowPositions[i - 1];
            Transform endPos = flowPositions[i];
            while (t < 1f)
            {
                t += Time.deltaTime / flowLerpTimes[i];
                thisCam.transform.position = Vector3.Lerp(startPos.position, endPos.position, flowCurves[i].Evaluate(t));
                thisCam.transform.eulerAngles = Vector3.Lerp(startPos.eulerAngles, endPos.eulerAngles, t);
                yield return null;
            }
        }


        playerCam.SetActive(true);
        playerController.canWalk = true;
    }

    // for directly cutting from one camera position to another
    void CameraCut(Transform newPosition)
    {
        thisCam.transform.position = newPosition.position;
        thisCam.transform.forward = newPosition.forward;
    }

    // for lerping positions and rotations, etc
    void CameraTransition(Transform startPos, Transform endPos, float transitionTime)
    {
        
    }
}

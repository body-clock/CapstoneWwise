using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGhost : MonoBehaviour
{

    public float jumpStrength;
    public float ledgeWaitTime;
    public float runTime;
    public AnimationCurve runAnimationCurve;

    public Transform startPosTrans;
    public Transform divingBoardTrans;

    private Vector3 startPos;
    private Vector3 jumpPos;
    private Rigidbody rBody;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = startPosTrans.position;
        jumpPos = divingBoardTrans.position;
        rBody = GetComponent<Rigidbody>();
    }

    private float t;

    public IEnumerator JumpTutorial()
    {

        while (t <= 1f)
        {
            t += Time.deltaTime / runTime;
            transform.position = Vector3.Lerp(startPos, jumpPos, runAnimationCurve.Evaluate(t));
        }
        
        yield return new WaitForSeconds(ledgeWaitTime);
        rBody.AddForce((transform.up - transform.forward)*jumpStrength, ForceMode.Impulse);
        yield return new WaitForSeconds(3f);
        Destroy(transform.gameObject);
    }

    
}

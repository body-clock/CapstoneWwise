using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{


    public Animator cabinetAnimator;


    void Start()
    {
        cabinetAnimator.gameObject.SetActive(false);
    }

    

    public IEnumerator startAnimation()
    {
        yield return new WaitForSeconds(2f);
        cabinetAnimator.gameObject.SetActive(true);
        cabinetAnimator.SetBool("constructing", true);
    }
}

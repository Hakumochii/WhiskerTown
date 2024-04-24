using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environment : MonoBehaviour
{
    public Animator myAnimator;
 
    public void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
    }


    public void BeginAnimation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myAnimator.SetTrigger("Active");
        }
    }
}

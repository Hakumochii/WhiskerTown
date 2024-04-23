using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CatPickup : MonoBehaviour
{
    public Animator animator;
   void Start()
    {
        Animator animator = GetComponent<Animator>();
    }
   public void OnMouseDown(){
         animator.SetBool("isPickedUp", true);
   }

   public void OnMouseUp(){
         animator.SetBool("isPickedUp", false);
   }

    public void OnMouseDrag(){
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
  //code sky object that moves along the x axis to the left
    public float speed = 0.5f;
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }   


 //after reaching the end of the screen, the sky will reset to the beginning
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sky")
        {
            transform.position = new Vector2(0, 0);
        }
    }
    

}

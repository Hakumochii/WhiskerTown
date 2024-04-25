using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tumble : environment
{
     Rigidbody2D rb;
    float xMovement;
    float moveSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.acceleration.x * moveSpeed;
        transform.position = new Vector2 (Mathf.Clamp (transform.position.x, -20f, 20f), transform.position.y);
        BeginAnimation();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2 (xMovement, 0f);
    }
}

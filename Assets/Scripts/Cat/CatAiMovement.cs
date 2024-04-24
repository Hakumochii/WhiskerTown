using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CatAiMovement : MonoBehaviour
{
    internal Transform thisTransform;
    public Animator animator;
    private UnityEngine.Vector2 minBounds;
    private UnityEngine.Vector2 maxBounds;

    // The movement speed of the object
    public float moveSpeed = 0.2f;

    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    public UnityEngine.Vector2 decisionTime = new UnityEngine.Vector2(1, 4);
    internal float decisionTimeCount = 0;

    // The possible directions that the object can move in: right, left, up, down, and zero for staying in place.
    internal UnityEngine.Vector3[] moveDirections = new UnityEngine.Vector3[] { 
        UnityEngine.Vector3.right, 
        UnityEngine.Vector3.left, 
        UnityEngine.Vector3.up, 
        UnityEngine.Vector3.down, 
        UnityEngine.Vector3.zero, 
        UnityEngine.Vector3.zero };
    internal int currentMoveDirection;

    // Use this for initialization
    void Start()
    {
        // Cache the transform for quicker access
        thisTransform = transform;

        // Set a random time delay for taking a decision (changing direction, or standing in place for a while)
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);


        minBounds = Camera.main.ScreenToWorldPoint(UnityEngine.Vector2.zero); // Bottom-left corner of the screen
        maxBounds = Camera.main.ScreenToWorldPoint(new UnityEngine.Vector2(Screen.width, Screen.height)); 

        // Choose a movement direction, or stay in place
        ChooseMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object in the chosen direction at the set speed
        UnityEngine.Vector3 direction = moveDirections[currentMoveDirection];
        float xDir = direction.x;
        float yDir = direction.y;

        UnityEngine.Vector3 newPosition = thisTransform.position + direction * Time.deltaTime * moveSpeed;

        // Clamp the new position within the specified bounds
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        thisTransform.position = newPosition;

        if (animator)
        {
            animator.SetFloat("MoveX", xDir);
            animator.SetFloat("MoveY", yDir);
        }

        if (decisionTimeCount > 0)
            decisionTimeCount -= Time.deltaTime;
        else
        {
            // Choose a random time delay for taking a decision (changing direction, or standing in place for a while)
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

            // Choose a movement direction, or stay in place
            ChooseMoveDirection();
        }
    }

    void ChooseMoveDirection()
    {
        // Choose whether to move sideways or up/down
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
    }
}

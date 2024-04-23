using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAiMovement : MonoBehaviour
{
    internal Transform thisTransform;
    public Animator animator;

    // The movement speed of the object
    public float moveSpeed = 0.2f;

    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    public Vector2 decisionTime = new Vector2(1, 4);
    internal float decisionTimeCount = 0;

    // The possible directions that the object can move in: right, left, up, down, and zero for staying in place.
    internal Vector3[] moveDirections = new Vector3[] { 
        Vector3.right, 
        Vector3.left, 
        Vector3.up, 
        Vector3.down, 
        Vector3.zero, 
        Vector3.zero };
    internal int currentMoveDirection;

    // Define the boundaries of the movement area
    public Vector2 minBounds = new Vector2(-5, -5); // Example minimum bounds
    public Vector2 maxBounds = new Vector2(5, 5);   // Example maximum bounds

    // Use this for initialization
    void Start()
    {
        // Cache the transform for quicker access
        thisTransform = transform;

        // Set a random time delay for taking a decision (changing direction, or standing in place for a while)
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

        // Choose a movement direction, or stay in place
        ChooseMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object in the chosen direction at the set speed
        Vector3 direction = moveDirections[currentMoveDirection];
        float xDir = direction.x;
        float yDir = direction.y;

        Vector3 newPosition = thisTransform.position + direction * Time.deltaTime * moveSpeed;

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

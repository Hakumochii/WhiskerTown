using Unity.VisualScripting;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public Animator animator;
    public CatAiMovement catAiMovement;

    Vector2 touchStartPos;
    Vector2 touchEndPos;
    float minPetDistance = 4f; // Adjust as needed
    float maxPetTime = 10f; // Adjust as needed
    float touchStartTime;

    bool isBeingPetted = false;
    bool isBeingDragged = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        catAiMovement = GetComponent<CatAiMovement>();
    }

    void Update()
    {
        if (!isBeingPetted && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    touchStartTime = Time.time;
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    touchEndPos = touch.position;
                    CheckPet();
                    break;
            }
        }
    }

    void CheckPet()
    {
        float petDistance = (touchEndPos - touchStartPos).magnitude;
        float petTime = Time.time - touchStartTime;

        if (petDistance < minPetDistance && petTime < maxPetTime && !isBeingDragged)
        {
            PetCat();
        }
    }

    public void PetCat()
    {
        animator.SetBool("isPet", true);
        catAiMovement.enabled = false;
        isBeingPetted = true;
        animator.SetFloat("MoveX", 0);
        animator.SetFloat("MoveY", 0);

        Invoke("EndPetting", 2f);
    }

    public void EndPetting()
    {
        animator.SetBool("isPet", false);
        catAiMovement.enabled = true;
        isBeingPetted = false;
    }

    public void OnMouseDown()
    {
        animator.SetBool("isPickedUp", true);
        catAiMovement.enabled = false;
        animator.SetFloat("MoveX", 0);
        animator.SetFloat("MoveY", 0);
        isBeingDragged = true;
    }

    public void OnMouseUp()
    {
        animator.SetBool("isPickedUp", false);
        catAiMovement.enabled = true;
        isBeingDragged = false;
    }

    public void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}

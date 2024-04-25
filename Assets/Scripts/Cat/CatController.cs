using UnityEngine;

public class CatController : MonoBehaviour
{
    public Animator animator;
    public CatAiMovement catAiMovement;
    AudioManager audioManager;
    Vector2 touchStartPos;
    Vector2 touchEndPos;
    float minPetDistance = 1f; // Adjust as needed
    float maxPetTime = 5f; // Adjust as needed
    float touchStartTime;

    bool isBeingPetted = false;
    bool isBeingDragged = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        catAiMovement = GetComponent<CatAiMovement>();

        // Store the initial state of the cat
        animator.SetBool("isLayingDown", animator.GetBool("isLayingDown"));
        animator.SetBool("isStanding", animator.GetBool("isStanding"));
        animator.SetBool("isPet", animator.GetBool("isPet"));
    }

    void Update()
    {
        if (!isBeingPetted && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log("Touch phase: " + touch.phase);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    touchStartTime = Time.time;
                    CheckPet(touchStartPos);
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    touchEndPos = touch.position;
                    break;
            }
        }
    }

    void CheckPet(Vector2 touchPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touchPos), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            // Cat touched, start petting logic
            float petDistance = (touchEndPos - touchStartPos).magnitude;
            float petTime = Time.time - touchStartTime;
            if (petDistance < minPetDistance && petTime < maxPetTime && !isBeingDragged)
            {
                PetCat();
            }
        }
    }

    public void PetCat()
    {
        Debug.Log("Petting cat");
        animator.SetBool("isPet", true); // Set pet animation parameter to true
        AudioManager.instance.PlayAudio("event:/cat_sounds/Pet");
        catAiMovement.enabled = false;
        isBeingPetted = true;

        // Invoke EndPetting after the pet animation duration
        float pettingDuration = 3f; // Adjust as needed based on your petting animation duration
        Invoke("EndPetting", pettingDuration);
    }

    public void EndPetting()
    {
        animator.SetBool("isPet", false); // Reset pet animation parameter to false
        catAiMovement.enabled = true;
        isBeingPetted = false;
    }

    public void OnMouseDown()
    {
        if (!isBeingPetted)
        {
            AudioManager.instance.PlayAudio("event:/cat_sounds/Meow");
            animator.SetBool("isPickedUp", true);
            animator.SetBool("isLayingDown", false);
            animator.SetBool("isStanding", true);
            catAiMovement.enabled = false;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
            isBeingDragged = true;
        }
    }

    public void OnMouseUp()
    {
        animator.SetBool("isPickedUp", false);
        catAiMovement.enabled = true;
        isBeingDragged = false;
    }

    public void OnMouseDrag()
    {
        if (!isBeingPetted)
        {
            animator.SetBool("isPickedUp", true);
            catAiMovement.enabled = false;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
            isBeingDragged = true;
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }
}

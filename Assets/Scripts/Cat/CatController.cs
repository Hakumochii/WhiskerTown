using UnityEngine;

public class CatController : MonoBehaviour
{
    public Animator animator;
    public CatAiMovement catAiMovement;
    AudioManager audioManager;
    Vector2 touchStartPos;
    Vector2 touchEndPos;
    float minPetDistance = 3f; // Adjust as needed
    float maxPetTime = 5f; // Adjust as needed
    float touchStartTime;

    bool isBeingPetted = false;
    bool isBeingDragged = false;

    // Store the initial state of the cat
    bool initialIsLayingDown;
    bool initialIsStanding;
    bool initialIsPet;

    void Start()
    {
        animator = GetComponent<Animator>();
        catAiMovement = GetComponent<CatAiMovement>();

        // Store the initial state of the cat
        initialIsLayingDown = animator.GetBool("isLayingDown");
        initialIsStanding = animator.GetBool("isStanding");
        initialIsPet = animator.GetBool("isPet");
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
        if (animator.GetBool("isPickedUp"))
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
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

        // Invoke EndPetting after the pet animation duration
        float pettingDuration = 3f;
        Invoke("EndPetting", pettingDuration);
}

    public void EndPetting()
    {
        animator.SetBool("isPet", false);
        catAiMovement.enabled = true;
        isBeingPetted = false;
        // Reset the cat to its original state
        animator.SetBool("isLayingDown", initialIsLayingDown);
        animator.SetBool("isStanding", initialIsStanding);
    }

    public void OnMouseDown()
    {
    
        if(!isBeingPetted)
        {
            AudioManager.instance.PlayAudio("event:/cat_sounds/Meow");
            animator.SetBool("isPickedUp", true);
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
        if(!isBeingPetted)
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

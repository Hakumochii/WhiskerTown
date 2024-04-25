using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject Musling;
    public GameObject Pusling;
    public GameObject Misling;

    public GameObject[] muslingSprites = new GameObject[16];
    public GameObject[] puslingSprites = new GameObject[9];
    public GameObject[] mislingSprites = new GameObject[18];

    public void Start()
    {
        Musling.SetActive(false);
        Pusling.SetActive(false);

    }
    public void MuslingClick()
    {
        Debug.Log(Musling.activeInHierarchy);
        switch (Musling.activeInHierarchy)
        {
            case true:
                Debug.Log("Musling is already chosen");
                break;
            case false:
                if (Pusling.activeInHierarchy)
                {
                    ResetColorsPusling();
                    Pusling.SetActive(false);
                    Musling.SetActive(true);
                }
                else if(Misling.activeInHierarchy)
                {
                    ResetColorsMisling();
                    Misling.SetActive(false);
                    Musling.SetActive(true);
                }

                


                else if (!Pusling.activeInHierarchy || !Misling.activeInHierarchy)
                {
                    Musling.SetActive(true);
                }
                break;
        }
    }

    public void PuslingClick()
    {
        switch (Pusling.activeInHierarchy)
        {
            case true:
                Debug.Log("Pusling is already chosen");
                break;
            case false:
                if (Musling.activeInHierarchy || Misling.activeInHierarchy)
                {
                    ResetColorsMusling();
                    Musling.SetActive(false);
                    ResetColorsMisling();
                    Misling.SetActive(false);
                    Pusling.SetActive(true);
                }
                else if (!Musling.activeInHierarchy || !Misling.activeInHierarchy)
                {
                    Pusling.SetActive(true);
                }
                break;
        }
    }

    public void MislingClick()
    {
        switch (Misling.activeInHierarchy)
        {
            case true:
                Debug.Log("Misling is already chosen");
                break;
            case false:
                if (Musling.activeInHierarchy || Pusling.activeInHierarchy)
                {
                    ResetColorsMusling();
                    Musling.SetActive(false);
                    ResetColorsPusling();
                    Pusling.SetActive(false);
                    Misling.SetActive(true);
                }
                else if (!Musling.activeInHierarchy || !Pusling.activeInHierarchy)
                {
                    Misling.SetActive(true);
                }

                break;
        }
    }

    public void ResetColorsMusling()
    {
        foreach (GameObject obj in muslingSprites)
        {
            if (obj != null)
            {
                // Get the Renderer component of the GameObject
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    // Change the color to white
                    spriteRenderer.color = Color.white;
                    Debug.Log(obj.name + "Has changed color to" + spriteRenderer.material.color);
                }
                else
                {
                    Debug.LogWarning("Renderer component not found on GameObject: " + obj.name);
                }
            }
            else
            {
                Debug.LogWarning("Null GameObject found in the array!");
            }
        }
    }

    public void ResetColorsMisling()
    {
        Misling.SetActive(false);
        foreach (GameObject obj in mislingSprites)
        {
            if (obj != null)
            {
                // Get the Renderer component of the GameObject
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    // Change the color to white
                    spriteRenderer.color = Color.white;
                    Debug.Log(obj.name + "Has changed color to" + spriteRenderer.material.color);
                }
                else
                {
                    Debug.LogWarning("Renderer component not found on GameObject: " + obj.name);
                }
            }
            else
            {
                Debug.LogWarning("Null GameObject found in the array!");
            }
        }
    }

    public void ResetColorsPusling()
    {
        Pusling.SetActive(false);
        foreach (GameObject obj in puslingSprites)
        {
            if (obj != null)
            {
                // Get the Renderer component of the GameObject
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    // Change the color to white
                    spriteRenderer.color = Color.white;
                    Debug.Log(obj.name + "Has changed color to" + spriteRenderer.material.color);
                    Debug.Log("Color has changes");
                }
                else
                {
                    Debug.LogWarning("Renderer component not found on GameObject: " + obj.name);
                }
            }
            else
            {
                Debug.LogWarning("Null GameObject found in the array!");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatManager : MenuManager
{   
    // Initialize arrays
    GameObject[] chosenCat = null;
    Color[] chosencolors = null; 
    GameObject catobject = null;
    int currentcolor = 1; 

    void OnButtonClicked()
    {
        // Check which cat is active
        if (Musling.activeSelf)
        {
            chosenCat = muslingSprites; // Assuming muslingSprites is an array of Sprites
            catobject = Musling;
        }
        else if (Misling.activeSelf)
        {
            chosenCat = mislingSprites; // Assuming mislingSprites is an array of Sprites
            catobject = Misling;
        }
        else if (Pusling.activeSelf)
        {
            chosenCat = puslingSprites; // Assuming puslingSprites is an array of Sprites
            catobject = Pusling;
        }
        else
        {
            Debug.Log("No cat chosen");
            return; // Exit the method if no cat is chosen
        }

        // Apply colors to the sprites
        for (int i = 0; i < chosenCat.Length; i++)
        {
            catobject.GetComponent<SpriteRenderer>().color = chosencolors[i];
        }

        // Instantiate a new cat object (assuming you want to clone the selected cat)
        GameObject newCatObject = Instantiate(catobject, Vector3.zero, Quaternion.identity);

        // Set colors for the new cat object
        SpriteRenderer[] spriteRenderers = newCatObject.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].color = chosencolors[currentcolor];
            currentcolor += 1;
        }

        debug.log("New cat object instantiated");

    }
}  

//when the "done" button is pressed in the "NewColorScene",  check If musling, pusling or misling has been chosen and if one have been chosen check its children spriterendere and the color of that and instantiate a new version in the "StickerColor" scene


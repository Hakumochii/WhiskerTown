using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatManager : MonoBehaviour
{
    public GameObject chosenCat;
    public List<Color> chosenColors;

    public void OnDoneButtonPressed()
    {
        // Instantiate chosenCat and apply chosenColors in the "stickerscroll" scene
        SceneManager.LoadScene("StickerScroll");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingApperence : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] cowboyHats;
    private int selectedHatIndex = -1;

    private void Start()
    {
        // Initialize all cowboy hats to false
        foreach (GameObject hat in cowboyHats)
        {
            hat.SetActive(false);
        }

        // Attach click event handlers to the buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Store the current index in a local variable to avoid closure issues
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }
    }

    private void OnButtonClicked(int index)
    {
        if (selectedHatIndex == index)
        {
            // Clicked the same cowboy hat again, set it to false
            cowboyHats[index].SetActive(false);
            selectedHatIndex = -1;
        }
        else
        {
            // Set the clicked cowboy hat to true
            cowboyHats[index].SetActive(true);

            // Set all other cowboy hats to false
            for (int i = 0; i < cowboyHats.Length; i++)
            {
                if (i != index)
                {
                    cowboyHats[i].SetActive(false);
                }
            }

            selectedHatIndex = index;
        }
    }


}

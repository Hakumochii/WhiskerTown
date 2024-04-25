/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CowboyHatMusling : MonoBehaviour
{
    public GameObject[] cowBoyHats = new GameObject[9];

    //public Button[] cowBoyHatsButton = new Button[9];

    private void Awake()
    {
       foreach (GameObject hat in cowBoyHats)
        {
            hat.SetActive(false);
        }
    }


    public void onClick()
    {
        bool currentHat = false;

        switch (currentHat)
        {
            case 1:
                if (cowBoyHatsButton[0] != null)
                {
                    cowBoyHats[0].SetActive(true);
                }
                break;

            case 2:
                if (cowBoyHatsButton[1] != null)
                {
                    cowBoyHats[1].SetActive(true);
                }
                break;

            case 3:
                if (cowBoyHatsButton[2] != null)
                {
                    cowBoyHats[2].SetActive(true);
                }
                break;

            default:
                foreach (GameObject hat in cowBoyHats)
                {
                    if (hat != null)
                    {
                        hat.SetActive(false);
                    }
                }
                break;
                x



        }
    }
}*/
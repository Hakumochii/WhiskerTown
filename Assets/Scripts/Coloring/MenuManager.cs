using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button Frame1;
    public Button Frame2;
    public Button Frame3;

    public GameObject Musling;
    public GameObject Pusling;
    public GameObject Misling;

    public void Frame1Click()
    {
        switch (Musling.activeInHierarchy)
        {
            case true:
                Debug.Log("Musling is already chosen");
                break;
            case false:
                if (Pusling.activeInHierarchy || Misling.activeInHierarchy)
                {
                    Pusling.SetActive(false);
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

    public void Frame2Click()
    {
        switch (Pusling.activeInHierarchy)
        {
            case true:
                Debug.Log("Pusling is already chosen");
                break;
            case false:
                if (Musling.activeInHierarchy || Misling.activeInHierarchy)
                {
                    Musling.SetActive(false);
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

    public void Frame3Click()
    {
        switch (Misling.activeInHierarchy)
        {
            case true:
                Debug.Log("Misling is already chosen");
                break;
            case false:
                if (Musling.activeInHierarchy || Pusling.activeInHierarchy)
                {
                    Musling.SetActive(false);
                    Misling.SetActive(false);
                    Pusling.SetActive(true);
                }
                else if (!Musling.activeInHierarchy || !Pusling.activeInHierarchy)
                {
                    Misling.SetActive(true);
                }

                break;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

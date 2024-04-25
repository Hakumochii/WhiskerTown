using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{


    public Cat(string animalSpecies, int animalAge, string animalName, string animalGender) : base(animalSpecies, animalAge, animalName, animalGender)
    {
        
    }

    public override void MakeSound()
    {
        AudioManager.instance.PlayAudio("Event:/Cat_Sounds/Miav");
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

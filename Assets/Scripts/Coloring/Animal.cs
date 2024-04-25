using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    //Get properties for gender
    private string _species;
    public string Species
    {
        get { return _species; }
    }

    public string animalName;

    //Get set properties to ensure you cannot override maximumAge
    private int _maximumAge;
    public int MaximumAge
    {
        get { return _maximumAge; }
    }

    //Get set properties to ensure you cannot set age above maximum age
    private int _age;
    public int Age
    {
        get { return _age; }
        set
        {
            // Ensure happiness is never set above 10
            if (value <= _maximumAge)
                _happiness = value;
            else
                _happiness = _maximumAge; // Set to maximum value
        }
    }

    //Get properties for gender
    private string _gender;
    public string Gender
    {
        get { return _gender; }
    }

    //Get set properties for Happiness
    private int _happiness;
    public int Happiness
    {
        get { return _happiness; }
        set
        {
            // Ensure happiness is never set above 10
            if (value <= 10)
                _happiness = value;
            else
                _happiness = 10; // Set to maximum value
        }
    }

    public Animal(string animalSpecies, int animalAge, string animalName, string animalGender)
    {
        this._species = animalSpecies;
        this._age = animalAge;
        this.animalName = animalName;
        this._gender = animalGender;
        this._happiness = 5;
        this._maximumAge = 50;
    }

    public void DisplayStats()
    {
        Debug.Log("Species " + Species)
        Debug.Log("Name: " + animalName);
        Debug.Log("Age: " + Age);
        Debug.Log("Gender: " + Gender);
        Debug.Log("Happiness: " + Happiness);
    }

    public virtual void Eat()
    {
        Debug.Log("The " + Species + " " + animalName + " is eating.");
    }

    public virtual void Sleep()
    {
        Debug.Log("The " + Species + " " + animalName + " is sleeping.");
    }

    public virtual void Move()
    {
        Debug.Log("The " + Species + " " + animalName + " is moving.");
    }

    public virtual void MakeSound()

    {
        Debug.Log("The " + Species + " " + animalName + " makes a generic sound.");
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

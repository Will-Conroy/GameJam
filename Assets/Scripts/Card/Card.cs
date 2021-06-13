using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
    public enum ColourTypes
    {
        Red,
        Blue,
        Yellow,
        Colourless
    }

    Dictionary<ColourTypes, int> colourCost = new Dictionary<ColourTypes, int>();
    int colourlessCost;
    CardEffect effect;

    public static Card createFromTemplate() //creates a card from a CardTemplate object (maybe make this a CardTemplate method?)
    {
        return new Card();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTemplate
{
    private Dictionary<Card.ColourTypes, int> colourCost = new Dictionary<Card.ColourTypes, int>();
    private CardEffect cardEffect;
    private string description;
    private string cardName; //store templates in a dictionary with name as key instead?


    public CardEffect getEffect()
    {
        return cardEffect;
    }

    public Dictionary<Card.ColourTypes, int> getCost()
    {
        return colourCost;
    }

    public string getDesc()
    {
        return description;
    }

    public string getName()
    {
        return cardName;
    }

    public CardTemplate(Dictionary<Card.ColourTypes, int> cost, CardEffect effect, string desc, string name)
    {
        colourCost = cost;
        cardEffect = effect;
        description = desc;
        cardName = name;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCommad : Command
{
    /*---- Veriables ----*/
    private  Deck _deck;
    private int _amount;


    /*---- Initialization ----*/
    //The Target for Draw command should be the deck you want to draw cards form
    //This can be done with (In most cases) List<GameObject> targetsDeck = new List<GameObject> {GameObject.Find("DeckPrefab")};
    public DrawCommad(List<GameObject> targets, int amount) : base(targets, GameController.ActionType.Draw){
        _deck = targets[0].GetComponent<Deck>();
        _amount = amount;
        info = string.Format("Game: Draw {0} Cards", amount);
    }

    /*---- Methods ----*/
    public override void Execute(){
        _deck.endDraw.AddListener(EndCommand);
        _deck.Draw(_amount);
        
    }
}
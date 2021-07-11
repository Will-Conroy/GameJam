using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawToHandSizeCommand : Command
{

    /*---- Veriables ----*/
    private  Deck _deck;


    /*---- Initialization ----*/
    //The Target for DrawTo command should be the deck you want to draw cards form
    public DrawToHandSizeCommand(List<GameObject> targets) : base(targets, GameController.ActionType.Draw){
        _deck = targets[0].GetComponent<Deck>();
        info = "Game: Drew to hand size";
    }

    
    /*---- Methods ----*/
    public override void Execute(){
        _deck.endDraw.AddListener(EndCommand);
        _deck.DrawToHandSize();
        
    }
}

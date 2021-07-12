using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardHandCommand : Command
{
    /*---- Veriables ----*/
    private  Hand _hand;


    /*---- Initialization ----*/
    //The Target for Draw command should be the deck you want to draw cards form
    //This can be done with (In most cases) List<GameObject> targetsDeck = new List<GameObject> {GameObject.Find("DeckPrefab")};
    public DiscardHandCommand(List<GameObject> targets) : base(targets, GameController.ActionType.Discard){
        _hand = targets[0].GetComponent<Hand>();
        info = "Discarded Hand";
    }

    /*---- Methods ----*/
    public override void Execute(){
        _hand.endDiscard.AddListener(EndCommand);
        _hand.discardHand();  
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillDeckCommand : Command
{
    /*---- Veriables ----*/
    private  Deck _deck;

    /*---- Initialization ----*/

        //targets should be the deck that needs refilling
        public RefillDeckCommand(List<GameObject> targets) : base(targets, GameController.ActionType.DumpToDeck){
        _deck = targets[0].GetComponent<Deck>();
        info = "Refilled Deck";
    }

    /*---- Methods ----*/
    public override void Execute(){
        _deck.endFilledDeck.AddListener(EndCommand);
        _deck.refillDeck();
    }
}
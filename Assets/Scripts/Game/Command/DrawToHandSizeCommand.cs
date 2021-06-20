using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawToHandSizeCommand : Command
{
    private  Deck _deck;

    public DrawToHandSizeCommand(List<GameObject> targets) : base(targets, GameController.ActionType.Draw){
        _deck = targets[0].GetComponent<Deck>();
        info = "Game: Drew to hand size";
    }

    public override void Execute(){
        _deck.DrawToHandSize();
        _deck.endDraw.AddListener(EndCommand);
    }
}

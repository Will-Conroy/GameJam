using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCommad : Command
{
    private  Deck _deck;
    private int _amount;

    public DrawCommad(List<GameObject> targets, int amount) : base(targets, GameController.ActionType.Draw){
        _deck = targets[0].GetComponent<Deck>();
        _amount = amount;
        info = string.Format("Game: Draw {0} Cards", amount);
    }

    public override void Execute(){
        _deck.endDraw.AddListener(EndCommand);
        _deck.Draw(_amount);
        
    }
}
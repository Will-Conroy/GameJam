using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCommad : Command
{
    private  Deck _deck;
    private int _amount;

    public DrawCommad(List<GameObject> targets, int amount) : base(targets, GameController.ActionType.DrawCard){
        _deck = targets[0].GetComponent<Deck>();
        _amount = amount;
    }

    public override void Execute(){
        _deck.Draw(_amount);
    }
}
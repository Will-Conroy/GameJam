using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyWeaknessCommand : Command
{
    /*---- Veriables ----*/
    private  List<StatController> puppets;
    private Card.ColourTypes _type;
    private int _amount;


    /*---- Initialization ----*/
    public ApplyWeaknessCommand(List<GameObject> targets, Card.ColourTypes type, int amount) : base(targets, GameController.ActionType.PerfromPuppetAction){
        puppets = new List<StatController>();
        _type = type;
        _amount = amount;
        foreach(GameObject target in targets){
            
            puppets.Add(target.GetComponent<StatController>());
        }
    }

    
    /*---- Methods ----*/
    public override void Execute(){
        foreach(StatController puppet in puppets){
            puppet.UpdateWeekness(_type, _amount);
        }
    }
}
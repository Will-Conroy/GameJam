using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class Command
{
    /*---- Events ----*/
    public UnityEvent<Command> Excuted = new UnityEvent<Command>();
    
    /*---- Veriables ----*/
      protected List<GameObject> _targets;
    protected GameController.ActionType _actionType;
    protected string info;


    /*---- Initialization ----*/
       public Command(List<GameObject> targets, GameController.ActionType actionType)
    {
        _targets = targets;
        _actionType = actionType;
    }
    /*---- Methods ----*/
       public abstract void Execute();

    public void EndCommand(){
        Excuted?.Invoke(this);
    }


    /*---- Getters & Setters ----*/
    public GameController.ActionType getActionType(){
        return _actionType;
    }
    public string  getInfo(){
        return info;
    }
}
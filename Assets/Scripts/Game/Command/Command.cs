using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class Command
{
    
    public UnityEvent Excuted;

    protected List<GameObject> _targets;
    protected GameController.ActionType _actionType;
    protected string info;
    public Command(List<GameObject> targets, GameController.ActionType actionType)
    {
        _targets = targets;
        _actionType = actionType;
    }

    public abstract void Execute();

    public void EndCommand(){
        Excuted?.Invoke();
    }
    public GameController.ActionType getActionType(){
        return _actionType;
    }
    public string  getInfo(){
        return info;
    }
}
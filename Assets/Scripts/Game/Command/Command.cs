using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Command
{
    protected List<GameObject> _targets;
    protected GameController.ActionType _actionType;
    public Command(List<GameObject> targets, GameController.ActionType actionType)
    {
        _targets = targets;
        _actionType = actionType;
    }

    public abstract void Execute();

    public GameController.ActionType getActionType(){
        return _actionType;
    }
}
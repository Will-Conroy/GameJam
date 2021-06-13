using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Command
{
    protected GameObject[] _targets;
    protected GameController.ActionType type;
    public Command(GameObject[] targets)
    {
        _targets = targets;
    }

    public abstract void Execute();

    public GameController.ActionType getActionType(){
        return type;
    }
}
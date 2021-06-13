using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
     GameController.ActionType getActionType();
     void performAction(List<GameObject> targets);
}
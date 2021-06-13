using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPhase{
     IPhase Tick(List<GameObject>  targets, IAction action);
     void Enter(List<GameObject>  targets);
     void Exit(List<GameObject>  targets);
     string getPhaseName();
     int getPlayerID();

}
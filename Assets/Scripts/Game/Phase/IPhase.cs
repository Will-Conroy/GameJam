using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPhase{
     IPhase Tick(List<GameObject>  targets, IAction action);
     void Enter();
     void Exit();
     IPhase NextPhase();
     string getPhaseName();
     int getPlayerID();

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPhase{
     IPhase Execute(Command command);
     void Enter();
     void Exit();
     IPhase NextPhase();
     string getPhaseName();
     bool isPlayerOne();

}
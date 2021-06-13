using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasePlan : Phase
{
    public PhasePlan(bool isPlayerOne): base(isPlayerOne){}
    public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.PlayerEndPhase};
       nextPhase = new PhaseDamage(_isPlayerOne);
       phaseName = "Plannig";
       return;
    }
}

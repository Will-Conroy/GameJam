using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseModify : Phase
{
   public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.PlayerEndPhase};
       nextPhase = new PhasePlan();
       phaseName = "Modify";
        return;
    }
}

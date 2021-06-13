using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseDamage : Phase
{
    public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase};
       nextPhase = new PhaseEnd();
       phaseName = "Damage";
       return;
    }
}
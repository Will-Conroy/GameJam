using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasePlan : Phase
{
    public override void Enter(List<GameObject> targets){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase};
       nextPhase = new PhaseDamage();
       phaseName = "Plannig";
       return;
    }
}

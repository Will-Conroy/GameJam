using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseEnd : Phase
{
    public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase};
       nextPhase = new PhaseUpkeep();
       phaseName = "End";
       return;
    }
}

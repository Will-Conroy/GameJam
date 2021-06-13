using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseDamage : Phase
{
    public PhaseDamage(bool isPlayerOne): base(isPlayerOne){}
    public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase};
       nextPhase = new PhaseEnd(_isPlayerOne);
       phaseName = "Damage";
       return;
    }
}
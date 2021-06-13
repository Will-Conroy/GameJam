using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseModify : Phase
{
    public PhaseModify(bool isPlayerOne): base(isPlayerOne){}

   public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.PlayerEndPhase, GameController.ActionType.Draw};
       nextPhase = new PhasePlan(_isPlayerOne);
       phaseName = "Modify";
        return;
    }
}

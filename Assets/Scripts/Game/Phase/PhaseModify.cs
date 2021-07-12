using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseModify : Phase
{

    /*---- Initialization ----*/
    public PhaseModify(bool isPlayerOne): base(isPlayerOne){
        phaseName = "Modify";
    }

    /*---- Methods ----*/
   public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.PlayerEndPhase, GameController.ActionType.Draw, GameController.ActionType.Discard};
       nextPhase = new PhasePlan(_isPlayerOne);
        return;
    }
}

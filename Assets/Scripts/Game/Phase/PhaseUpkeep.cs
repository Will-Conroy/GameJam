using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseUpkeep : Phase
{
   public PhaseUpkeep(bool isPlayerOne): base(isPlayerOne){}

   public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.PlayerEndPhase};
       nextPhase = new PhaseModify(_isPlayerOne);
       phaseName = "Upkeep";
       return;
    }
}

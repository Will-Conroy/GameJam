using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseUpkeep : Phase
{

   public override void Enter(List<GameObject> targets){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.PlayerEndPhase};
       nextPhase = new PhaseModify();
       phaseName = "Upkeep";
       return;
    }

 
}

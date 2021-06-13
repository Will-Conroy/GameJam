using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseUpkeep : Phase
{
   public PhaseUpkeep(bool isPlayerOne): base(isPlayerOne){}

   public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase};
       nextPhase = new PhaseModify(_isPlayerOne);
       phaseName = "Upkeep";
       //return;
       _commandProcessor.ExecuteCommand(new EndPhaseCommand(new List<GameObject> {_gameController.getGameObject()}, _isPlayerOne));

        //_commandProcessor.AddCommand(new EndPhaseCommand(new List<GameObject> {_gameController.getGameObject()}, _isPlayerOne));
        //_commandProcessor.RunAllCommands();
    }

    
}

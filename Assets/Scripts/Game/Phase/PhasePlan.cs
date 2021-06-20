using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasePlan : Phase
{
    public PhasePlan(bool isPlayerOne): base(isPlayerOne){
        phaseName = "Planing";
    }

    public override void Enter(){
        nextPhase = new PhaseDamage(_isPlayerOne, _commandProcessor);
        validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.PlayerEndPhase, GameController.ActionType.PerfromPuppetAction};
        return;
    }

    public override void Execute(Command command){
    
        if(command.getActionType() ==GameController.ActionType.PlayerEndPhase || command.getActionType() ==GameController.ActionType.EndPhase  )
            _commandProcessor.ExecuteCommand(command);
        if(IsValidAction(command))
          _commandProcessor.AddCommand(command);
          
   }
}

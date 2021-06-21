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
        _commandProcessor.AddCommand(new PlayerEndPhaseCommand(new List<GameObject> {_gameController.getGameObject()}, _isPlayerOne));
    }

    public override void Execute(Command command){
    
        if(command.getActionType() ==GameController.ActionType.PlayerEndPhase)
            _commandProcessor.RunAllCommands();
        if(IsValidAction(command))
          _commandProcessor.AddCommand(command);
          
   }

}

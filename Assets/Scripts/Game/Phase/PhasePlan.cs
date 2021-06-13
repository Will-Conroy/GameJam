using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasePlan : Phase
{
    public PhasePlan(bool isPlayerOne): base(isPlayerOne){}
    public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.PlayerEndPhase, GameController.ActionType.PerfromPuppetAction};
       nextPhase = new PhaseDamage(_isPlayerOne, _commandProcessor);
       phaseName = "Planing";
       //_commandProcessor.AddCommand(new EndPhaseCommand(new List<GameObject> {_gameController.getGameObject()}, _isPlayerOne));
       return;
    }

    public override Phase Execute(Command command){
    
        if(command.getActionType() ==GameController.ActionType.PlayerEndPhase || command.getActionType() ==GameController.ActionType.EndPhase  )
            _commandProcessor.ExecuteCommand(command);
        if(IsValidAction(command))
          _commandProcessor.AddCommand(command);
        return null;
   }
}

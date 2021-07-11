using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasePlan : Phase
{
    /*---- Initialization ----*/
       public PhasePlan(bool isPlayerOne): base(isPlayerOne){
        phaseName = "Planing";
    }


    /*---- Methods ----*/
      public override void Enter(){
        nextPhase = new PhaseDamage(_isPlayerOne, _commandProcessor);
        validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.PlayerEndPhase, GameController.ActionType.PerfromPuppetAction};
        _commandProcessor.AddCommand(new PlayerEndPhaseCommand(new List<GameObject> {_gameController.getGameObject()}, _isPlayerOne));
    }

    public override bool Execute(Command command){
    
        if(command.getActionType() ==GameController.ActionType.PlayerEndPhase)
            _commandProcessor.RunAllCommands();
        
        bool valid = IsValidAction(command);
        if(valid)
          _commandProcessor.AddCommand(command);
        
        return valid;
   }
}

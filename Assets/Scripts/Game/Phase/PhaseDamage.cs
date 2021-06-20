using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseDamage : Phase
{
    public PhaseDamage(bool isPlayerOne, CommandProcessor commandProcessor): base(isPlayerOne){
        _commandProcessor = commandProcessor;
        phaseName = "Damage";
    }
    
    public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.PerfromPuppetAction};
       nextPhase = new PhaseEnd(_isPlayerOne);
       _commandProcessor.AddCommand(new EndPhaseCommand(new List<GameObject> {_gameController.getGameObject()}, _isPlayerOne));
       _commandProcessor.RunAllCommands();
    }
}
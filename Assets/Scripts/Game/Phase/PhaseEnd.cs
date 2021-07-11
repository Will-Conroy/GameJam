using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseEnd : Phase
{

    /*---- Initialization ----*/
    public PhaseEnd(bool isPlayerOne): base(isPlayerOne){
        phaseName = "End";
    }


    /*---- Methods ----*/
    public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase};
       nextPhase = new PhaseUpkeep(!_isPlayerOne);
       _commandProcessor.AddCommand(new EndPhaseCommand(new List<GameObject> {_gameController.getGameObject()}, _isPlayerOne));
       _commandProcessor.RunAllCommands();
       return;
    }
    public override void Exit(){
        _gameController.endTurn();
    }
}

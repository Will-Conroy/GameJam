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
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.Discard, GameController.ActionType.DumpToDeck};
       nextPhase = new PhaseUpkeep(!_isPlayerOne);
       _commandProcessor.AddCommand(new DiscardHandCommand(new List<GameObject>{GameObject.FindGameObjectWithTag("Hand")}));
       _commandProcessor.AddCommand(new EndPhaseCommand(new List<GameObject> {_gameController.getGameObject()}, _isPlayerOne));
       _commandProcessor.RunAllCommands();
       return;
    }
    public override void Exit(){
        _gameController.endTurn();
    }
}

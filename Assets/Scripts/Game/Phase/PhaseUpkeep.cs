using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseUpkeep : Phase
{
   public PhaseUpkeep(bool isPlayerOne): base(isPlayerOne){}

   public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.Draw};
       nextPhase = new PhaseModify(_isPlayerOne);
       phaseName = "Upkeep";
       _commandProcessor.ExecuteCommand(new DrawToHandSizeCommand(new List<GameObject> {GameObject.FindGameObjectWithTag("Deck")}));
       _commandProcessor.ExecuteCommand(new EndPhaseCommand(new List<GameObject> {_gameController.getGameObject()}, _isPlayerOne));
    }

    
}

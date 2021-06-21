using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseUpkeep : Phase
{
   public PhaseUpkeep(bool isPlayerOne): base(isPlayerOne){
        phaseName = "Upkeep";
        
   }

   public override void Enter(){
       nextPhase = new PhaseModify(_isPlayerOne);
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.Draw};
        GameObject DeckObject = GameObject.FindGameObjectWithTag("Deck");
       _commandProcessor.AddCommand(new DrawToHandSizeCommand(new List<GameObject> {DeckObject}));
       _commandProcessor.AddCommand(new EndPhaseCommand(new List<GameObject> {_gameController.getGameObject()}, _isPlayerOne));
       _commandProcessor.RunAllCommands();  
    }
    

    
}
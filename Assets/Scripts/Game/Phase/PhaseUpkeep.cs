using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseUpkeep : Phase
{
    /*---- Initialization ----*/
    public PhaseUpkeep(bool isPlayerOne): base(isPlayerOne){
        phaseName = "Upkeep";
        
   }


    /*---- Methods ----*/
   public override void Enter(){
       nextPhase = new PhaseModify(_isPlayerOne);
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase, GameController.ActionType.Draw};
        GameObject DeckObject = GameObject.FindGameObjectWithTag("Deck");
       _commandProcessor.AddCommand(new DrawToHandSizeCommand(new List<GameObject> {DeckObject}));
       _commandProcessor.AddCommand(new EndPhaseCommand(new List<GameObject> {_gameController.getGameObject()}, _isPlayerOne));
       _commandProcessor.RunAllCommands();  
    }
    

    
}
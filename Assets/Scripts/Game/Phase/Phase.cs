using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  abstract class Phase
{

    /*-----Veriables-----*/
    protected GameController.ActionType [] validAction;
    protected Phase nextPhase;
    protected string phaseName;
    protected bool _isPlayerOne;
    protected CommandProcessor _commandProcessor;
    protected GameController _gameController;
    
    public Phase(bool isPlayerOne){
        _commandProcessor = new CommandProcessor();
       _isPlayerOne = isPlayerOne;
       _gameController = GameObject.Find("HUB").GetComponent<GameController>();
    }
   public virtual void Execute(Command command){
       if(IsValidAction(command))
          _commandProcessor.ExecuteCommand(command);
          
      
   }

   public Phase NextPhase(){
     return nextPhase;
   }

   public abstract  void Enter();

    public virtual void Exit(){
         return;
    }

    public string getPhaseName(){
        return phaseName;
    }

    public bool isPlayerOne(){
         return _isPlayerOne;
     }


    protected bool IsValidAction(Command command){

        foreach( GameController.ActionType actionID in validAction )
        {
            if( actionID == command.getActionType())
         
                return true;
        }

        return false;
    }
  
    public CommandProcessor getCommandProcessor(){
        return _commandProcessor;
    }
}

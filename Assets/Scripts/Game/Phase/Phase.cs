using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Phase : IPhase
{
    protected GameController.ActionType [] validAction;
    protected Phase nextPhase;
    protected string phaseName;
    protected int playerID;
    protected CommandProcessor _commandProcessor;
    
    public Phase(){
        _commandProcessor = new CommandProcessor();
    }

   public IPhase Execute(Command command){
       if (command.getActionType() == GameController.ActionType.EndPhase)
            return nextPhase;

       if(IsValidAction(command))
          _commandProcessor.ExecuteCommand(command);
       return null;
   }

   public IPhase NextPhase(){
     return nextPhase;
   }

   public virtual  void Enter(){
       
        return;
    }

    public void Exit(){
         return;
    }

    public string getPhaseName(){
        return phaseName;
    }

    public int getPlayerID(){
         return 1;
     }

    private bool IsValidAction(Command command){
        foreach( GameController.ActionType actionID in validAction )
        {
            if( actionID == command.getActionType())
                return true;
        }

        return false;
    }
}

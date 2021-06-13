using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Phase : IPhase
{
    internal GameController.ActionType [] validAction;
    internal Phase nextPhase;
    internal string phaseName;
    internal int playerID;
    
    
    
   public IPhase Tick(List<GameObject> targets, IAction action){
       if (action.getActionType() == GameController.ActionType.EndPhase)
            return nextPhase;

       if(IsValidAction(action))
           action.performAction(targets);
       return null;
   }

   public virtual  void Enter(List<GameObject> targets){
       
        return;
    }

    public void Exit(List<GameObject> targets){
         return;
    }

    public string getPhaseName(){
        return phaseName;
    }

    public int getPlayerID(){
         return 1;
     }


    private bool IsValidAction(IAction action){
        foreach( GameController.ActionType actionID in validAction )
        {
            
            if( actionID == action.getActionType())
                return true;
        }

        return false;
    }


 
}

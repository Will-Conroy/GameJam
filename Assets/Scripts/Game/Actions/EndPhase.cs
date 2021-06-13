using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhase : IAction
{
   public  GameController.ActionType getActionType(){
        return GameController.ActionType.EndPhase;
    }

    public void performAction(List<GameObject> targets){
         GameController gamecon = targets[0].GetComponent<GameController>();
         gamecon.nextPhase();
         return;
     }
}

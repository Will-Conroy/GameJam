using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APlayerEndsPhase : IAction
{

   public  GameController.ActionType getActionType(){
        return GameController.ActionType.PlayerEndPhase;
    }

    public void performAction(List<GameObject> targets){
         return;
     }
}

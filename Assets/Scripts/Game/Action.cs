using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private GameController.ActionType actionID;

  public GameController.ActionType getID(){
      return actionID;
  }
  
}

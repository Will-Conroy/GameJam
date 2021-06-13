using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnBarController : MonoBehaviour
{
    private TextMeshProUGUI[] txtBar;
    private TextMeshProUGUI playerTurnValue;
    private TextMeshProUGUI phaseNameValue;
    //private Phase currentPhase;
    private GameController gameController;
    private CommandProcessor _commandProcessor;
    private Phase currentPhase;

    private void Awake()
    {
        txtBar = GetComponentsInChildren<TextMeshProUGUI>();
        gameController = GetComponentInParent<GameController>();
        
        playerTurnValue = txtBar[0];
        phaseNameValue = txtBar[1];
    }
   
    public void SetPhaseText((string, bool) textArray){
        phaseNameValue.text =  textArray.Item1;

        string message = "P: 2";
        if(textArray.Item2)
            message = "P: 1";
        
        playerTurnValue.text = message;
    
    }

     public void endPhaseButtonExcute(){
        
        List<GameObject> thisArray = new List<GameObject> {gameController.getGameObject()};
        Command action = new PlayerEndPhaseCommand(thisArray, gameController.getIsPlayerOne());
        gameController.performAction(action);
        
        return;
    }


   
}

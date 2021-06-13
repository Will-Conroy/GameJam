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
        //_commandProcessor = GetComponentInParent<CommandProcessor>();
        playerTurnValue = txtBar[0];
        phaseNameValue = txtBar[1];
    }
   
    public void SetPhaseText((string, bool) textArray){
        
        phaseNameValue.text =  textArray.Item1;
        playerTurnValue.text = textArray.Item2.ToString();
    
    }

    /*
    public void endPhaseButtonExcute(){
        IAction action = new APlayerEndsPhase();
        List<GameObject> thisArray = new List<GameObject> {gameController.getGameObject()};

       gameController.performAction(action, thisArray);
        return;
    }*/
     public void endPhaseButtonExcute(){
        
        List<GameObject> thisArray = new List<GameObject> {gameController.getGameObject()};
        Command action = new PlayerEndPhaseCommand(thisArray, gameController.getIsPlayerOne());
        gameController.performAction(action);
        
        return;
    }

    /*
    public void endPhaseButtonExcute(){
        
        List<GameObject> thisArray = new List<GameObject> {gameController.getGameObject()};
        Command action = new PlayerEndPhaseCommand(thisArray);
        //gameController.performAction(action, thisArray);
        _commandProcessor.ExecuteCommand(action);
        return;
    }*/


   
}

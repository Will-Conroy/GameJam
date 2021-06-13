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
    private Phase currentPhase;

    private void Awake()
    {
        txtBar = GetComponentsInChildren<TextMeshProUGUI>();
        gameController = GetComponentInChildren<GameController>();
        playerTurnValue = txtBar[0];
        phaseNameValue = txtBar[1];
    }
   
    public void SetPhaseText((string, int) textArray){
        
        phaseNameValue.text =  textArray.Item1;
        playerTurnValue.text = textArray.Item2.ToString();
    
    }


    public void nextPhase(){
        gameController.UpdateState( new EndPhase(), null);
        return;
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogController : MonoBehaviour
{
    /*---- Veriables ----*/
    private TextMeshProUGUI logText;
    private GameController _gameController;
    private Phase currentPhase;
    private int count;
    private bool isVisable;


    /*---- Initialization ----*/
      private void Awake(){
        isVisable = true;
        toggleVisiable();
        count = 0;
        logText = GetComponentInChildren<TextMeshProUGUI>();
        _gameController = GameObject.Find("HUB").GetComponent<GameController>();
        _gameController.phaseChange.AddListener(updateCurrentPhase);
    }


    /*---- Methods ----*/
    private void updateCurrentPhase((string, bool) textArray){
        currentPhase?.getCommandProcessor().commandExcutionStart.RemoveListener(updateText);
        currentPhase = _gameController.getCurrentPhase();
        currentPhase.getCommandProcessor().commandExcutionStart.AddListener(updateText);
    }

    private void updateText(string message){
        logText.text += count + ": " +message + '\n';
        count ++;
    }

    public void toggleVisiable(){
        isVisable = !isVisable;
        gameObject.transform.parent.gameObject.SetActive(isVisable);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameController : MonoBehaviour
{
    /*-----Events-----*/
    public UnityEvent<(string, bool)> phaseChange;
    /*-----ENUMS-----*/
    public enum PhasesName
    {
        Upkeep,
        Modify,
        Plan,
        Damage,
        End
    }

    public enum ActionType{
        EndPhase,
        PlayerEndPhase,
        AddMana,
        DrawCard,
        EquipCard,
        QueuePuppetAction,
        PerfromPuppetAction
    }
    /*-----Veriables-----*/

    private Phase currentPhase;
    private ManaPool manaPool;

    private void Awake()
    {
  
        currentPhase = new PhaseUpkeep(true);
        currentPhase.Enter();
        phaseChange?.Invoke((currentPhase.getPhaseName(),  currentPhase.isPlayerOne()));
    }

    public void nextPhase(bool isPlayerOne){
        Phase newPhase = currentPhase.NextPhase();
        currentPhase.Exit();
        currentPhase = newPhase;
        currentPhase.Enter();
        phaseChange?.Invoke((currentPhase.getPhaseName(),  currentPhase.isPlayerOne()));
        return;
    }
    
    public void performAction(Command command){
        currentPhase.Execute(command);
    }


    /*-----Getters----*/
    public GameObject getGameObject(){
        return gameObject;
    }
    public bool getIsPlayerOne(){
        return currentPhase.isPlayerOne();
    }

}

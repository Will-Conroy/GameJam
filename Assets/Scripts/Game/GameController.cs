using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameController : MonoBehaviour
{
    /*-----Events-----*/
    public UnityEvent turnEnded;
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
        Draw,
        EquipCard,
        QueuePuppetAction,
        PerfromPuppetAction
    }

    /*-----Veriables-----*/
    private Phase currentPhase;
    private ManaPool manaPool;

    /*----Methods----*/
    private void Start()
    {
        currentPhase = new PhaseUpkeep(true);
        currentPhase.Enter();
        phaseChange?.Invoke((currentPhase.getPhaseName(),  currentPhase.isPlayerOne()));
    }

    public void nextPhase(bool isPlayerOne){
        currentPhase.Exit();
        currentPhase = currentPhase.NextPhase();
        currentPhase.Enter();   
        phaseChange?.Invoke((currentPhase.getPhaseName(),  currentPhase.isPlayerOne()));
    }
    
    public void performAction(Command command){
        currentPhase.Execute(command);
    }

    public void endTurn(){
            turnEnded?.Invoke();
    }
    
    /*-----Getters----*/
    public GameObject getGameObject(){
        return gameObject;
    }

    public bool getIsPlayerOne(){
        return currentPhase.isPlayerOne();
    }

    public Phase getCurrentPhase(){
        return currentPhase;
    }
}

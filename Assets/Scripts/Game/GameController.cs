using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameController : MonoBehaviour
{
    /*---- Events -----*/
    public UnityEvent turnEnded;
    public UnityEvent<(string, bool)> phaseChange;


    /*---- ENUMS ----*/
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
        Discard,
        DumpToDeck,
        EquipCard,
        QueuePuppetAction,
        PerfromPuppetAction
    }


    /*---- Veriables ----*/
    private Phase currentPhase;
    private ManaPool manaPool;

    

    


    /*---- Initialization ----*/
    private void Awake(){
        currentPhase = new PhaseUpkeep(true);
        phaseChange?.Invoke((currentPhase.getPhaseName(),  currentPhase.isPlayerOne()));
        

    }
    
    private void Start()
    {
        
        currentPhase.Enter();
        //phaseChange?.Invoke((currentPhase.getPhaseName(),  currentPhase.isPlayerOne()));
       
    }


    /*---- Methods ----*/
    public void nextPhase(bool isPlayerOne){
        
        currentPhase.Exit();
        currentPhase = currentPhase.NextPhase();
        phaseChange?.Invoke((currentPhase.getPhaseName(),  currentPhase.isPlayerOne()));
        currentPhase.Enter();   
        
    }


    public bool playCard(Command command, Dictionary<Card.ColourTypes, int> manaCost){
        if(isEnoughMana(manaCost)){
            if(performAction(command)){
                removeMana(manaCost);
                return true;
            }
        }
        return false;
    }

    //NEED IMPLMENTION
    private bool isEnoughMana(Dictionary<Card.ColourTypes, int> manaCost){
        return true;
    }


    //NEED IMPLMENTION
    private void removeMana(Dictionary<Card.ColourTypes, int> mana){

    }
    
    public bool performAction(Command command){
        return currentPhase.Execute(command);
    }

    public bool performInterruptAction(Command command){
        return currentPhase.ExecuteInterrupt(command);
    }

    public void endTurn(){
            turnEnded?.Invoke();
    }
    

    /*---- Getters & Setters ----*/
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

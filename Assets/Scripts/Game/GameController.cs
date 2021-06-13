using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameController : MonoBehaviour
{

    public UnityEvent<(string, int)> phaseChange;
    public enum PhasesName
    {
        Upkeep,
        Modify,
        Plan,
        Damage,
        End
    }
    public enum TurnName{
        PlayerOne,
        PlayerTwo
    }

    public enum ActionType{
        EndPhase,
        PlayerEndPhase,
        AddMana,
        DrawCard,
        EquipCard,
        QueuePuppetAction,
        PerfromingPuppetAction
    }

    private IPhase currentPhase;
    private ManaPool manaPool;
    private TurnName playersTurn;
    private Dictionary<TurnName, Player> players;
    
    private void Awake()
    {
        players = new Dictionary<TurnName, Player>(){
          {TurnName.PlayerOne, new Player()},
          {TurnName.PlayerTwo, new Player()}
        };
        currentPhase = new PhaseUpkeep();
        currentPhase.Enter();
        phaseChange?.Invoke((currentPhase.getPhaseName(),  currentPhase.getPlayerID()));
    }

    public void nextPhase(){
        IPhase newPhase = currentPhase.NextPhase();
        currentPhase.Exit();
        currentPhase = newPhase;
        currentPhase.Enter();
        phaseChange?.Invoke((currentPhase.getPhaseName(),  currentPhase.getPlayerID()));
        return;
    }
    
    public void performAction(Command command){
        currentPhase.Execute(command);
    }
    
    public IPhase getCurrentPhase(){
        return currentPhase;
    }
    public GameObject getGameObject(){
        return gameObject;
    }

}

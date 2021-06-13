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
        QueuePuppetAction
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
        currentPhase.Enter(null);
        phaseChange?.Invoke((currentPhase.getPhaseName(),  currentPhase.getPlayerID()));
    }
    private void nextPhase(){
       /*List<GameObject> thisArray = new List<GameObject> {transform.parent.gameObject};
        UpdateState( new EndPhase(), thisArray);*/
        UpdateState( new EndPhase(), null);
        return;
    }
    public void UpdateState(IAction action, List<GameObject> targets){
        IPhase newPhase = currentPhase.Tick(targets, action);

        if (newPhase != null)
        {
            currentPhase.Exit(targets);
            currentPhase = newPhase;
            currentPhase.Enter(targets);
            
            phaseChange?.Invoke((currentPhase.getPhaseName(),  currentPhase.getPlayerID()));
        }
    }
    public IPhase getCurrentPhase(){
        return currentPhase;
    }

}

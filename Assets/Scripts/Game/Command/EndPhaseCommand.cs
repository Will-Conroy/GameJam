using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhaseCommand : Command
{
    private  GameController _gamecontroller;
    private bool player;

    public EndPhaseCommand(List<GameObject> targets, bool isPlayerOne) : base(targets, GameController.ActionType.EndPhase){
        player = isPlayerOne;
        _gamecontroller = _targets[0].GetComponent<GameController>();
        info = "Automaic Phase end";
    }

    public override void Execute(){
        _gamecontroller.nextPhase(player);
        EndCommand();
    }
}

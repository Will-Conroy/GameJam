using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndPhaseCommand : Command
{
    private  GameController gamecon;
    private bool player;

    public PlayerEndPhaseCommand(List<GameObject> targets,  bool isPlayerOne) : base(targets, GameController.ActionType.PlayerEndPhase){
        gamecon = _targets[0].GetComponent<GameController>();
        player = isPlayerOne;
        info = "Player Changed Phase";
    }

    public override void Execute(){
        gamecon.nextPhase(player);
        EndCommand();
    }
}

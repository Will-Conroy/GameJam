using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhaseCommand : Command
{
    private  GameController gamecon;
    private bool player;

    public EndPhaseCommand(List<GameObject> targets, bool isPlayerOne) : base(targets, GameController.ActionType.EndPhase){
        player = isPlayerOne;
        gamecon = _targets[0].GetComponent<GameController>();

        

    }

    public override void Execute(){
        gamecon.nextPhase(player);
        return;
    }
}

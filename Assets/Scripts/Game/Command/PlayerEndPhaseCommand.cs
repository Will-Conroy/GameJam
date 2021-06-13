using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndPhaseCommand : Command
{
    private  GameController gamecon;
    private bool player;

    public PlayerEndPhaseCommand(List<GameObject> targets,  bool isPlayerOne) : base(targets){
        type = GameController.ActionType.PlayerEndPhase;
        type = GameController.ActionType.EndPhase;
        gamecon = _targets[0].GetComponent<GameController>();
        player = isPlayerOne;
    }

    public override void Execute(){
        gamecon.nextPhase(player);
        return;
    }
}

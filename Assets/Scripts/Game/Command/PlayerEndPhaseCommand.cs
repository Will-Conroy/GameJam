using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndPhaseCommand : Command
{
    private  GameController gamecon;

    public PlayerEndPhaseCommand(List<GameObject> targets) : base(targets){
        type = GameController.ActionType.PlayerEndPhase;
        gamecon = _targets[0].GetComponent<GameController>();
        
    }

    public override void Execute(){
        gamecon.nextPhase();
        return;
    }
}

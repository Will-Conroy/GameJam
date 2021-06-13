using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhaseCommand : Command
{
    private  GameController gamecon;

    public EndPhaseCommand(GameObject[] targets) : base(targets){
        type = GameController.ActionType.EndPhase;
        gamecon = _targets[0].GetComponent<GameController>();

    }

    public override void Execute(){
        gamecon.nextPhase();
        return;
    }
}

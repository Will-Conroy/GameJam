using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseEnd : Phase
{
    public PhaseEnd(bool isPlayerOne): base(isPlayerOne){}
    public override void Enter(){
       validAction = new GameController.ActionType[] {GameController.ActionType.EndPhase};
       nextPhase = new PhaseUpkeep(!_isPlayerOne);
       phaseName = "End";
       _commandProcessor.AddCommand(new EndPhaseCommand(new List<GameObject> {_gameController.getGameObject()}, _isPlayerOne));
       _commandProcessor.RunAllCommands();
       return;
    }
}

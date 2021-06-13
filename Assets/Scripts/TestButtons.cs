using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtons : MonoBehaviour
{
    private GameController _gameController;
    private List<GameObject> _targets;

    public void Awake(){
        _gameController = GameObject.Find("HUB").GetComponent<GameController>();
        _targets = new List<GameObject> {GameObject.Find("fightGuy"), GameObject.Find("fightGuy (1)")};
        

    }
    public void testWeekness(){
        Command command = new ApplyWeaknessCommand(_targets, Card.ColourTypes.Red, 9);
     
        _gameController.performAction(command);
    }
    
}

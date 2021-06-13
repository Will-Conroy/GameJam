using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtons : MonoBehaviour
{
    private GameController _gameController;
    private List<GameObject> _targetsPuppets;

    public void Awake(){
        _gameController = GameObject.Find("HUB").GetComponent<GameController>();
        _targetsPuppets = new List<GameObject> {GameObject.Find("fightGuy"), GameObject.Find("fightGuy (1)")};
        

    }
    public void testWeekness(){
        Command command = new ApplyWeaknessCommand(_targetsPuppets, Card.ColourTypes.Red, 9);
     
        _gameController.performAction(command);
    }
    public void testDraw(){
        List<GameObject> targetsDeck = new List<GameObject> {GameObject.Find("DeckPrefab")};
        Command command = new DrawCommad(targetsDeck, 2);
        _gameController.performAction(command);

    }

     public void testDrawToHandSize(){
        List<GameObject> targetsDeck = new List<GameObject> {GameObject.Find("DeckPrefab")};
        Command command = new DrawToHandSizeCommand(targetsDeck);
        _gameController.performAction(command);
    }

 
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour {
    public enum ColourTypes
    {
        Red,
        Blue,
        Yellow,
        Colourless
    }

    private CardTemplate template;
    private bool draggable = false;
    private TextMeshPro mesh;
    private int owner = 1; //remove default later 
    [SerializeField]
    private Sprite cardSpriteFront;
    [SerializeField]
    private Sprite cardSpriteBack1;
    [SerializeField]
    private Sprite cardSpriteBack2;

    public void loadFromTemplate(CardTemplate templateToLoad, int player)
    {
        template = templateToLoad;
        mesh.text = template.getDesc();
        owner = player;
        
    
        
    }
    
    //cardObject = Instantiate(Resources.Load("CardPrefab"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject; use this to instantiate card prefabs later


    public bool isDraggable()
    {
        return draggable;
    }

    public void setDraggable(bool newValue)
    {
        draggable = newValue;
    }

    public void show()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void hide()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void back()
    {
        mesh.gameObject.SetActive(false);
        transform.GetComponentInChildren<SpriteRenderer>().sprite = owner == 1 ? cardSpriteBack1 : cardSpriteBack2;
    }

    public void front()
    {
        mesh.gameObject.SetActive(true);
        transform.GetComponentInChildren<SpriteRenderer>().sprite = cardSpriteFront;
    }

    public void moveTo(Vector3 position)
    {
        GetComponent<GoTo>().setTarget(position);
    }

    void Awake()
    {
        mesh = GetComponentInChildren<TextMeshPro>();
        //Layer 3 = card layer
        gameObject.layer = 3;
    }

    public CardEffect getEffect(){
        return template?.getEffect();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour {

    /*---- ENUMS ----*/
    public enum ColourTypes
    {
        Red,
        Blue,
        Yellow,
        Colourless
    }

    /*----- Veriables -----*/
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


    /*---- Initialization ----*/
    void Awake()
    {
        mesh = GetComponentInChildren<TextMeshPro>();
    }

    //cardObject = Instantiate(Resources.Load("CardPrefab"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject; use this to instantiate card prefabs later
    public void loadFromTemplate(CardTemplate templateToLoad, int player)
    {
        template = templateToLoad;
        mesh.text = template.getDesc();
        owner = player;
    }

    /*---- Methods ----*/
    public bool isDraggable()
    {
        return draggable;
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

    public bool cardPlay( List<GameObject> collisions)
    {
        Command cardCommand = null;
    
        if(getEffect()?.getType() == CardEffect.EffectType.EquipPuppet)
        {
            foreach (GameObject gObject in collisions)
            {
                // 6 = attacker layer
                if(gObject.layer == 6)
                {
                    //if cardCommand is NOT null it means there are more than one puppet target; meaning the card has NOT been played legaly 
                    if(cardCommand == null)
                    {
                        cardCommand = getEffect().constructCommand(new List<GameObject> {gObject});
                    }else
                    {
                        return false;
                    }
                }
            } 
        //Current implamention means all other effect types don't need to be parst a target
        }else
        {
            foreach (GameObject gObject in collisions)
            {
                // 8 = PlayerCard
                if(gObject.layer == 8)
                    //Passes null as the effect should know the legal target
                    cardCommand = getEffect().constructCommand(null);
            }  
        }

        //if cardCommand is null it means the layer condition for the give effectType has NOT been met.
        if(cardCommand == null)
            return false;
        //Add's listener to move the played card into the discard pile, when the all animation have finished
        cardCommand?.Excuted.AddListener(delegate{movePlayedCard();});
        return GameObject.Find("HUB").GetComponent<GameController>().playCard(cardCommand, template?.getCost());      
    }

    private void movePlayedCard(){

    }

    /*----- Getters & Setters ----*/
    public CardEffect getEffect()
    {
        return template?.getEffect();
    }
    public void setDraggable(bool newValue)
    {
        draggable = newValue;
    }


}

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
    private bool isTextVisible = true;


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


    public void setVisible(bool isVisible){
        for (int i = 0; i < transform.childCount; i++){
            transform.GetChild(i).gameObject.SetActive(isVisible);
        }

        if (!isTextVisible){
            mesh.gameObject.SetActive(false);
        }

    }

    public void back()
    {
        isTextVisible = false;
        mesh.gameObject.SetActive(false);
        changeImage(owner == 1 ? cardSpriteBack1 : cardSpriteBack2);
    }

    public void front()
    {
        isTextVisible = true;
        //make text visible if card is visible
        mesh.gameObject.SetActive(transform.GetChild(0).gameObject.activeInHierarchy);
        changeImage(cardSpriteFront);
    }

    private void changeImage(Sprite newImage){
        Transform spriteChild = transform.GetChild(0);
        bool isSpriteVisible = spriteChild.gameObject.activeInHierarchy;
        spriteChild.gameObject.SetActive(true);
        spriteChild.GetComponent<SpriteRenderer>().sprite = newImage;
        spriteChild.gameObject.SetActive(isSpriteVisible);
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
                    }else{
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
        cardCommand?.Excuted.AddListener(finishPlayingCard);

        bool played = GameObject.Find("HUB").GetComponent<GameController>().playCard(cardCommand, template?.getCost());
        if(played){
            GameObject.FindGameObjectWithTag("Hand").GetComponent<Hand>().moveCardToNewZone(this, GameObject.FindGameObjectWithTag("Play").GetComponent<Zone>());
        }else{
            cardCommand.Excuted.RemoveListener(finishPlayingCard);
            GameObject.FindGameObjectWithTag("Hand").GetComponent<Hand>().unlockCards();
        }
        return played;
    }


    private void finishPlayingCard(Command command){
        command.Excuted.RemoveListener(finishPlayingCard);
        GameObject.FindGameObjectWithTag("Play").GetComponent<Zone>().moveCardToNewZone(this, GameObject.FindGameObjectWithTag("Discard").GetComponent<Discard>());
        GameObject.FindGameObjectWithTag("Hand").GetComponent<Hand>().unlockCards();
        //GetComponentInParent<Zone>().display();
    }
    private void movePlayedCard(Command command){
        
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : Zone
{
    /*---- ENUMS ----*/
    /*---- Veriables ----*/
     private bool isLocked = false;
    [SerializeField]
    private float maxWidth = 15f;
    [SerializeField]
    private float maxZ = 50f;
    [SerializeField]
    private int maxHandSize = 7;


    /*---- Initialization ----*/
        void Awake()
    {
        /*for (int i = 0; i < 100; i++)
        {
            GameObject c = Instantiate(Resources.Load("CardPrefab"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            addCard(c.GetComponent<Card>());
        }*/
    }


    /*---- Methods ----*/
    public override void display()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            float xSeparation = Mathf.Min(3, maxWidth/cards.Count);
            float zSeparation = Mathf.Min(0.5f, (maxZ/cards.Count));
            cards[i].moveTo(transform.position + new Vector3(xSeparation * (i-(cards.Count-1)/2f), 0, -zSeparation * i));
        }
    }

    public void lockCards()
    {
        isLocked = true;
        cards.ForEach(delegate (Card card)
            {
                card.setDraggable(false);
            });
    }

    public void unlockCards()
    {
        isLocked = false;
        cards.ForEach(delegate (Card card)
            {
                card.setDraggable(true);
            });
    }

    new public void addCard(Card cardToAdd)
    {
        cardToAdd.setDraggable(!isLocked);
        cardToAdd.front();
        cardToAdd.show();
        base.addCard(cardToAdd);
        display();
    }


    //discards the first x cards
    public void discardCards(int amount){
        if(amount > cards.Count)
            amount = cards.Count;

        for(int i = 0; i < amount; i++)
            moveCardToNewZone(cards[i], GameObject.FindGameObjectWithTag("Discard").GetComponent<Discard>());
    }

    public void discardHand(){
        for(int i = 0; i < cards.Count; i++)
            moveCardToNewZone(cards[i], GameObject.FindGameObjectWithTag("Discard").GetComponent<Discard>());
    }

    public void discardCard(Card card){
        moveCardToNewZone(card, GameObject.FindGameObjectWithTag("Discard").GetComponent<Discard>());
    }

    public void discardRandomCards(int amount){
        if(amount > cards.Count)
            amount = cards.Count;

        for(int i = 0; i < amount; i++)
            moveCardToNewZone(cards[Random.Range(0, cards.Count)], GameObject.FindGameObjectWithTag("Discard").GetComponent<Discard>());

    }

    /*---- Getters & Setters ----*/
    public int getMaxHandSize(){
        return maxHandSize;
    }

    


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hand : Zone
{
  
    /*---- Events ----*/
    public UnityEvent endDiscard = new UnityEvent();
    /*---- Veriables ----*/
     private bool isLocked = false;
    [SerializeField]
    private float maxWidth = 15f;
    [SerializeField]
    private float maxZ = 50f;
    [SerializeField]
    private int maxHandSize = 7;

    private Queue<Card> discardList = new Queue<Card>();

    private Discard discard;


    /*---- Initialization ----*/
        void Awake()
    {
        discard = GameObject.FindGameObjectWithTag("Discard").GetComponent<Discard>();
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



    public void discardHand(){
       Discard(new Queue<Card>(cards));
    }
    public void Discard (Queue<Card> cardsToDiscard){
        discardList = cardsToDiscard;
        if (discardList.Count < 1){
            endDiscard?.Invoke();
            return;
        }
        DiscardNext();
    }

    private void DiscardNext()
    {
        //drawing -= 1;
        CardFlip flipper = cards[0].GetComponent<CardFlip>();
        flipper.flip();
        flipper.flipComplete.AddListener(DiscardComplete);
        if (cards.Count >= 2)
            cards[1].show();
    }

    private void DiscardComplete(){
        if (cards.Count < 1){
            endDiscard.Invoke();
            return;
        }
        Card discardedCard = discardList.Dequeue();
        removeCard(discardedCard);
        discard.addCard(discardedCard);
        discardedCard.GetComponent<CardFlip>().flipComplete.RemoveListener(DiscardComplete);
        //if no more cards are present, shuffle in the discard pile and continue
        if (discardList.Count > 0){
            DiscardNext();
        } else{
            display();
            endDiscard.Invoke();
        }
    }


    /*---- Getters & Setters ----*/
    public int getMaxHandSize(){
        return maxHandSize;
    }
}

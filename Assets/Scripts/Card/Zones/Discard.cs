using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : Zone
{
    /*---- Initialization ----*/
    void Awake()
    {
        /*
        for (int i = 0; i < 15; i++)
        {
            GameObject c = Instantiate(Resources.Load("CardPrefab"), transform.position, Quaternion.identity) as GameObject;
            addCard(c.GetComponent<Card>());
        }*/
    }

    
    /*---- Methods ----*/
    public override void display()
    {
        for (int i = 0; i < cards.Count; i++){
            Card card = cards[cards.Count - 1 - i];
            switch (i)
            {
                case 0:
                    card.moveTo(transform.position + new Vector3(0,0,-1));
                    card.show();
                    break;
                default:
                    card.moveTo(transform.position);
                    break;
            }

        }
    }
    new public void addCard(Card cardToAdd)
    {
        cardToAdd.setDraggable(false);
        cardToAdd.front();
        cardToAdd.hide();
        base.addCard(cardToAdd);
        display();
        cards[cards.Count-1].GetComponent<GoTo>().moveComplete.AddListener(hideOthers);
    }
    private void hideOthers(){
        for (int i = 0; i < cards.Count - 1; i++){
            cards[i].hide();
        }
    }

    public void addToDeck(Deck deck){
        while (cards.Count > 0)
        {
            Card card = removeCard();
            card.back();
            deck.addCard(card);
        }
        //Shuffle deck
    }


    public void dumpToNewZone(Zone zone){
        while(cards.Count > 0)
            moveCardToNewZone(cards[0], zone);    
    }
}

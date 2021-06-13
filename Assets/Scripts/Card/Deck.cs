using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : Zone
{
    Hand hand;
    int drawing = 0;
    public override void display()
    {
        for (int i = 0; i < cards.Count; i++){
            Card card = cards[i];
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
        cardToAdd.back();
        cardToAdd.hide();
        base.addCard(cardToAdd);
        display();
    }

    void Awake()
    {
        hand = GameObject.FindGameObjectWithTag("Hand").GetComponent<Hand>();


        for (int i = 0; i < 15; i++)
        {
            GameObject c = Instantiate(Resources.Load("CardPrefab"), transform.position, Quaternion.identity) as GameObject;
            addCard(c.GetComponent<Card>());
        }
        cards[0].GetComponent<GoTo>().moveComplete.AddListener(delegate{Draw(5);}); //Once the move is complete, draw 4

    }

    public void Draw (int numToDraw){
        if (numToDraw < 1){
            return;
        }
        drawing = Mathf.Min(numToDraw, cards.Count); //add discard pile too
        hand.lockCards();
        DrawNext();

    }

    private void DrawNext()
    {
        drawing -= 1;
        CardFlip flipper = cards[0].GetComponent<CardFlip>();
        flipper.flip();
        flipper.flipComplete.AddListener(DrawComplete);
        cards[1].show();
    }

    private void DrawComplete(){
        Card drawnCard = removeCard();
        hand.addCard(drawnCard);
        drawnCard.GetComponent<CardFlip>().flipComplete.RemoveListener(DrawComplete);
        //if no more cards are present, shuffle in the discard pile and continue
        if (drawing > 0){
            DrawNext();
        } else{
            hand.unlockCards();
            display();
        }
    }
}

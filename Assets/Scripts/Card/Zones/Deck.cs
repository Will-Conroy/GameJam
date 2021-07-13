using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Deck : Zone
{
    /*---- Events ----*/
    public UnityEvent endDraw = new UnityEvent();
    public UnityEvent endFilledDeck = new UnityEvent();


    /*---- Veriables ----*/    
    Hand hand;
    GameController _gameController;
    int drawing = 0;

    /*---- Initialization ----*/
        void Awake()
    {
        hand = GameObject.FindGameObjectWithTag("Hand").GetComponent<Hand>();
        _gameController = GameObject.Find("HUB").GetComponent<GameController>();
        for (int i = 0; i < 15; i++)
        {
            CardTemplate cardTemplateDraw = new CardTemplate(null, new EffectDraw(2), "Draws 2 cards", "Draw");
            GameObject c = Instantiate(Resources.Load("CardPrefab"), transform.position, Quaternion.identity) as GameObject;
            c.GetComponent<Card>().loadFromTemplate(cardTemplateDraw,0);
            addCard(c.GetComponent<Card>());
        }
        //cards[0].GetComponent<GoTo>().moveComplete.AddListener(delegate{Draw(5);}); //Once the move is complete, draw 4

    }


    /*---- Methods ----*/
    public override void display()
    {
        for (int i = 0; i < cards.Count; i++){
            Card card = cards[i];
            switch (i)
            {
                case 0:
                    card.moveTo(transform.position + new Vector3(0,0,-1));
                    card.setVisible(true);
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
        cardToAdd.setVisible(false);
        base.addCard(cardToAdd);
        display();
    }


    public void refillDeck(){
        GameObject.FindGameObjectWithTag("Discard").GetComponent<Discard>().dumpToDeck(this);
        display();
        shuffle();
        endFilledDeck?.Invoke();
    }


    public void Draw (int numToDraw){
        //drawing = Mathf.Min(numToDraw, cards.Count); //add discard pile too
        drawing = numToDraw; 
        hand.lockCards();
        DrawNext();

    }

    private void DrawNext()
    {
        if(isEmpty())
            _gameController.performInterruptAction(new RefillDeckCommand(new List<GameObject> {GameObject.FindGameObjectWithTag("Deck")}));

        if(isEmpty()){
            drawing = 0;
            DrawComplete();

        }else{
            drawing -= 1;
            CardFlip flipper = cards[0].GetComponent<CardFlip>();
            flipper.flip();
            flipper.flipComplete.AddListener(DrawComplete);
            if (cards.Count >= 2)
                cards[1].setVisible(true);
        }
    }
    private void DrawComplete(){
        if (cards.Count < 1){
            endDraw.Invoke();
            return;
        }
        Card drawnCard = removeCard();
        hand.addCard(drawnCard);
        drawnCard.GetComponent<CardFlip>().flipComplete.RemoveListener(DrawComplete);
        //if no more cards are present, shuffle in the discard pile and continue
        if (drawing > 0){
            DrawNext();
        } else{
            hand.unlockCards();
            display();
            endDraw.Invoke();
        }
    }
    public void DrawToHandSize(){
        int difference = hand.getMaxHandSize() - hand.cardCount();
        Draw(difference);
    }

    public void shuffle(){
        System.Random rng = new System.Random();
        for (int n = cards.Count; n > 1; n--) {
            int k = rng.Next(n);  
            n--;
            Card tmp = cards[k];  
            cards[k] = cards[n];  
            cards[n] = tmp;  
        }
        display();
    }
}

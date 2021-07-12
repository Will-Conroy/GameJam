using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    /*---- Veriables ----*/
    protected List<Card> cards = new List<Card>();
    private int maxLength = 0;


    /*---- Methods ----*/
    public void addCard(Card cardToAdd)
    {
        ///Debug.Log("damn...");
        if (this.canAddCard())
        {
            cards.Add(cardToAdd);
            cardToAdd.transform.SetParent(this.transform);
        }
    }

    public Card removeCard()
    {
        return removeCard(0);
    }

    public Card removeCard(int index)
    {
        Card card = cards[index];
        cards.RemoveAt(index);
        return card;
    }

    public void removeCard(Card cardToRemove)
    {
        cards.Remove(cardToRemove);
    }


    public void moveCardToNewZone(Card cardToMove, Zone zoneToMoveTo){
        if(cards.Contains(cardToMove)){
            zoneToMoveTo.addCard(cardToMove);
            removeCard(cardToMove);
            zoneToMoveTo.display();
        }
    }

    public bool canAddCard()
    {
        return (cards.Count < maxLength || maxLength == 0);
    }

    public virtual void display()
    {
        int displayCount = Mathf.Max(0, cards.Count-1);
        cards[displayCount].moveTo(transform.position + new Vector3(0,0,-1));
        cards[displayCount].setVisible(true);

    }

    public int cardCount(){
        return cards.Count;
    }

    public bool isEmpty(){
        return cards.Count < 1;
    }
    /*---- Getters & Setters ----*/
    public Card getCard(int index){
        return cards[index];
    }
    public List<Card> getCards()
    {
        return cards;
    }   
}
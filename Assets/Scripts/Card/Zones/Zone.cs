﻿using System.Collections;
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

    public bool canAddCard()
    {
        return (cards.Count < maxLength || maxLength == 0);
    }

 
    public virtual void display()
    {

    }

    public int cardCount(){
        return cards.Count;
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : Zone
{
    private bool isLocked = false;
    [SerializeField]
    private float maxWidth = 15f;
    [SerializeField]
    private float maxZ = 50f;

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

    void Awake()
    {
        /*for (int i = 0; i < 100; i++)
        {
            GameObject c = Instantiate(Resources.Load("CardPrefab"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            addCard(c.GetComponent<Card>());
        }*/
    }
}

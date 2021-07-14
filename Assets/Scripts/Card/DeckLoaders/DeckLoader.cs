using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeckLoader : MonoBehaviour
{

    [SerializeField]
   private TextAsset cardListFile;
   private Deck _deck;
    [SerializeField]
   private string deckListName;
   private List<string[]> loadedCardInfo = new List<string[]>();

    void Awake()
    {
        string[] cardsString = cardListFile.text.Split('\n');
        foreach (var card in cardsString)
        {
            string[] cardSplit = card.Split(',');
            loadedCardInfo.Add(cardSplit);
        }
        
    }

    void Start(){
        _deck = GetComponentInParent<Deck>();
        loadCardsIntoDeckFormDeckList(deckListName);
    }

   private CardTemplate loadCardTemplate(int cardID){
       string[] cardInfo = loadedCardInfo[cardID];
       Dictionary<Card.ColourTypes, int> cost = loadCostFromString(cardInfo[2]);
       CardEffect cardEffect = loadCardEffectFromString(cardInfo[4], cardInfo[5]);
       return new CardTemplate(cost, cardEffect, cardInfo[3], cardInfo[1]);
   }

    private Dictionary<Card.ColourTypes, int> loadCostFromString(string cost){
        return null;
    }
    private CardEffect loadCardEffectFromString(string cardEffectName, string modifers){
        
        switch (cardEffectName)
        {
            case "DrawEffect":
                return new EffectDraw(int.Parse(modifers));
            default:
                return null;
        }
    }

   public Card loadCard(int cardID, int playerID){
       CardTemplate cardTemplate= loadCardTemplate(cardID);
       GameObject c = Instantiate(Resources.Load("CardPrefab"), transform.position, Quaternion.identity) as GameObject;
       c.GetComponent<Card>().loadFromTemplate(cardTemplate,playerID);
       return c.GetComponent<Card>();
   }

   public void loadCardsIntoDeckFormDeckList(string deckName){
        TextAsset deckList = (TextAsset)Resources.Load(deckName, typeof(TextAsset));
        string content = deckList.text;
        string[] playersDecks = content.Split('#');
        loadCardsFormDeckListPlayerString(playersDecks[0], 0);
        loadCardsFormDeckListPlayerString(playersDecks[1], 1);
        _deck.shuffle();
   }

   private void loadCardsFormDeckListPlayerString( string deckList, int playerID){
       string[] deckListSplit =  deckList.Split(',');
       foreach (var cardID in deckListSplit)
        {
            _deck.addCard(loadCard(int.Parse(cardID), playerID));
        }
   }
}

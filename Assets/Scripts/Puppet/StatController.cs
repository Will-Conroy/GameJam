using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(BoxCollider2D))]
public class StatController : MonoBehaviour
{

    /* Events */
    public UnityEvent<int> PuppetHit;
    public UnityEvent<int> PuppetHealed;
    public UnityEvent PuppetNewAction;
    public UnityEvent PuppetNewModification;
    public UnityEvent PuppetKilled;
    public UnityEvent<Dictionary<Card.ColourTypes, int>> PuppetWeaknessUpdated;


    /* Veriables */
    [SerializeField] private int maxHealth;
    private int health;
    Dictionary <Card.ColourTypes, int> weaknesses;

    
    
   private void Awake()
    {
      Heal(maxHealth);
      weaknesses = new Dictionary<Card.ColourTypes, int>(){
          {Card.ColourTypes.Red, 0},
          {Card.ColourTypes.Yellow, 0},
          {Card.ColourTypes.Blue, 0},
          {Card.ColourTypes.Colourless, 0},
      };
      PuppetWeaknessUpdated?.Invoke(weaknesses);
    }

    private void Update(){
        //Damage(1);
        //Heal(1);
        //UpdateWeekness(Card.ColourTypes.Blue, 1);
        Dictionary<Card.ColourTypes, int> weaknessesChange = new Dictionary<Card.ColourTypes, int>(){
          {Card.ColourTypes.Red, 1},
          {Card.ColourTypes.Yellow, -1},
          {Card.ColourTypes.Blue, 3},
          {Card.ColourTypes.Colourless, 3},
        };
        //UpdateWeeknesses(weaknessesChange); 
    }

    public void Damage(int amount){
        health -= amount;
        if (amount < 1)
            Kill(); 
        PuppetHit?.Invoke(health);
    }

    public void Heal(int amount){

        health += amount; 

        if(health > maxHealth)
            health = maxHealth;

        PuppetHealed?.Invoke(health);
    }

    private void Kill(){
        PuppetKilled?.Invoke();
    }
    /**
     amount is the value added on 
    **/
    public void UpdateWeekness(Card.ColourTypes type, int amount){
        weaknesses[type] = NegativeStop(weaknesses[type], amount);

        PuppetWeaknessUpdated?.Invoke(weaknesses);
    }

    private int NegativeStop(int valueStart, int operand){
        int newValue = valueStart + operand;
        if(newValue < 0)
            return 0;
        return newValue;
    }

    public void UpdateWeeknesses(Dictionary<Card.ColourTypes, int> weaknessesAmount){
        foreach( KeyValuePair<Card.ColourTypes, int> weaknessAmount in weaknessesAmount )
        {
            weaknesses[weaknessAmount.Key] = NegativeStop(weaknesses[weaknessAmount.Key], weaknessAmount.Value);
        }
         PuppetWeaknessUpdated?.Invoke(weaknesses);
    }



}

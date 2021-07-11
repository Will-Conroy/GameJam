using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect {
    /*---- ENUMS ----*/
       public enum EffectType{
        Mana,
        Draw,
        EquipPuppet
    }
    
    
    /*---- Veriables ----*/
    protected EffectType type;


    /*---- Initialization ----*/


    /*---- Methods ----*/
    public virtual void activateEffect()
    {

    }

    //NEEDS Implamention
    public virtual Command constructCommand(List<GameObject> targets)
    {
        return null;
    }


    /*---- Getters & Setters ----*/
    public EffectType getType()
    {
        return type;
    }  
}

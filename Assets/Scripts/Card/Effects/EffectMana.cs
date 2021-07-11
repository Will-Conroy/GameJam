using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMana : CardEffect
{
    /*---- Initialization ----*/
       public EffectMana()
    {
        type = EffectType.Mana;
    }


    /*---- Methods ----*/
       public override void activateEffect()
    {
        //add mana to the relevant mana pool
    }
}

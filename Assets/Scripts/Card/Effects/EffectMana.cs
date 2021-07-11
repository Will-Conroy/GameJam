using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMana : CardEffect
{

    public EffectMana()
    {
        type = EffectType.Mana;
    }

    public override void activateEffect()
    {
        //add mana to the relevant mana pool
    }

}

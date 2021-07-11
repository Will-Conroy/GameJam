using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect {
    protected EffectType type;

    public enum EffectType{
        Mana,
        Draw,
        GuyStuff
    }

    public EffectType getType()
    {
        return type;
    }

    public virtual void activateEffect()
    {

    }
}

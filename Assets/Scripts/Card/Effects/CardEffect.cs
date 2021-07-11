using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect {
    protected EffectType type;

    public enum EffectType{
        Mana,
        Draw,
        EquipPuppet
    }

    public EffectType getType()
    {
        return type;
    }

    public virtual void activateEffect()
    {

    }


    //NEEDS Implamention
    public virtual Command constructCommand(List<GameObject> targets)
    {
        return null;
    }
}

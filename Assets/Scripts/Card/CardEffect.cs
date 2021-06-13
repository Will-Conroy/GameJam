using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect {
    protected string effectType;

    public string getType()
    {
        return effectType;
    }

    public virtual void activateEffect()
    {

    }
}

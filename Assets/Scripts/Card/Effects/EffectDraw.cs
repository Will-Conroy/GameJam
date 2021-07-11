using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDraw : CardEffect
{

    private int amount;
    public EffectDraw(int amountToDraw)
    {
        amount = amountToDraw;
        type = EffectType.Draw;
    }

    public override void activateEffect()
    {
        //get deck and draw from it
    }

    public override Command constructCommand(List<GameObject> targets){
        return new DrawCommad(new List<GameObject> {GameObject.Find("DeckPrefab")}, amount);
    }
}

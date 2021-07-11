using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaknessUI : MonoBehaviour
{
    /*---- Veriables ----*/
    private TextMeshProUGUI weaknessText;
    private StatController statController;


    /*---- Initialization ----*/
      private void Awake()
    {
        weaknessText = GetComponent<TextMeshProUGUI>();
        statController = GetComponentInParent<StatController>();
        statController.PuppetWeaknessUpdated.AddListener(SetWeaknessText);
    }
    /*---- Methods ----*/
    public void SetWeaknessText(Dictionary<Card.ColourTypes, int> weaknesses){
        string outputText = "--Weakness-- \n";
        foreach( KeyValuePair<Card.ColourTypes, int> weakness in weaknesses )
        {
            outputText += weakness.Key.ToString() + ": " + weakness.Value.ToString() + '\n';
        }
        weaknessText.text = outputText;
    }
}
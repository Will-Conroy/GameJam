using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    /*---- Veriables ----*/
    private TextMeshProUGUI healthText;
    private StatController statController;


    /*---- Initialization ----*/
      private void Awake()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        statController = GetComponentInParent<StatController>();
        statController.PuppetHit.AddListener(SetHealthText);
        statController.PuppetHealed.AddListener(SetHealthText);
    }


    /*---- Methods ----*/
    public void SetHealthText(int health){
        healthText.text = "Health: " + health.ToString();
    }
}
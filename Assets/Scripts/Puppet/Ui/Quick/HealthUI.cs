using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    private StatController statController;

    private void Awake()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        statController = GetComponentInParent<StatController>();
        statController.PuppetHit.AddListener(SetHealthText);
        statController.PuppetHealed.AddListener(SetHealthText);
    }
   
    public void SetHealthText(int health){
        healthText.text = "Health: " + health.ToString();
    }
}
using System.Collections;
using System.Collections.Generic;
using Creatures;
using UnityEngine;
using UnityEngine.UI;

public class StatsUIController : MonoBehaviour {

    public Image healthBar;
    public Image staminaBar;
    public Image hungerBar;
    public Image hungerThresholdBar;
    
    // Start is called before the first frame update
    void Awake() {
      healthBar =  transform.Find("StatsCanvas").Find("HealthBG").Find("HealthBar").gameObject.GetComponent<Image>();
      staminaBar =  transform.Find("StatsCanvas").Find("StaminaBG").Find("StaminaBar").gameObject.GetComponent<Image>();
      hungerBar =  transform.Find("StatsCanvas").Find("HungerBG").Find("HungerBar").gameObject.GetComponent<Image>();
      hungerThresholdBar =  transform.Find("StatsCanvas").Find("HungerBG").Find("HungerThresholdBar").gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        Stats creature = gameObject.GetComponent<Stats>();
        healthBar.fillAmount = creature.health / 100;
        staminaBar.fillAmount = creature.stamina / 100;
        hungerBar.fillAmount = creature.hunger / 100;
        hungerThresholdBar.fillAmount = creature.hungerThreshold / 100;
    }
}
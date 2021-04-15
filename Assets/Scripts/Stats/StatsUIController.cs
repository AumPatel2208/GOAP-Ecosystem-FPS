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
    private Stats creature;
    
    // Start is called before the first frame update
    void Awake() {
       creature = gameObject.GetComponent<Stats>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        healthBar.fillAmount = creature.GetHealth() / 100;
        staminaBar.fillAmount = creature.GetStamina() / 100;
        hungerBar.fillAmount = creature.GetHunger() / 100;
        hungerThresholdBar.fillAmount = creature.GetHungerThreshold() / 100;
    }
}
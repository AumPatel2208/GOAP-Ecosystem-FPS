using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUi : MonoBehaviour {
    public Image healthBar;
    public Image staminaBar;
    public Image hungerBar;
    public Stats.Stats playerStats;
    
    // Start is called before the first frame update
    void Start() {
        playerStats = GetComponent<Stats.Stats>();
    }

    // Update is called once per frame
    void Update() {
        healthBar.fillAmount = playerStats.GetHealth() / 100;
        staminaBar.fillAmount = playerStats.GetStamina() / 100;
        hungerBar.fillAmount = playerStats.GetHunger() / 100;
    }
}
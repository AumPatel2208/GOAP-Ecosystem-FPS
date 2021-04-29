using System;
using UnityEngine;
using UnityEngine.UI;

namespace Stats {
    public class StatsUIController : MonoBehaviour {
        // images that contain the sprite for the health
        public  Image healthBar;
        public  Image staminaBar;
        public  Image hungerBar;
        public  Image hungerThresholdBar;
        private Stats creatureStats;

        // to disable UI element when the creature dies
        private bool _enabled = true;

        void Awake() {
            creatureStats = gameObject.GetComponent<Stats>();
        }

        private void Update() {
            if (_enabled && creatureStats.IsDead()) {
                _enabled = false;
                healthBar.transform.parent.gameObject.SetActive(false);
            }
        }

        void FixedUpdate() {
            // change the fill amount
            healthBar.fillAmount = creatureStats.GetHealth() / 100;
            staminaBar.fillAmount = creatureStats.GetStamina() / 100;
            hungerBar.fillAmount = creatureStats.GetHunger() / 100;
            hungerThresholdBar.fillAmount = creatureStats.GetHungerThreshold() / 100;
        }
    }
}
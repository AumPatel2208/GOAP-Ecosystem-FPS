using System;
using UnityEngine;
using UnityEngine.UI;

namespace Stats {
    public class StatsUIController : MonoBehaviour {

        public Image healthBar;
        public Image staminaBar;
        public Image hungerBar;
        public Image hungerThresholdBar;
        private global::Stats.Stats creatureStats;

        private bool _enabled = true;
        // Start is called before the first frame update
        void Awake() {
            creatureStats = gameObject.GetComponent<global::Stats.Stats>();
        }

        private void Update() {
            if (_enabled && creatureStats.IsDead()) {
                _enabled = false;
                healthBar.transform.parent.gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void FixedUpdate() {
            healthBar.fillAmount = creatureStats.GetHealth() / 100;
            staminaBar.fillAmount = creatureStats.GetStamina() / 100;
            hungerBar.fillAmount = creatureStats.GetHunger() / 100;
            hungerThresholdBar.fillAmount = creatureStats.GetHungerThreshold() / 100;
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace Stats {
    public class StatsUIController : MonoBehaviour {

        public Image healthBar;
        public Image staminaBar;
        public Image hungerBar;
        public Image hungerThresholdBar;
        private global::Stats.Stats creature;
    
        // Start is called before the first frame update
        void Awake() {
            creature = gameObject.GetComponent<global::Stats.Stats>();
        }

        // Update is called once per frame
        void FixedUpdate() {
            healthBar.fillAmount = creature.GetHealth() / 100;
            staminaBar.fillAmount = creature.GetStamina() / 100;
            hungerBar.fillAmount = creature.GetHunger() / 100;
            hungerThresholdBar.fillAmount = creature.GetHungerThreshold() / 100;
        }
    }
}
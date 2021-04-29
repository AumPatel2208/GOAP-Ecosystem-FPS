using Creatures;
using Pathfinding;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Stats {
    public class Stats : MonoBehaviour {
        public float health              = 100;
        public float healthRegenRate     = 2;
        public float healthThreshold     = 50; // unused
        public float hunger              = 100;
        public float hungerDepletionRate = 2; // unused
        public float hungerThreshold     = 80f;
        public float stamina             = 100;
        public float staminaRegenRate    = 2;

        public float moveSpeed = 5;

        // threats unused
        public float   threatLevel = 0f;
        public float[] threatThresholds;

        // Particles for the creature it is attached to 
        public GameObject bloodParticle;

        // ragdoll
        private RagdollToggle ragdoll;
        private bool          isThereRagdoll = false;

        // for efficiency to not constantly compare to null
        private bool isGoapAgentNotNull;
        private bool isAIPathNotNull;

        public void Awake() {
            isAIPathNotNull = GetComponent<AIPath>() != null;
            isGoapAgentNotNull = GetComponent<GoapAgent>() != null;
            ragdoll = GetComponent<RagdollToggle>();
            if (ragdoll != null) {
                isThereRagdoll = true;
            }
        }

        public void Update() {
            if (IsDead()) {
                Death();
            }

            // if over max hunger amount
            if (hunger > 100) {
                // add to health remove from hunger
                var val = Time.deltaTime * healthRegenRate;
                health += val;
                hunger -= val;
            }

            // limit health
            if (health > 100) {
                health = 100;
            }

            // regen stamina
            stamina += staminaRegenRate * Time.deltaTime;
            if (stamina > 100) {
                stamina = 100;
            }
        }

        public void SetHealth(float amount) {
            health = amount;
        }

        // apply damage without particles
        public void ApplyDamage(float damage) {
            health -= damage;
        }

        // apply damage and spawn particles
        public void ApplyDamage(float damage, Vector3 centerPosition, Quaternion rotation) {
            health -= damage;
            SpawnBloodParticles(centerPosition, rotation);
        }

        public void DepleteHunger(float decrement) {
            hunger -= decrement;
        }

        public void AddFoodAmount(float amount) {
            hunger += amount;
        }

        public bool IsHungry() {
            return hunger < hungerThreshold;
        }

        public float GetHealth() {
            return health;
        }

        public float GetStamina() {
            return stamina;
        }

        public void ApplyStaminaReduction(float staminaCost) {
            stamina -= staminaCost;
        }


        public float GetHunger() {
            return hunger;
        }

        public float GetHungerThreshold() {
            return hungerThreshold;
        }

        /* threats unused */
        public void IncreaseThreatLevel(float amount) {
            threatLevel += amount;
        }

        public float GetThreatLevel() {
            return threatLevel;
        }

        public int IsThreatPastThreshold() {
            for (int i = 0; i < threatThresholds.Length; i++) {
                if (threatLevel > threatThresholds[i])
                    return i;
            }

            return -1;
        }

        // whether the creature is dead
        public bool IsDead() {
            return health <= 0;
        }

        // get a speed relative to time
        public float GetProperSpeed() {
            return moveSpeed * Time.deltaTime;
        }

        // if they die, we want to deactivate most things and let them be eaten
        private void Death() {
            if (isThereRagdoll) {
                ragdoll.EnableRagdoll(true);
                if (isGoapAgentNotNull)
                    GetComponent<GoapAgent>().enabled = false;
                if (isAIPathNotNull)
                    GetComponent<AIPath>().enabled = false;
            }

            // if the player dies then restart the scene
            if (gameObject.CompareTag("player")) {
                // restart the scene
                SceneManager.LoadScene("Testing");
            }
        }

        // spawn blood particles
        private void SpawnBloodParticles(Vector3 centerPosition, Quaternion rotation) {
            Instantiate(bloodParticle, centerPosition, rotation);
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Stats {
    public class FoodStats : MonoBehaviour {
        public float foodAmount = 10f;
        public float totalFoodAmount = 100f;
        // public bool isEaten = false;
        // public bool requiresKilling = false;
        public bool isReadyToEat = true;

        public GameObject foodParticles;
    
        private void Start() {
            if (isReadyToEat) {
                gameObject.GetComponent<global::Stats.Stats>().SetHealth(0f);
            }
        
            // Get default particles if they haven't been set
            if (foodParticles == null) {
                // foodParticles = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Particles/FoodParticles.prefab");
            }
        }

        public bool isEaten() {
            return totalFoodAmount <= 0f;
        }
    
        private void Update() {
            isReadyToEat = gameObject.GetComponent<global::Stats.Stats>().IsDead();
        
            // Destroy this as this food is finished
            if (isEaten()) {
                // if it is the player then restart the scene
                if (gameObject.CompareTag("player")) {
                    // restart the scene
                    SceneManager.LoadScene("Testing");
                }
                else {
                    // destroy the game object
                    Destroy(gameObject);
                }
            }
        }

        public void DepleteTotalFoodAmount(float amount) {
            totalFoodAmount -= amount;
        }   
        public void DepleteTotalFoodAmount() {
            totalFoodAmount -= foodAmount;
        }   
        public void DepleteTotalFoodAmount(Vector3 centerPosition, Quaternion rotation) {
            totalFoodAmount -= foodAmount;
            SpawnFoodParticles(centerPosition, rotation);
        }
    
        public void SpawnFoodParticles(Vector3 centerPosition, Quaternion rotation) {
            Instantiate(foodParticles, centerPosition, rotation);
        }
    
    }
}
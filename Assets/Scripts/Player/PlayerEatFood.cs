using Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Player {
    public class PlayerEatFood : MonoBehaviour {
        private Stats.Stats stats;

        // Raycast info
        private float thickness = 1f; // thickness/radius of the raycast
        private Vector3 origin;
        private Vector3 direction;
        private float maxDistance = 2.5f; // max distance that the ray can go
        public LayerMask lifeLayerMask; // life layer
        private bool currentUIStatus = true; // true is showing. should toggle off instantly in the update method

        public Text interactUI;

        private void Awake() {
            // cache references
            stats = GetComponent<Stats.Stats>();
            // Get the layer mask the creatures are in
            lifeLayerMask = LayerMask.GetMask("Life");
            // get the ui element; not the most elegant way
            interactUI = GameObject.Find("Text_E").GetComponent<Text>();
        }

        // toggle the UI element to interact with food
        private void toggleUI(bool isActive) {
            if (isActive != currentUIStatus) {
                interactUI.enabled = isActive;
                currentUIStatus = isActive;
            }
        }

        // Update is called once per frame
        void Update() {
            direction = Camera.main.transform.forward;
            origin = Camera.main.transform.position;
            RaycastHit hit;
            if (Physics.SphereCast(origin, thickness, direction, out hit, maxDistance, lifeLayerMask)) {
                // NOTE : WILL NOT WORK IF THE FOOD IS NOT ON THE ROOT
                // Debug.Log(hit.transform.root.gameObject.name);
                // interact with it
                // press E to eat
                if (hit.transform.root.GetComponent<FoodStats>() != null) {
                    if (hit.transform.root.GetComponent<FoodStats>().isReadyToEat) {
                        toggleUI(true);

                        if (Input.GetKeyDown(KeyCode.E)) {
                            stats.AddFoodAmount(hit.transform.root.GetComponent<FoodStats>().foodAmount);
                            // hit.transform.root.GetComponent<FoodStats>().SpawnFoodParticles(hit.transform.position, hit.transform.rotation);
                            hit.transform.root.GetComponent<FoodStats>().DepleteTotalFoodAmount(hit.transform.position, hit.transform.rotation);
                        }
                    }
                }
            }
            else {
                toggleUI(false);
            }
        }
    }
}
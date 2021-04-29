using Creatures.Actions;
using UnityEngine;

namespace Creatures {
    // randomly call find food action to change the target if a better target is available
    public class RandomlyCallFindFood : MonoBehaviour {
        // frequency to call the find food
        public  float callFrequency = 2f;
        private float callTimer     = 0f;

        private Action_FindFood findFoodAction;

        // Start is called before the first frame update
        void Start() {
            findFoodAction = GetComponent<Action_FindFood>();
            // the timer is randomised by a range of 1 - 5 seconds
            callTimer = callFrequency + Random.Range(-1f, 3f);
        }

        // Update is called once per frame
        void Update() {
            if (callTimer > 0f) {
                // decrement timer
                callTimer -= Time.deltaTime;
            }
            else {
                // perform the action at the end of the timer
                findFoodAction.perform(gameObject);
                // reset the timer
                callTimer = callFrequency + Random.Range(-1f, 3f);
            }
        }
    }
}
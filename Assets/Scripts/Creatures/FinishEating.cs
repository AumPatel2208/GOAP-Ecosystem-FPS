using System;
using Creatures.Actions;
using Pathfinding;
using Stats;
using UnityEngine;

namespace Creatures {
    public class FinishEating : MonoBehaviour {
        // if it is in progress eating
        private bool isInProgress;

        // to set the destination for AIPath movement controller
        private AIDestinationSetter destinationSetter;

        // the eat food action
        private Action_EatFood eatAction;

        // the food to eat
        private Food food;

        private void Start() {
            // cache references to the components
            food = GetComponent<Food>();
            destinationSetter = GetComponent<AIDestinationSetter>();
            eatAction = GetComponent<Action_EatFood>();
        }

        private void Update() {
            if (!isInProgress) {
                if (destinationSetter.target == null && food.targetFood != null) {
                    // go eat it 
                    destinationSetter.target = food.targetFood.transform;
                    isInProgress = true;
                }
            }
            // finish eating
            else {
                // if within the distance than perform the action
                if (destinationSetter.target != null) {
                    if (!gameObject.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Bite")) {
                        if (Vector3.Distance(destinationSetter.target.position, transform.position) < eatAction.radius) {
                            eatAction.perform(gameObject);
                        }

                        isInProgress = true;
                    }
                }
                else {
                    // stop
                    isInProgress = false;
                }
            }
        }

        // getter
        public bool IsInProgress() {
            return isInProgress;
        }

        // to override the eating in progress
        public void StopInProgress() {
            isInProgress = false;
        }
    }
}
using System;
using Creatures.Actions;
using Pathfinding;
using Stats;
using UnityEngine;

namespace Creatures {
    public class FinishEating : MonoBehaviour {
        private bool isInProgress;
        private AIDestinationSetter destinationSetter;
        private Action_EatFood eatAction;
        private Food food;

        private void Start() {
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
                    if (Vector3.Distance(destinationSetter.target.position, transform.position) < eatAction.radius) {
                        eatAction.perform(gameObject);
                    }

                    isInProgress = true;
                }
                else {
                    isInProgress = false;
                }
            }
        }

        public bool IsInProgress() {
            return isInProgress;
        }

        public void StopInProgress() {
            isInProgress = false;
        }
    }
}
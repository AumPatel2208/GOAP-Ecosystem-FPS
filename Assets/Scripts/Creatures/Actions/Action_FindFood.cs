using System.Collections.Generic;
using UnityEngine;

namespace Creatures.Actions {
    public class Action_FindFood : GoapAction {
        // Start is called before the first frame update

        private HashSet<string> food;


        public GameObject foodTarget = null;

        void Start() {
            // Pre-conditions
            addPrecondition("isHungry", true);

            FoodChain foodChain = GameObject.Find("FoodChain").GetComponent<FoodChain>();
            food = foodChain.GetFood(gameObject.tag);
            // Debug.Log("TAG:" + gameObject.tag + " FOOD: " + food);

            // Effects
            // Either food needs to be destroyed, or it is found
            addEffect("foodFound", true);
        }

        public override void reset() {
            // // might break the program so remove if so
            // foodTarget = null;
        }

        public override bool isDone() {
            return foodTarget != null;
        }

        public override bool checkProceduralPrecondition(GameObject agent) {
            return food != null;
        }

        public override bool perform(GameObject agent) {
            foodTarget = null; // making the foodTarget null here as to reset it, not sure if it works tho

            GameObject tempFoodTarget = null;
            // GameObject.FindGameObjectsWithTag(food[])
            foreach (var f in food) {
                float distance = 0;
                if (tempFoodTarget != null) {
                    distance = Vector3.Distance(tempFoodTarget.transform.position, transform.position);
                }

                foreach (var o in GameObject.FindGameObjectsWithTag(f)) {
                    if (tempFoodTarget == null) {
                        tempFoodTarget = o;
                    }
                    else {
                        // check distance if it is greater than tempFoodTarget's distance
                        if (distance > Vector3.Distance(o.transform.position, transform.position)) {
                            tempFoodTarget = o;
                        }
                    }
                }
            }

            foodTarget = tempFoodTarget;
        
            agent.GetComponent<Creature>().target = foodTarget;
            return foodTarget != null;
        }

        public override bool requiresInRange() {
            return false;
        }
    }
}
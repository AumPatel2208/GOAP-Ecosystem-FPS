using System;
using System.Collections.Generic;
using UnityEngine;

namespace Creatures {
    public class ActionEatFood : GoapAction {
        private HashSet<string> food;

        // private string agentName;
        private bool foodIsEaten = false;

        public ActionEatFood() {
            addPrecondition("isHungry", true);

            addEffect("isHungry", false);
            cost = 1f;
        }

        public void Start() {
            FoodChain foodChain = GameObject.Find("FoodChain").GetComponent<FoodChain>();
            food = foodChain.GetFood(gameObject.tag);
            // Debug.Log("TAG:" + gameObject.tag + " FOOD: " + food);
        }

        public override void reset() {
            foodIsEaten = false;
            target = null;
        }

        public override bool isDone() {
            return foodIsEaten;
        }

        public override bool checkProceduralPrecondition(GameObject agent) {
            //TODO make it food with a different amount of hunger fill up and with a food chain so food is defined
            // TODO Use the FoodChain Object to calculate what is food

            // find a food

            GameObject tempTarget = null;
            // GameObject.FindGameObjectsWithTag(food[])
            foreach (var f in food) {
                float distance = 0;
                if (tempTarget != null) {
                    distance = Vector3.Distance(tempTarget.transform.position, transform.position);
                }
                foreach (var o in GameObject.FindGameObjectsWithTag(f)) {
                    if (tempTarget == null) {
                        tempTarget = o;
                    }
                    else {
                        // check distance if it is greater than tempTarget's distance
                        if (distance > Vector3.Distance(o.transform.position, transform.position)) {
                            tempTarget = o;
                        }
                    }
                }
            }

            // target = GameObject.Find("Food");
            target = tempTarget;

            if (target != null) {
                return true;
            }
            else {
                return false;
            }
        }

        public override bool perform(GameObject agent) {
            Creature currentAgent = agent.GetComponent<Creature>();

            // do the action
            foodIsEaten = true;
            agent.GetComponent<Creature>().hunger += target.GetComponent<Food>().foodAmount;
            return foodIsEaten;
        }

        public override bool requiresInRange() {
            return true;
        }
    }
}
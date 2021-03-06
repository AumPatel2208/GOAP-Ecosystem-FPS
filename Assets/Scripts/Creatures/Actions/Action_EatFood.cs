using System;
using System.Collections.Generic;
using UnityEngine;

namespace Creatures {
    public class Action_EatFood : GoapAction {
        private HashSet<string> food;

        // private string agentName;
        private bool foodIsEaten = false;

        public Action_EatFood() {
            // commented out as need to change this to work separately
            // addPrecondition("isHungry", true);
            addPrecondition("foodFound", true);
            addPrecondition("preyDead", true);

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
           
            target = agent.GetComponent<Creature>().target;
            //
            return target != null;
            // return true;
        }

        public override bool perform(GameObject agent) {
            // Creature currentAgent = agent.GetComponent<Creature>();

            target = agent.GetComponent<Creature>().target;

            if (target== null) {
                return false;
            }
            
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
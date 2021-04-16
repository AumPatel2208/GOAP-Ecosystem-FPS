﻿using Stats;
using UnityEngine;

namespace Creatures.Actions {
    public class Action_EatFood : GoapAction {
        // private string agentName;
        private bool foodIsEaten = false;


        public Action_EatFood() {
            addPrecondition("isHungry", true);
            // addPrecondition("foodIsReady", true);

            addEffect("isHungry", false);
            cost = 1f;
        }

        public override void reset() {
            foodIsEaten = false;
            target = null;
        }

        public override bool isDone() {
            return foodIsEaten;
        }

        public override bool checkProceduralPrecondition(GameObject agent) {
            // target = GameObject.FindGameObjectWithTag("plant");
            target = agent.GetComponent<Food>().targetFood;

            if (gameObject.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Bite")) {
                return false;
            }

            if (target == null)
                return false;

            return target.GetComponent<FoodStats>().isReadyToEat;

        }

        public override bool perform(GameObject agent) {

            if (target== null) {
                return false;
            }
            
            // do the action
            foodIsEaten = true;
            // agent.GetComponent<Stats>().hunger += target.GetComponent<FoodStats>().foodAmount;
            agent.GetComponent<Stats.Stats>().AddFoodAmount(target.GetComponent<FoodStats>().foodAmount); 
            target.GetComponent<FoodStats>().DepleteTotalFoodAmount(target.transform.position, target.transform.rotation);
        
            // animate
            // will only work with the ones with a bite animation
            if (GetComponentInChildren<Animator>() != null) {
                GetComponentInChildren<Animator>().Play("Bite");
            }
        
            // sets the food back to null because it has eaten it
            // agent.GetComponent<Food>().targetFood = null;
            // Debug.Log("EATEN");
               
        
            return foodIsEaten;
        }

        public override bool requiresInRange() {
            return true;
        }
    }
}
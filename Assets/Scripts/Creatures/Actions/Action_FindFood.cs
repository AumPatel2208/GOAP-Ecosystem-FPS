using System.Collections.Generic;
using Stats;
using UnityEngine;

namespace Creatures.Actions {
    public class Action_FindFood : GoapAction {
        private bool foodFound = false;
        private HashSet<string> validFoods;

        public Transform head;
        public LayerMask lifeLayerMask;
        public float sphereRadius = 40;
        public float viewAngle = 90;

        public Action_FindFood() {
            addEffect("foodFound", true);
            // addEffect("isHungry", false);
        }

        public void Start() {
            FoodChain foodChain = GameObject.FindGameObjectWithTag("foodchain").GetComponent<FoodChain>();
            validFoods = foodChain.GetFood(gameObject.tag);
        }

        public override void reset() {
            foodFound = false;
            target = null;
        }

        public override bool isDone() {
            return foodFound;
        }

        public override bool checkProceduralPrecondition(GameObject agent) {
            // target = GameObject.FindGameObjectWithTag("plant");

            return agent.GetComponent<Food>().targetFood == null;
        }

        // will find a food in it's vision cone. will only find foods with colliders
        public override bool perform(GameObject agent) {
            GameObject food = null;

            // all the colliders in the radius
            Collider[] hitColliders = Physics.OverlapSphere(head.position, sphereRadius, lifeLayerMask);
            float selectedFoodDistance = 0;

            foreach (Collider collider in hitColliders) {
                // if (collider.transform.parent == null && !collider.CompareTag(transform.tag)) { // taking this out as to be able to target other enemies of the same species
                if (collider.transform.parent == null ) {
                    
                    // get angle
                    Vector3 targetDir = collider.transform.position - head.position;
                    float angle = Vector3.Angle(targetDir, head.forward);

                    // check the angle
                    if (viewAngle < angle) {
                        // get distance for current food
                        if (food != null) {
                            selectedFoodDistance = Vector3.Distance(food.transform.position, head.position);
                        }

                        foreach (var f in validFoods) {
                            if (collider.gameObject.CompareTag(f)) {
                                if (food == null) {
                                    food = collider.gameObject;
                                }
                                else {
                                    // check distance if it is greater than tempFoodTarget's distance
                                    if (Vector3.Distance(collider.transform.position, transform.position) < selectedFoodDistance) {
                                        food = collider.gameObject;
                                    }
                                }
                            }
                        }
                    }
                }
            }


            if (food == null)
                return false;

            agent.GetComponent<Food>().targetFood = food;
            foodFound = true;
            return true;
        }

        public override bool requiresInRange() {
            return false;
        }
    }
}
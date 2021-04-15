using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // OLD
        /*
        // // Going through all game objects and getting the shortest distance away
        // foreach (var f in validFoods) {
        //
        //     float distance = 0;
        //     if (food != null) {
        //         distance = Vector3.Distance(food.transform.position, transform.position);
        //     }
        //
        //     foreach (var o in GameObject.FindGameObjectsWithTag(f)) {
        //         if (food == null) {
        //             food = o;
        //         }
        //         else {
        //             // check distance if it is greater than tempFoodTarget's distance
        //             if (distance > Vector3.Distance(o.transform.position, transform.position)) {
        //                 food = o;
        //             }
        //         }
        //     }
        // }
        */


        // all the colliders in the radius
        Collider[] hitColliders = Physics.OverlapSphere(head.position, sphereRadius, lifeLayerMask);
        float selectedFoodDistance = 0;

        foreach (Collider collider in hitColliders) {
            if (collider.transform.parent == null && !collider.CompareTag(transform.tag)) {
                // Debug.Log("Collider Name: " + collider.gameObject.name);
                // check angle
                Vector3 targetDir = collider.transform.position - head.position;
                float angle = Vector3.Angle(targetDir, head.forward);


                // Temporarily change the layer of the game object so that it ignores the raycast
                // LayerMask originalLayerMask = gameObject.layer;
                // gameObject.layer = LayerMask.GetMask("Ignore Raycast");
                // bool didRaycastHit = Physics.Raycast(transform.position, targetDir, sphereRadius, lifeLayerMask);
                // gameObject.layer = originalLayerMask;

                // RaycastHit hit;
                // if (Physics.Raycast(transform.position, targetDir, out hit, sphereRadius, lifeLayerMask)) {
                //     Debug.Log("Hit Info: " + hit.transform.name);
                // }

                // && Physics.Raycast(transform.position, targetDir, sphereRadius, lifeLayerMask)
                // && didRaycastHit

                // check the angle
                // does not check if there are obstacles in the way
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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_FindFood : GoapAction {
    private bool foodFound = false;
    private HashSet<string> validFoods;

    public Action_FindFood() {
        addEffect("foodFound", true);

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

    public override bool perform(GameObject agent) {
        GameObject food = null;

        // GameObject tempFoodTarget = null;
        foreach (var f in validFoods) {
            float distance = 0;
            if (food != null) {
                distance = Vector3.Distance(food.transform.position, transform.position);
            }

            foreach (var o in GameObject.FindGameObjectsWithTag(f)) {
                if (food == null) {
                    food = o;
                }
                else {
                    // check distance if it is greater than tempFoodTarget's distance
                    if (distance > Vector3.Distance(o.transform.position, transform.position)) {
                        food = o;
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
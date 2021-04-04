﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Fly : MonoBehaviour, IGoap {
    // public float hunger = 100;
    // public float hungerThreshold = 80;
    // public float moveSpeed = 2;
    public Stats stats;
    // public GameObject targetFood;

    private void Awake() {
        if (gameObject.GetComponent<Stats>() == null)
            stats = gameObject.AddComponent<Stats>();
    }

    // Start is called before the first frame update
    void Start() {
    }

    private void FixedUpdate() {
        // stats.hunger -= 0.01f;
        stats.DepleteHunger(0.01f);
    }


    public HashSet<KeyValuePair<string, object>> getWorldState() {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();
        worldData.Add(new KeyValuePair<string, object>("isHungry", stats.IsHungry()));
        worldData.Add(new KeyValuePair<string, object>("foodFound", (gameObject.GetComponent<Food>().targetFood != null)));

        return worldData;
    }

    public HashSet<KeyValuePair<string, object>> createGoalState() {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();

        goal.Add(new KeyValuePair<string, object>("isHungry", false));
        goal.Add(new KeyValuePair<string, object>("foodFound", true));

        return goal;
    }

    // MOVE
    public bool moveAgent(GoapAction nextAction) {
        // move towards the NextAction's target
        float step = stats.GetProperSpeed();

        float distance = Vector3.Distance(gameObject.transform.position, nextAction.target.transform.position);
        // check the distance of the player
        if (distance < nextAction.radius) {
            // we are at the target location, we are done
            nextAction.setInRange(true);
            return true;
        }
        else {
            // Debug.Log("Distance: " + distance);
            // Debug.Log("NextAction Radius: " + nextAction.radius);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextAction.target.transform.position, step);
            return false;
        }
    }


    public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal) {
        // throw new NotImplementedException();
        Debug.Log(gameObject.name + ": <color=red>Plan Failed</color> " + GoapAgent.prettyPrint(failedGoal));
    }


    public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions) {
        // Yay we found a plan for our goal
        Debug.Log(gameObject.name + ": <color=green>Plan found</color> " + GoapAgent.prettyPrint(actions));
    }

    public void actionsFinished() {
        // Everything is done, we completed our actions for this gool. Hooray!
        Debug.Log(gameObject.name + ": <color=blue>Actions completed</color>");
    }

    public void planAborted(GoapAction aborter) {
        // An action bailed out of the plan. State has been reset to plan again.
        // Take note of what happened and make sure if you run the same goal again
        // that it can succeed.
        Debug.Log(gameObject.name + ": <color=red>Plan Aborted</color> " + GoapAgent.prettyPrint(aborter));
    }
}
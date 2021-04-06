using System;
using System.Collections;
using System.Collections.Generic;
using Creatures;
using UnityEngine;
using UnityEngine.Serialization;
using Pathfinding;


public class Sloth : BaseAIGoap {
    public Stats stats;

    private Animator animator;
    private AIDestinationSetter destinationSetter;
    private AIPath movementController;


    private void Awake() {
        if (gameObject.GetComponent<Stats>() == null)
            stats = gameObject.AddComponent<Stats>();
    }

    private void Start() {
        animator = GetComponentInChildren<Animator>();

        destinationSetter = GetComponent<AIDestinationSetter>();
        movementController = GetComponent<AIPath>();
    }

    private void FixedUpdate() {
        // stats.hunger -= 0.01f;
        stats.DepleteHunger(0.01f);
    }


    public override HashSet<KeyValuePair<string, object>> getWorldState() {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();
        worldData.Add(new KeyValuePair<string, object>("isHungry", stats.IsHungry()));
        worldData.Add(new KeyValuePair<string, object>("foodFound", (gameObject.GetComponent<Food>().targetFood != null)));

        return worldData;
    }

    public override HashSet<KeyValuePair<string, object>> createGoalState() {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();

        goal.Add(new KeyValuePair<string, object>("isHungry", false));
        goal.Add(new KeyValuePair<string, object>("foodFound", true));

        return goal;
    }

    // MOVE
    public override bool moveAgent(GoapAction nextAction) {
        // move towards the NextAction's target
        float step = stats.GetProperSpeed();

        float distance = Vector3.Distance(gameObject.transform.position, nextAction.target.transform.position);
        // check the distance of the player
        if (distance < nextAction.radius) {
            // we are at the target location, we are done
            nextAction.setInRange(true);

            // set astar target to null
            destinationSetter.target = null;

            // stop moving
            movementController.canMove = false;

            // animate
            // idle
            animator.SetBool("Moving", false);

            return true;
        }
        else {
            if (destinationSetter.target == null) {
                destinationSetter.target = nextAction.target.transform;
            }

            movementController.canMove = true;

            // animate
            // walk
            animator.SetBool("Moving", true);

            // gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextAction.target.transform.position, step);
            return false;
        }
    }


}
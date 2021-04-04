using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Sabertooth : MonoBehaviour, IGoap {
    public bool enableDebugging = true;

    public Stats stats;

    private Animator animator;
    private AIDestinationSetter destinationSetter;
    private AIPath movementController;

    private static readonly int anim_MovementState = Animator.StringToHash("Movement State");

    private void Awake() {
        if (gameObject.GetComponent<Stats>() == null)
            stats = gameObject.AddComponent<Stats>();
    }

    // Start is called before the first frame update
    void Start() {
        // get rid of the IF as I would like an error if it doesnt work
        // if (gameObject.GetComponent<Animator>() != null)
        animator = GetComponent<Animator>();

        destinationSetter = GetComponent<AIDestinationSetter>();
        movementController = GetComponent<AIPath>();
    }

    private void FixedUpdate() {
        // stats.hunger -= 0.01f;
        stats.DepleteHunger(0.01f);
    }


    public HashSet<KeyValuePair<string, object>> getWorldState() {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();
        worldData.Add(new KeyValuePair<string, object>("isHungry", stats.IsHungry()));
        worldData.Add(new KeyValuePair<string, object>("foodFound", (gameObject.GetComponent<Food>().targetFood != null)));

        worldData.Add(gameObject.GetComponent<Food>().targetFood != null
            ? new KeyValuePair<string, object>("foodIsReady", (gameObject.GetComponent<Food>().targetFood.GetComponent<FoodStats>().isReadyToEat))
            : new KeyValuePair<string, object>("foodIsReady", true));


        return worldData;
    }

    public HashSet<KeyValuePair<string, object>> createGoalState() {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();

        goal.Add(new KeyValuePair<string, object>("isHungry", false));
        goal.Add(new KeyValuePair<string, object>("foodFound", true));
        goal.Add(new KeyValuePair<string, object>("foodIsReady", true));

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

            // set astar target to null
            destinationSetter.target = null;

            // stop moving
            movementController.canMove = false;

            // animate
            // idle
            animator.SetInteger(anim_MovementState, 0);

            return true;
        }
        else {
            // var damping = 2;
            // var lookPos = nextAction.target.transform.position - transform.position;
            // lookPos.y = 0;
            // var rotation = Quaternion.LookRotation(lookPos);
            // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            //
            // gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextAction.target.transform.position, step);


            if (destinationSetter.target == null) {
                destinationSetter.target = nextAction.target.transform;
            }

            movementController.canMove = true;

            // animate
            // walk
            animator.SetInteger(anim_MovementState, 1);

            return false;
        }
    }


    public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal) {
        Debug.Log(gameObject.name + ": <color=red>Plan Failed</color> " + GoapAgent.prettyPrint(failedGoal));
    }

    public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions) {
        // Yay we found a plan for our goal
        Debug.Log(gameObject.name + ": <color=green>Plan found</color> " + GoapAgent.prettyPrint(actions));
    }

    public void actionsFinished() {
        // Everything is done, we completed our actions for this gool.
        Debug.Log(gameObject.name + ": <color=blue>Actions completed</color>");
    }

    public void planAborted(GoapAction aborter) {
        // An action bailed out of the plan. State has been reset to plan again.
        // Take note of what happened and make sure if you run the same goal again
        // that it can succeed.
        Debug.Log(gameObject.name + ": <color=red>Plan Aborted</color> " + GoapAgent.prettyPrint(aborter));
    }
}
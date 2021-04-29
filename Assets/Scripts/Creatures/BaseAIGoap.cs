using System.Collections.Generic;
using UnityEngine;

namespace Creatures {
    // This class inherits IGOAP to provide implementation for methods on finishing the plans.
    public abstract class BaseAIGoap : MonoBehaviour, IGoap {
        // if this is true then print output to console
        public bool enableDebugging = true;

        // world state of the agent
        public abstract HashSet<KeyValuePair<string, object>> getWorldState();

        // desired goal state of the agent 
        public abstract HashSet<KeyValuePair<string, object>> createGoalState();

        // implement this method by having a check to print the output or not
        public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal) {
            if (enableDebugging)
                Debug.Log(gameObject.name + ": <color=red>Plan Failed</color> " + GoapAgent.prettyPrint(failedGoal));
        }

        // similar thing applied to following methods
        public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions) {
            // found a plan for our goal
            if (enableDebugging)
                Debug.Log(gameObject.name + ": <color=green>Plan found</color> " + GoapAgent.prettyPrint(actions));
        }

        public void actionsFinished() {
            // Everything is done, we completed our actions for this goal.
            if (enableDebugging)
                Debug.Log(gameObject.name + ": <color=blue>Actions completed</color>");
        }

        public void planAborted(GoapAction aborter) {
            // An action bailed out of the plan. State has been reset to plan again.
            // Take note of what happened and make sure if you run the same goal again
            // that it can succeed.
            if (enableDebugging)
                Debug.Log(gameObject.name + ": <color=red>Plan Aborted</color> " + GoapAgent.prettyPrint(aborter));
        }

        public abstract bool moveAgent(GoapAction nextAction);

        // this is a method I created which will be different for different agents, it performs all the things to start and stop moving the agent
        public abstract void StartMoving(bool toMove, Transform target);
    }
}
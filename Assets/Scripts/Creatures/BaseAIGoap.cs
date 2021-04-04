using System.Collections.Generic;
using UnityEngine;

namespace Creatures {
    public abstract class BaseAIGoap : MonoBehaviour, IGoap {
        public bool enableDebugging = true;

        public abstract HashSet<KeyValuePair<string, object>> getWorldState();

        public abstract HashSet<KeyValuePair<string, object>> createGoalState();

        public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal) {
            if(enableDebugging)
                Debug.Log(gameObject.name + ": <color=red>Plan Failed</color> " + GoapAgent.prettyPrint(failedGoal));
        }

        public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions) {
            // found a plan for our goal
            if(enableDebugging)
                Debug.Log(gameObject.name + ": <color=green>Plan found</color> " + GoapAgent.prettyPrint(actions));
        }

        public void actionsFinished() {
            // Everything is done, we completed our actions for this goal.
            if(enableDebugging)
                Debug.Log(gameObject.name + ": <color=blue>Actions completed</color>");


        }

        public void planAborted(GoapAction aborter) {
            // An action bailed out of the plan. State has been reset to plan again.
            // Take note of what happened and make sure if you run the same goal again
            // that it can succeed.
            if(enableDebugging)
                Debug.Log(gameObject.name + ": <color=red>Plan Aborted</color> " + GoapAgent.prettyPrint(aborter));
        }

        public abstract bool moveAgent(GoapAction nextAction);
    }
}
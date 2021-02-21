using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Creatures {
    public abstract class Creature : MonoBehaviour, IGoap {

        public float health = 100;
        public float healthRegenRate = 2;
        public float healthThreshold = 50;
        public float hunger = 100;
        public float hungerDepletionRate = 2;
        public float hungerThreshold = 0.5f;
        public float stamina = 100;
        public float staminaRegenRate = 2;
        public float moveSpeed = 5;

        // public food chain

        public HashSet<KeyValuePair<string, object>> getWorldState() {
            HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();

            worldData.Add(new KeyValuePair<string, object>("isHungry", (hunger < hungerThreshold)));
            // worldData.Add(new KeyValuePair<string, object>("isHurt", (health < healthThreshold)));

            // TODO implement does a threat exist
            // worldData.Add(new KeyValuePair<string, object>("noThreatExists", true));

            return worldData;
        }




        public HashSet<KeyValuePair<string, object>> createGoalState() {
            // create the desired goal state
            HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();
            // goal.Add(new KeyValuePair<string, object>("eatFood", true));
            // goal.Add(new KeyValuePair<string, object>("noThreatExists", true));
            goal.Add(new KeyValuePair<string, object>("isHungry", false));

            return goal;
        }

        public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal) {
            // throw new System.NotImplementedException();
            // Not handling this here since we are making sure our goals will always succeed.
            // But normally you want to make sure the world state has changed before running
            // the same goal again, or else it will just fail.
        }

        public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions) {
            // Yay we found a plan for our goal
            Debug.Log("<color=green>Plan found</color> " + GoapAgent.prettyPrint(actions));
        }

        public void actionsFinished() {
            // Everything is done, we completed our actions for this gool. Hooray!
            Debug.Log("<color=blue>Actions completed</color>");
        }

        public void planAborted(GoapAction aborter) {
            // An action bailed out of the plan. State has been reset to plan again.
            // Take note of what happened and make sure if you run the same goal again
            // that it can succeed.
            Debug.Log("<color=red>Plan Aborted</color> " + GoapAgent.prettyPrint(aborter));
        }

        public abstract bool moveAgent(GoapAction nextAction);
    }
}
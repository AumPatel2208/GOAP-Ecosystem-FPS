using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using Vector3 = UnityEngine.Vector3;

namespace Creatures {
    public class Lizard : MonoBehaviour, IGoap {
        public float moveSpeed = 1;
        public float hunger = 1;
        public float hungerThreshold = 0.5f;
        public float stamina = 100;

        // the starting states, will also specify what data is even looked at.
        // data the will feed the goap actions when planning
        public HashSet<KeyValuePair<string, object>> getWorldState() {
            HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();

            worldData.Add(new KeyValuePair<string, object>("damagePlayer", false)); //to-do: change player's state for world data here

            worldData.Add(new KeyValuePair<string, object>("isHungry", (hunger > hungerThreshold)));

            return worldData;
        }

        public HashSet<KeyValuePair<string, object>> createGoalState() {
            // create the desired goal state
            HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();
            goal.Add(new KeyValuePair<string, object>("damagePlayer", true));
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

        public bool moveAgent(GoapAction nextAction) {
            // move towards the NextAction's target
            float step = moveSpeed * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextAction.target.transform.position, step);

            // check the distance of the player
            // TODO should figure a way around the casting
            if (Vector3.Distance(gameObject.transform.position, nextAction.target.transform.position) < ((LizardAttackAction) nextAction).radius) {
                // we are at the target location, we are done
                nextAction.setInRange(true);
                return true;
            }
            else
                return false;
        }
    }
}
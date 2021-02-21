using System;
using System.Collections.Generic;
using UnityEngine;

namespace Creatures {
    public class Lizard : Creature {
        public LizardMove lizardMove;

        public void Start() {
            
        }

        public HashSet<KeyValuePair<string, object>> getWorldState() {
            HashSet<KeyValuePair<string, object>> worldData = base.getWorldState();
            worldData.Add(new KeyValuePair<string, object>("damagePlayer", false)); //to-do: change player's state for world data here
            return worldData;
        }


        public HashSet<KeyValuePair<string, object>> createGoalState() {
            HashSet<KeyValuePair<string, object>> goal = base.createGoalState();
            goal.Add(new KeyValuePair<string, object>("damagePlayer", true));
            return goal;
        }

        public override bool moveAgent(GoapAction nextAction) {
            // move towards the NextAction's target
            float step = moveSpeed * Time.deltaTime;

            if (lizardMove != null) {
                lizardMove.speed = moveSpeed;
            }
            else {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextAction.target.transform.position, step);
            }

            // check the distance of the player
            if (Vector3.Distance(gameObject.transform.position, nextAction.target.transform.position) < nextAction.radius) {
                // we are at the target location, we are done
                nextAction.setInRange(true);
                return true;
            }
            else
                return false;
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Creatures {
    [RequireComponent(typeof(LizardMove))]
    public class Lizard : Creature {
        private LizardMove lizardMove;

        public void Start() {
            // lizardMove = gameObject.GetComponent(typeof(LizardMove)) as LizardMove;
            lizardMove = gameObject.GetComponent<LizardMove>();
            // target = GameObject.Find("Fly");
        }

        public override HashSet<KeyValuePair<string, object>> iGetWorldState() {
            // HashSet<KeyValuePair<string, object>> worldData = base.getWorldState();
            HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();
            // worldData.Add(new KeyValuePair<string, object>("damagePlayer", false)); //to-do: change player's state for world data here

            // worldData.Add(new KeyValuePair<string, object>("foodFound", false))

            //
            // if (target != null) {
            //     worldData.Add(new KeyValuePair<string, object>("preyDead", target.GetComponent<Food>().requiresKilling));
            // }
            // else {
            //     worldData.Add(new KeyValuePair<string, object>("preyDead", true)); // true so it doesnt have to do it
            // }

            if (target != null) {
                worldData.Add(new KeyValuePair<string, object>("preyDead", target.GetComponent<Food>().requiresKilling));
            }
            else {
            }


            return worldData;
        }


        public override HashSet<KeyValuePair<string, object>> iCreateGoalState() {
            // HashSet<KeyValuePair<string, object>> goal = base.createGoalState();
            HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();
            // goal.Add(new KeyValuePair<string, object>("damagePlayer", true));

            goal.Add(new KeyValuePair<string, object>("preyDead", true));

            return goal;
        }

        public override bool moveAgent(GoapAction nextAction) {
            // move towards the NextAction's target
            float step = moveSpeed * Time.deltaTime;

            // check the distance of the player
            if (Vector3.Distance(gameObject.transform.position, nextAction.target.transform.position) < nextAction.radius) {
                // we are at the target location, we are done
                nextAction.setInRange(true);
                return true;
            }
            else {
                if (lizardMove != null) {
                    lizardMove.speed = moveSpeed;
                }
                else {
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextAction.target.transform.position, step);
                }

                return false;
            }
        }
    }
}
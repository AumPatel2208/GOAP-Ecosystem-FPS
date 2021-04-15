using Stats;
using UnityEngine;

namespace Creatures.Actions {
    public class Action_MeleeAttack : GoapAction {
        // private string agentName;
        private bool hasAttacked = false;
        public float attackDamage = 10f;

        public Action_MeleeAttack() {
            addPrecondition("foodFound", true);
            addPrecondition("foodIsReady", false);

            addEffect("foodIsReady", true);
            cost = 1f;
        }

        public override void reset() {
            hasAttacked = false;
            target = null;
        }

        public override bool isDone() {
            return hasAttacked;
        }

        public override bool checkProceduralPrecondition(GameObject agent) {
            // target = GameObject.FindGameObjectWithTag("plant");
            target = agent.GetComponent<Food>().targetFood;
            if (gameObject.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Bite")) {
                return false;
            }
            if (target == null)
                return false;

            return true;

            // if (target.GetComponent<FoodStats>().isReadyToEat)
            //     return true;
            // else
            //     return false;
        }

        public override bool perform(GameObject agent) {
            if (target == null) {
                return false;
            }

            // do the action
            hasAttacked = true;
            target.GetComponent<Stats.Stats>().ApplyDamage(attackDamage, target.transform.position, target.transform.rotation);
            // animate
            if (gameObject.GetComponentInChildren<Animator>() != null) {
                gameObject.GetComponentInChildren<Animator>().Play("Bite");
            }

            return hasAttacked;
        }

        public override bool requiresInRange() {
            return true;
        }
    }
}
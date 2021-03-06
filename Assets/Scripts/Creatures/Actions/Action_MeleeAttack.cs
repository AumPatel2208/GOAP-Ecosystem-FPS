using UnityEngine;

namespace Creatures.Actions {
    public class Action_MeleeAttack : GoapAction {
        private bool attacked = false;
        public float staminaCost = 5f;

        public void Start() {
            // no precondition for this as of now
            
            // effects
            addEffect("preyDead", true);

            cost = 1f;
        }

        public override void reset() {
            target = null;
        }

        public override bool isDone() {
            return attacked;
        }

        public override bool checkProceduralPrecondition(GameObject agent) {
            target = agent.GetComponent<Creature>().target; // get target from parent component
            //
            // // add stamina check here as well
            return target!=null;

            // return true;
        }

        public override bool perform(GameObject agent) {
            // Lizard currentAgent = agent.GetComponent<Lizard> ();
            agent.GetComponent<Creature>().stamina -= staminaCost; // maybe add a stamina cost scaling to the different actions
            
            target = agent.GetComponent<Creature>().target; // get target from parent component
            /*need to add the animation here to move the head.*/

            attacked = true;
            return attacked;
        }

        public override bool requiresInRange() {
            return true;
        }
    }
}
using UnityEngine;

namespace Creatures {
    public class LizardAttackAction : GoapAction {

        private bool attacked = false;
        public float staminaCost = 5f;
        // public float radius = 0.5f;
        
        public LizardAttackAction() {
            // add preconditions
            // should not need to add if in range as that is a common thing it should be handled elsewhere           
            
            // add effects
            addEffect("damagePlayer", true);
            
            // add the cost
            cost = 1f;
        }
        
        
        public override void reset() {
            attacked = false;
            target = null;
        }

        public override bool isDone() {
            return attacked;
        }

        public override bool checkProceduralPrecondition(GameObject agent) {
            target = GameObject.Find("Player");
            Lizard currentAgent = agent.GetComponent<Lizard>();

            if (target!=null) {
                return true;
            }
            else {
                return false;
            }
            
        }

        public override bool perform(GameObject agent) {
            // throw new System.NotImplementedException();
            Lizard currentAgent = agent.GetComponent<Lizard> ();
            currentAgent.stamina -= staminaCost; // maybe add a stamina cost scaling to the different actions

            // Animator currAnim = GetComponentInParent<Animator> ();
            //spellAnim.wrapMode = WrapMode.ClampForever; //done in inspector right now
            
            /*need to add the animation here to move the head.*/
            // currAnim.Play("abigale attack");

            attacked = true;
            return attacked;
        }

        public override bool requiresInRange() {
            // precondition of being in range
            return true;
        }
    }
}
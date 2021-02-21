using UnityEngine;

namespace Creatures {
    public class ActionEatFood : GoapAction {

        private bool foodIsEaten = false;
        public ActionEatFood() {
            addPrecondition("isHungry", true);
            
            addEffect("isHungry", false);
            cost = 1f;
        }
        
        public override void reset() {
            foodIsEaten = false;
            target = null;
        }

        public override bool isDone() {
            return foodIsEaten;
        }

        public override bool checkProceduralPrecondition(GameObject agent) {
            //TODO make it food with a different amount of hunger fill up and with a food chain so food is defined
            target = GameObject.Find("Food");

            if (target!=null) {
                return true;
            }
            else {
                return false;
            }
        }

        public override bool perform(GameObject agent) {
            Creature currentAgent = agent.GetComponent<Creature>();

            // do the action
            foodIsEaten = true;
            agent.GetComponent<Creature>().hunger += target.GetComponent<Food>().foodAmount;
            return foodIsEaten;
        }

        public override bool requiresInRange() {
            return true;
        }
    }
}
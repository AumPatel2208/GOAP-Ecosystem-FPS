using System.Collections.Generic;
using Pathfinding;
using Stats;
using UnityEngine;

namespace Creatures.Agents {
    public class Sabertooth : BaseAIGoap {
        // stats
        public Stats.Stats stats;

        private Animator            animator;
        private AIDestinationSetter destinationSetter;
        private AIPath              movementController;

        // movement state name in the animator
        private static readonly int anim_MovementState = Animator.StringToHash("Movement State");

        private void Awake() {
            // cache a reference to the stats
            if (gameObject.GetComponent<Stats.Stats>() == null)
                stats = gameObject.AddComponent<Stats.Stats>();
        }

        void Start() {
            // cache references to components
            animator = GetComponent<Animator>();
            destinationSetter = GetComponent<AIDestinationSetter>();
            movementController = GetComponent<AIPath>();
        }

        private void FixedUpdate() {
            // deplete the hunger in a fixed update
            stats.DepleteHunger(0.01f);
        }

        public override HashSet<KeyValuePair<string, object>> getWorldState() {
            HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();
            // Hungry world state
            worldData.Add(new KeyValuePair<string, object>("isHungry", stats.IsHungry()));
            // whether there is a food target
            worldData.Add(new KeyValuePair<string, object>("foodFound", (gameObject.GetComponent<Food>().targetFood != null)));

            // if the food is ready or not to eat
            worldData.Add(gameObject.GetComponent<Food>().targetFood != null
                ? new KeyValuePair<string, object>("foodIsReady", (gameObject.GetComponent<Food>().targetFood.GetComponent<FoodStats>().isReadyToEat))
                : new KeyValuePair<string, object>("foodIsReady", true));


            return worldData;
        }

        public override HashSet<KeyValuePair<string, object>> createGoalState() {
            HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();

            // three goal states for this agent
            goal.Add(new KeyValuePair<string, object>("isHungry", false));
            goal.Add(new KeyValuePair<string, object>("foodFound", true));
            goal.Add(new KeyValuePair<string, object>("foodIsReady", true));

            return goal;
        }

        // MOVE
        public override bool moveAgent(GoapAction nextAction) {
            // move towards the NextAction's target
            float step = stats.GetProperSpeed();

            float distance = Vector3.Distance(gameObject.transform.position, nextAction.target.transform.position);

            // check the distance of the player
            if (distance < nextAction.radius) {
                // if we are in range to perform the action, then set in range to true
                nextAction.setInRange(true);
                // stop moving
                StartMoving(false, null);
                return true;
            }
            else {
                // move
                StartMoving(true, nextAction.target.transform);
                return false;
            }
        }

        public override void StartMoving(bool toMove, Transform target) {
            // set astar target to the target
            destinationSetter.target = target;

            // stop moving
            movementController.canMove = toMove;

            // animate
            animator.SetInteger(anim_MovementState, toMove ? 1 : 0);
        }
    }
}
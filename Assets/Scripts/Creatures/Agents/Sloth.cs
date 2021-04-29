using System.Collections.Generic;
using Pathfinding;
using Stats;
using UnityEngine;


namespace Creatures.Agents {
    public class Sloth : BaseAIGoap {
        // stats
        public Stats.Stats stats;

        private Animator animator;
        private AIDestinationSetter destinationSetter;
        private AIPath movementController;
        private GoapAgent goapAgent;
        
        // movement state name in the animator
        private static readonly int hMoving = Animator.StringToHash("Moving");
    
        private void Awake() {
            if (gameObject.GetComponent<Stats.Stats>() == null)
                stats = gameObject.AddComponent<Stats.Stats>();
            goapAgent = GetComponent<GoapAgent>();
        }

        private void Start() {
            animator = GetComponentInChildren<Animator>();

            destinationSetter = GetComponent<AIDestinationSetter>();
            movementController = GetComponent<AIPath>();
        }

        private void FixedUpdate() {
            stats.DepleteHunger(0.01f);
            
        
        
            // Collider[] hitColliders = Physics.OverlapSphere(transform.position, 80, lifeLayerMask);
        }


        public override HashSet<KeyValuePair<string, object>> getWorldState() {
            HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();
            worldData.Add(new KeyValuePair<string, object>("isHungry", stats.IsHungry()));
            worldData.Add(new KeyValuePair<string, object>("foodFound", (gameObject.GetComponent<Food>().targetFood != null)));

            return worldData;
        }

        public override HashSet<KeyValuePair<string, object>> createGoalState() {
            HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();

            goal.Add(new KeyValuePair<string, object>("isHungry", false));
            goal.Add(new KeyValuePair<string, object>("foodFound", true));

            return goal;
        }

        // MOVE
        public override bool moveAgent(GoapAction nextAction) {
            // move towards the NextAction's target
            float step = stats.GetProperSpeed();

            float distance = Vector3.Distance(gameObject.transform.position, nextAction.target.transform.position);
            // check the distance of the player
            if (distance < nextAction.radius) {
                // we are at the target location, we are done
                nextAction.setInRange(true);

                StartMoving(false, null);
                return true;
            }
            else {

                StartMoving(true, nextAction.target.transform);

                return false;
            }
        }

        public override void StartMoving(bool toMove, Transform target) {
        
            // set astar target to null
            destinationSetter.target = target;
        
            // stop moving
            movementController.canMove = toMove;
        
            // animate
            animator.SetBool(hMoving, toMove);
        }
    }
}
using Pathfinding;
using UnityEngine;

namespace Creatures {
    public class RandomlyRoam : MonoBehaviour {
        private GameObject randomPositionObj;
        private AIDestinationSetter destinationSetter;
        public BaseAIGoap creature;

        void Awake() {
            destinationSetter = GetComponent<AIDestinationSetter>();
            creature= GetComponent<BaseAIGoap>();
            randomPositionObj = new GameObject("Random_Position");
        }


        // Update is called once per frame
        void FixedUpdate() {
            Roam();
        }

        private void Roam() {
            // if the destinationSetter's target position is the same as/close to the creature's position then make it null
            if (Vector3.Distance(transform.position, randomPositionObj.transform.position) < 2f) {
                // destinationSetter.target = null;
                creature.StartMoving(false, null);
            }

            // if there is no action, pick a random destination to move to.
            if (destinationSetter.target == null) {
                // https://arongranberg.com/astar/documentation/dev_4_3_8_84e2f938/old/wander.php
                GraphNode randomNode;
                // For grid graphs
                var grid = AstarPath.active.data.gridGraph;
                randomNode = grid.nodes[Random.Range(0, grid.nodes.Length)];
                // Use the center of the node as the destination for example
                var randomNodePosition = (Vector3) randomNode.position;

                randomPositionObj.transform.position = randomNodePosition;
                creature.StartMoving(true, randomPositionObj.transform);
            }
        }
    }
}
﻿using System;
using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Creatures {
    public class RandomlyRoam : MonoBehaviour {
        // to set it to a random position and to use it's transform
        private GameObject          randomPositionObj;
        private AIDestinationSetter destinationSetter;
        // the creature to randomly roam
        public  BaseAIGoap   creature;
        private FinishEating finishEating;
        private bool         isFinishEatingNull;
        
        // frequency and timer to change randomly roam
        public float resetRandomPositionFrequency = 3f;
        private float resetRandomPositionTimer = 0f;


        
        private void Start() {
            // cache references to components
            destinationSetter = GetComponent<AIDestinationSetter>();
            creature = GetComponent<BaseAIGoap>();
            randomPositionObj = new GameObject("Random_Position");
            finishEating = GetComponent<FinishEating>();
            if (finishEating == null)
                isFinishEatingNull = true;

            // set the timer
            resetRandomPositionTimer = resetRandomPositionFrequency + Random.Range(-3f, 3f);
        }


        private void Update() {
            if (isFinishEatingNull) {
                Roam();
            }
            else {
                // if not eating, then roam
                if (!finishEating.IsInProgress()) {
                    Roam();
                }
            } 
        }
  
        private void Roam() {
            // if the destinationSetter's target position is the same as/close to the creature's position then make it null
            if (Vector3.Distance(transform.position, randomPositionObj.transform.position) < 2f) {
                creature.StartMoving(false, null);
            }
            
            // if the timer is over it will make the target null and find a new one
            if (resetRandomPositionTimer > 0f) {
                resetRandomPositionTimer -= Time.deltaTime;
            }
            else {
                creature.StartMoving(false, null);
                resetRandomPositionTimer = resetRandomPositionFrequency + Random.Range(-3f, 3f);
            }

            // before randomly roaming, see if there is a food available and start going there and eat it.

            // if there is no action, pick a random destination to move to.
            if (destinationSetter.target == null) {
                // from documentation for the library : https://arongranberg.com/astar/documentation/dev_4_3_8_84e2f938/old/wander.php
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
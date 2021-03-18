using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class AStarMovement : MonoBehaviour {
    public Transform targetPosition;
    private Seeker seeker;
    private CharacterController controller;

    public Path path;
    public float speed = 2;
    public float nextWaypointDistance = 3;
    private int currentWaypoint = 0;
    public bool reachedEndOfPath;
    

    public void Start() {
        // Get a refrence to the seeker component
         seeker= GetComponent<Seeker>();
    
         // using Unity's built in character controller to move the Agent
         controller = GetComponent<CharacterController>();

        // Start to calculate a new path to the targetPosition object, return the result to the OnPathComplete method.
        // Path requests are asynchronous(may take a few frames), so when the OnPathComplete method is called depends on how long it
        // takes to calculate the path. Usually it is called the next frame.
        seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
    }

    public void OnPathComplete(Path p) {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);

        if (!p.error) {
            path = p;
            // reset the current waypoint counter so we start to move towards the first point in the path
            currentWaypoint = 0;
        }
    }

    public void Update() {
        if (path == null) {
            // we have no path so don't do anything
            return;
        }
        
        // Check in a loop if we are close enough to the current waypoint to switch to the next one.
        // We do this in a loop because many waypoints might be close to each other and we may reach
        // several of them in the same frame.
        reachedEndOfPath = false;
        // The distance to the next waypoint in the path
        float distanceToWaypoint;
        
        while (true) {
            // If you want maximum performance you can check the squared distance instead to get rid of a
            // square root calculation. But that is outside the scope of this tutorial.
            distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWaypoint < nextWaypointDistance) {
                // Check if there is another waypoint or if we have reached the end of the path
                if (currentWaypoint + 1 < path.vectorPath.Count) {
                    currentWaypoint++;
                } else {
                    // Set a status variable to indicate that the agent has reached the end of the path.
                    // You can use this to trigger some special code if your game requires that.
                    reachedEndOfPath = true;
                    break;
                }
            } else {
                break;
            }
        }
        
        // Slow down smoothly upon approaching the end of the path
        // This value will smoothly go from 1 to 0 as the agent approaches the last waypoint in the path.
        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint/nextWaypointDistance) : 1f;

        // Direction to the next waypoint
        // Normalize it so that it has a length of 1 world unit
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        // Multiply the direction by our desired speed to get a velocity
        Vector3 velocity = dir * speed * speedFactor;

        // Move the agent using the CharacterController component
        // Note that SimpleMove takes a velocity in meters/second, so we should not multiply by Time.deltaTime
        controller.SimpleMove(velocity);

        // If you are writing a 2D game you should remove the CharacterController code above and instead move the transform directly by uncommenting the next line
        // transform.position += velocity * Time.deltaTime;
    }
}
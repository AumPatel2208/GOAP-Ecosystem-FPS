using System.Collections;
using System.Collections.Generic;
using Creatures;
using UnityEngine;

public class Fly : Creature {
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
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextAction.target.transform.position, step);
            return false;
        }
    }
}
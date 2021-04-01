using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Roam : GoapAction {
    public float searchRadius = 20f;
    public Action_Roam() {
        
        addEffect("needToRoam", false);
        cost = 10f;
    }
    
    public override void reset() {
        target = null;
    }

    public override bool isDone() {
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent) {
        // pick a random spot on the path.
        target = 
        
        return true;
    }
    
    Vector3 PickRandomPoint () {
        var point = Random.insideUnitSphere * radius;
        point.y = 0;
        point += transform.position;
        return point;
    }

    
    public override bool perform(GameObject agent) {
        return true;
    }

    public override bool requiresInRange() {
        return true;
    }
}
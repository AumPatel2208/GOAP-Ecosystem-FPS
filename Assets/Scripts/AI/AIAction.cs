using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : MonoBehaviour {
    
    // Properties
    
    // // Preconditions
    private Dictionary<String, bool> preconditions;
    
    // // Post-Conditions
    private Dictionary<String, bool> postConditions;
    
    // Methods
    public abstract void Action();
    
    // // verify the preconditions against the blackboard
    public abstract bool CheckPreconditionsAreMet(AIBlackBoard blackBoard);
    
    
    
}
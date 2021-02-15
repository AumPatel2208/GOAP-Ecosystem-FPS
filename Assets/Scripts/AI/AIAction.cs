using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : MonoBehaviour {
    
    // Properties
    // // Preconditions

    
    // Methods
    
    // // verify the preconditions against the blackboard
    public abstract bool CheckPreconditionsAreMet(AIBlackBoard blackBoard);
    
    
    
}
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace AI {
    public class AIGOAPAgent : MonoBehaviour {
        // World State
        // private  globalWorldState;
        private AIWorldState ownWorldState;

        // goal is the desired final state, or series of states
        private List<Dictionary<String, bool>> goal;
        
        // List of all actions
        private List<AIAction> possibleActions;
        private AIAction idle; // Action without any preconditions to perform if all others fail

    }
}
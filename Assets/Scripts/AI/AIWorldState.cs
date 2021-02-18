using System;
using System.Collections.Generic;

namespace AI {
    public class AIWorldState {
        // stores the states as a dictionary
        private Dictionary<String, bool> states = new Dictionary<string, bool>();
        
        // if the key exists, then change it, otherwise create one
        public void SetState(String key, bool value) {
            if (states.ContainsKey(key)) {
                states[key] = value;
            }
            else {
                states.Add(key, value);
            }
        }

        public bool GetState(String key) {
            return states[key];
        }

        public bool CheckIfEquals(String key, bool value) {
            if (states.ContainsKey(key))
                return value == states[key];
            
            return false;
        }
    }
}
// Goal Oriented Action Planning AI (GOAP)
// Creator: Brent Owens sploreg.com @Sploreg 
// Licence Date : 2015

using UnityEngine;
using System.Collections;

public interface FSMState {
    void Update(FSM fsm, GameObject gameObject);
}
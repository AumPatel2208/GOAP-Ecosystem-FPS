using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStats : MonoBehaviour {
    public float foodAmount = 10;
    public bool isEaten = false;
    public bool requiresKilling = false;
    public bool isReadyToEat = true;

    private void Start() {
        if (isReadyToEat) {
            gameObject.GetComponent<Stats>().health = 0;
        }
    }

    private void Update() {
        isReadyToEat = gameObject.GetComponent<Stats>().health == 0;
    }
}
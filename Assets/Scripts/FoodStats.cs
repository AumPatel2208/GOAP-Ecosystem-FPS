using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStats : MonoBehaviour {
    public float foodAmount = 10;
    public float totalFoodAmount = 100;
    public bool isEaten = false;
    public bool requiresKilling = false;
    public bool isReadyToEat = true;

    private void Start() {
        if (isReadyToEat) {
            gameObject.GetComponent<Stats>().health = 0;
        }
    }

    private void Update() {
        isReadyToEat = gameObject.GetComponent<Stats>().IsDead();
        
        // Destroy this as this food is finished
        if (totalFoodAmount <= 0) {
            Destroy(gameObject);
        }
    }
}
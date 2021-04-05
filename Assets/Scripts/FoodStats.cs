using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStats : MonoBehaviour {
    public float foodAmount = 10f;
    public float totalFoodAmount = 100f;
    // public bool isEaten = false;
    // public bool requiresKilling = false;
    public bool isReadyToEat = true;

    private void Start() {
        if (isReadyToEat) {
            gameObject.GetComponent<Stats>().SetHealth(0f);
        }
    }

    public bool isEaten() {
        return totalFoodAmount <= 0f;
    }
    
    private void Update() {
        isReadyToEat = gameObject.GetComponent<Stats>().IsDead();
        
        // Destroy this as this food is finished
        if (isEaten()) {
            Destroy(gameObject);
        }
    }

    public void DepleteTotalFoodAmount(float amount) {
        totalFoodAmount -= amount;
    }   
    public void DepleteTotalFoodAmount() {
        totalFoodAmount -= foodAmount;
    }
    
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FoodStats : MonoBehaviour {
    public float foodAmount = 10f;
    public float totalFoodAmount = 100f;
    // public bool isEaten = false;
    // public bool requiresKilling = false;
    public bool isReadyToEat = true;

    public GameObject foodParticles;
    
    private void Start() {
        if (isReadyToEat) {
            gameObject.GetComponent<Stats>().SetHealth(0f);
        }
        
        // Get default particles if they haven't been set
        if (foodParticles == null) {
            foodParticles = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Particles/FoodParticles.prefab");
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
    
    public void SpawnFoodParticles(Vector3 centerPosition, Quaternion rotation) {
        Instantiate(foodParticles, centerPosition, rotation);
    }
    
}
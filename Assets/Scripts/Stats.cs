using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {
    public float health = 100;

    // public  float startingHealth = 100;
    public float healthRegenRate = 2;
    public float healthThreshold = 50;
    public float hunger = 100;
    public float hungerDepletionRate = 2;
    public float hungerThreshold = 80f;
    public float stamina = 100;
    public float staminaRegenRate = 2;
    public float moveSpeed = 5;

    public GameObject bloodParticle;

    protected RagdollToggle ragdoll;
    protected bool isThereRagdoll = false;

    public void Awake() {
        ragdoll = GetComponent<RagdollToggle>();
        if (ragdoll != null) {
            isThereRagdoll = true;
        }
    }

    public void SetHealth(float amount) {
        health = amount;
    }
    
    public void ApplyDamage(float damage) {
        health -= damage;
    }

    public void DepleteHunger(float decrement) {
        hunger -= decrement;
    }

    public void AddFoodAmount(float amount) {
        hunger += amount;
    }

    public bool IsHungry() {
        return hunger < hungerThreshold;
    }

    public bool IsDead() {
        return health <= 0;
    }

    public void Update() {
        if (IsDead()) {
            Death();
        }
    }
    
    // get a speed relative to time
    public float GetProperSpeed() {
        return moveSpeed * Time.deltaTime;
    }
    
    // if they die, we want to deactivate most things and let them be eaten
    private void Death() {
        if (isThereRagdoll)
            ragdoll.EnableRagdoll(true);
    }
}
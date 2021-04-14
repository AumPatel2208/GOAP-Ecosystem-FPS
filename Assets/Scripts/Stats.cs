﻿using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
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
    public float threatLevel = 0f;
    public float[] threatThresholds;

    // Particles
    public GameObject bloodParticle;

    protected RagdollToggle ragdoll;
    protected bool isThereRagdoll = false;
    private bool isGoapAgentNotNull;
    private bool isAIPathNotNull;

    public void Awake() {
        isAIPathNotNull = GetComponent<AIPath>() != null;
        isGoapAgentNotNull = GetComponent<GoapAgent>() != null;
        ragdoll = GetComponent<RagdollToggle>();
        if (ragdoll != null) {
            isThereRagdoll = true;
        }
    }
    
    public void Update() {
        if (IsDead()) {
            Death();
        }
    }
    
    public void SetHealth(float amount) {
        health = amount;
    }

    public void ApplyDamage(float damage) {
        health -= damage;
    }
    
    public void ApplyDamage(float damage, Vector3 centerPosition, Quaternion rotation) {
        health -= damage;
        SpawnBloodParticles(centerPosition, rotation);
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

    public float GetHealth() {
        return health;
    }  
    public float GetStamina() {
        return stamina;
    }
    public float GetHunger() {
        return hunger;
    } 
    public float GetHungerThreshold() {
        return hungerThreshold;
    }

    public void IncreaseThreatLevel(float amount) {
        threatLevel += amount;
    }

    public float GetThreatLevel() {
        return threatLevel;
    }

    public int IsThreatPastThreshold() {
        for (int i = 0; i < threatThresholds.Length; i++) {
            if (threatLevel > threatThresholds[i])
                return i;
        }

        return -1;
    }
    
    public bool IsDead() {
        return health <= 0;
    }
    
    // get a speed relative to time
    public float GetProperSpeed() {
        return moveSpeed * Time.deltaTime;
    }

    // if they die, we want to deactivate most things and let them be eaten
    private void Death() {
        if (isThereRagdoll) {
            ragdoll.EnableRagdoll(true);
            if(isGoapAgentNotNull)
                GetComponent<GoapAgent>().enabled = false;
            if(isAIPathNotNull)
                GetComponent<AIPath>().enabled = false;
        }
    }

    public void SpawnBloodParticles(Vector3 centerPosition, Quaternion rotation) {
        Instantiate(bloodParticle, centerPosition, rotation);
    }
}
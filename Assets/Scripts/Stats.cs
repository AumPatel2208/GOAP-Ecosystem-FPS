using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    
    public float health = 100;
    // public  float startingHealth = 100;
    public float healthRegenRate = 2;
    public float healthThreshold = 50;
    public float hunger = 100;
    public float hungerDepletionRate = 2;
    public float hungerThreshold = 0.5f;
    public float stamina = 100;
    public float staminaRegenRate = 2;
    public float moveSpeed = 5;

    public GameObject bloodParticle;
    
    public void ApplyDamage(float damage) {
        health -= damage;
         
    
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Ragdoll Tutorial : https://youtu.be/oVPI2ESkgIw
public class RagdollToggle : MonoBehaviour
{
    // Get the elements to disable and enable for enabling the Ragdoll
    protected Animator animator;
    // protected Rigidbody rigidbody;
    protected BoxCollider boxCollider;
    protected Sabertooth sabertooth;
    
    protected Collider[] childrenColliders;
    protected Rigidbody[] childrenRigidbodies;
    
    
    void Awake() {
        animator = GetComponent<Animator>();
        // rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        sabertooth = GetComponent<Sabertooth>();

        childrenColliders = GetComponentsInChildren<Collider>();
        childrenRigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    private void Start() {
        EnableRagdoll(false);
    }


    public void EnableRagdoll(bool isActive) {
        // children
        foreach (var collider in childrenColliders) {
            collider.enabled = isActive;
        }
        
        // rigidbody
        foreach (var rigidbody in childrenRigidbodies) {
            rigidbody.detectCollisions = isActive;
            rigidbody.isKinematic = !isActive;
        }


        animator.enabled = !isActive;
        // rigidbody.detectCollisions = !isActive;
        // rigidbody.isKinematic = isActive;
        boxCollider.enabled = !isActive;
        sabertooth.enabled = !isActive;
    }
    
    // Update is called once per frame
    void Update() {
        
    }
}

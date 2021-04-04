using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Ragdoll Tutorial : https://youtu.be/oVPI2ESkgIw
public class RagdollToggle : MonoBehaviour {
    
    // Get the elements to disable and enable for enabling the Ragdoll
    protected Animator animator;
    // protected Rigidbody rigidbody;
    protected BoxCollider boxCollider;
    // protected Sabertooth sabertooth;
    public Behaviour aiComponent;
    
    protected Collider[] childrenColliders;
    protected Rigidbody[] childrenRigidbodies;

    public bool currentState;
    
    
    void Awake() {
        animator = GetComponent<Animator>();
        // rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        // aiComponent = GetComponent<Sabertooth>();

        childrenColliders = GetComponentsInChildren<Collider>();
        childrenRigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    private void Start() {
        
        // disable the ragdoll first
        currentState = true;
        EnableRagdoll(false);
    }


    public void EnableRagdoll(bool isActive) {

        if (currentState != isActive) {
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
            aiComponent.enabled = !isActive;

            // for efficiency 
            currentState = isActive;
        }
    }
    
    // Update is called once per frame
    void Update() {
        
    }
}

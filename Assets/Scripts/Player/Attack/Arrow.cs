using System;
using System.Collections;
using System.Collections.Generic;
// using UnityEditor.UIElements;
using UnityEngine;

public class Arrow : MonoBehaviour {
    private Rigidbody body;
    public float attackDamage = 10f;
    private bool usedUp = false;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody>();
        // transform.rotation = Quaternion.LookRotation(body.velocity);
    }

    // Update is called once per frame
    void Update() {
        // transform.rotation = Quaternion.LookRotation(body.velocity);
    }

    private void OnCollisionEnter(Collision other) {
        // 11 is life layer
        if (!usedUp && other.gameObject.layer == 11) {

            if (other.gameObject.GetComponent<Stats>() != null) {
                other.gameObject.GetComponent<Stats>().ApplyDamage(attackDamage, other.GetContact(0).point,other.transform.rotation);
                usedUp = true;
            }

        }
    }
}
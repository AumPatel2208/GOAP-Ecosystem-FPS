using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMove : MonoBehaviour {
    public Transform futureTarget;

    public float threshold = 1;
    
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(transform.position, futureTarget.position);
        Debug.Log("Distance: " + distance);
        if (distance > threshold) {
            transform.position = futureTarget.position;
        }
    }
}
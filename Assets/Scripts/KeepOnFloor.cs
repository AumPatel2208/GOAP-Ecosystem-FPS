using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnFloor : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
    }

    void FixedUpdate() {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit)) {
            Debug.Log("Found an object - distance: " + hit.distance);
            transform.position = new Vector3(hit.point.x, hit.point.y+0.01f, hit.point.z);
        }
    }
}
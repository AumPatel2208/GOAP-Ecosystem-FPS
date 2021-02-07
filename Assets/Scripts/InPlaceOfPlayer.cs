using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPlaceOfPlayer : MonoBehaviour {
    public Transform player;
    public float xOffset;
    public float yOffset = 1;
    public float zOffset = 2;
    public float xRotation;
    public float yRotation;
    public float zRotation = 90;
    
    // Start is called before the first frame update
    void Start() {
        transform.Rotate(xRotation, yRotation, zRotation, Space.Self);
    }

    // Update is called once per frame
    void Update() {
        // transform.position = player.position + new Vector3(xOffset, yOffset, zOffset);
    }
}
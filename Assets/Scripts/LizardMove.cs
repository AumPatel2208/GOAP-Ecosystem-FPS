using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardMove : MonoBehaviour {
    public Transform main;

    public float speed = 0.01f;
    public float height = 1;

    private float previousHeightOffset;
    // private const int MainIndex = 0;

    // Start is called before the first frame update
    void Start() {
        previousHeightOffset = transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        // Debug.Log(transform.GetChild().name);
        // Need to make sure that the first 4 elements are the feet
        // float sum = 0;
        // for (int i = 0; i < 4; i++) {
        //     sum += transform.GetChild(i).position.y;
        // }
        //
        // float average = sum / 4;
        //
        // if (average != previousHeightOffset) {
        //     main.position = new Vector3(main.position.x, main.position.y+ average, main.position.z );
        //     previousHeightOffset = average;
        // }


        main.position = new Vector3(main.position.x, main.position.y, main.position.z + speed);
    }
}
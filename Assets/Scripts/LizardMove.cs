using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardMove : MonoBehaviour {
    public Transform main;

    public List<Transform> feet = new List<Transform>();
    
    public float speed = 0.01f;
    public float height = 0;

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

        // transform.Find("LeftBackLeg_Target");
        // height = CalculateHeight();
        // float tempHeight = height;
        // height = height - previousHeightOffset;
        main.position = new Vector3(main.position.x, main.position.y+height, main.position.z + speed);
        // previousHeightOffset = tempHeight;
        // if (height == previousHeightOffset) {
        //     main.position = new Vector3(main.position.x, main.position.y, main.position.z + speed);
        // }
        // else {
        //     main.position = new Vector3(main.position.x, main.position.y+height, main.position.z + speed);
        //     previousHeightOffset = height;
        // }


    }

    private float CalculateHeight() {
        float newHeight = 0;

        float average = 0;
        foreach (Transform foot in feet) {
            average+=foot.position.y;
        }

        average /= feet.Count;
        
        
        return average;
    }
    
}
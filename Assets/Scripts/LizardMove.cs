using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardMove : MonoBehaviour {
    public Transform main;

    public float speed = 0.01f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        main.position = new Vector3(main.position.x, main.position.y, main.position.z+speed);
    }
}

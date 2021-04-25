using System.Collections;
using System.Collections.Generic;
using Creatures.Actions;
using UnityEngine;

public class RandomlyCallFindFood : MonoBehaviour {
    public float callFrequency = 2f;
    private float callTimer = 0f;

    private Action_FindFood findFoodAction;

    // Start is called before the first frame update
    void Start() {
        findFoodAction = GetComponent<Action_FindFood>();
        callTimer = callFrequency + Random.Range(-3f, 3f);
    }

    // Update is called once per frame
    void Update() {
        if (callTimer > 0f) {
            callTimer -= Time.deltaTime;
        }
        else {
            findFoodAction.perform(gameObject);
            callTimer = callFrequency + Random.Range(-3f, 3f);
        }
    }
}
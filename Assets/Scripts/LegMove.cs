using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMove : MonoBehaviour {
    private Vector3 pointToTransitionTo;
    private bool isTransitioning = false;
    private bool toTransition = false;
    
    public float transitionTime = 0.1f;
    
    
    
    public Transform futureTarget;


    public float threshold = 1;


    // Start is called before the first frame update
    void Start() {
        //set strarting position of the future target
       float zFutureTargetValue = futureTarget.transform.position.z * transform.parent.localScale.z;
       futureTarget.transform.position = new Vector3(futureTarget.transform.position.x,futureTarget.transform.position.y, zFutureTargetValue);
       // if (threshold < 1) {
       //     threshold *= transform.parent.localScale.x;
       // }
       // else {
       //     threshold = transform.parent.localScale.x;
       // }
           
    }

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(transform.position, futureTarget.position);
        // Debug.Log("Distance: " + distance);

        if (toTransition) {
            isTransitioning = true;
            toTransition = false;
            StartCoroutine(LerpPosition(pointToTransitionTo, transitionTime));
        }
        else if (isTransitioning) {
        }
        else {
            if (distance > threshold) {
                pointToTransitionTo = new Vector3(futureTarget.position.x, futureTarget.position.y, futureTarget.position.z + (distance- distance*0.01f));
                toTransition = true;
                // transform.position = new Vector3(futureTarget.position.x, futureTarget.position.y, futureTarget.position.z + distance / 2f);
            }
        }
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration) {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration) {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isTransitioning = false;
    }
}
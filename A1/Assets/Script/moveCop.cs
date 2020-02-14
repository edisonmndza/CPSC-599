using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCop : MonoBehaviour
{
    private float Speed = 60;
    private float Decel = 50;

    private Transform thisTransform;
    private Transform targetTransform;
    void Awake(){
        targetTransform = GameObject.FindWithTag("targetCar").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start(){
        thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveForwardFast= new Vector3(0.0f, 0.0f, Speed*Time.deltaTime);
        Vector3 moveSideways= new Vector3(Decel*Time.deltaTime, 0.35f, 0.0f);
        if (targetTransform.localPosition.z >= 0.15 && 
            thisTransform.localPosition.x <= -0.35) {
            thisTransform.Translate(moveForwardFast);
        } else if (thisTransform.localPosition.x > -0.35 && Decel != 0){
            targetTransform.Translate(moveSideways);
            targetTransform.Rotate(0, 0, -90 * Time.deltaTime, Space.Self);
            Decel--;
        }
    }
}

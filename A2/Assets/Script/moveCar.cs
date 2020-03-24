using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCar : MonoBehaviour
{
    public static float Speed = 20;
    private int phase = 1;
    public static bool onTrackFound = false, start = false;

    private Transform thisTransform;
    private GameObject imageTarget;
    private Transform imageTrans;

    public Vector3 startPosCar, startPosCop;

    void Start() {
        thisTransform = GetComponent<Transform>();
        imageTarget = GameObject.FindWithTag("ImageTarget");
        imageTrans = imageTarget.GetComponent<Transform>();
        startPosCar = thisTransform.position;
    }

    void Update() {   
        Vector3 moveForward= new Vector3(0.0f, 0.0f, Speed * Time.deltaTime);
        Vector3 moveForwardFast= new Vector3(0.0f, 0.0f, 3*Speed*Time.deltaTime);
        if (onTrackFound && start){
            switch (phase){
            case 1:
                thisTransform.Translate(moveForward);
                if (thisTransform.localPosition.z >= -0.66) phase = 2;
                break;
            case 2:
                thisTransform.Rotate(0, -90 * Time.deltaTime, 0, Space.Self);
                if (thisTransform.localRotation.y <= -0.7) {
                    thisTransform.localRotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                    phase = 3;
                }
                break;
            case 3:
                thisTransform.Translate(moveForward);
                if (thisTransform.localPosition.x <= -0.265) phase = 4;
                break;
            case 4:
                thisTransform.Rotate(0, 90 * Time.deltaTime, 0, Space.Self);
                if (thisTransform.localRotation.y >= 0) {
                    thisTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    phase = 5;
                }
                break;
            case 5:
                thisTransform.Translate(moveForwardFast);
                if (thisTransform.localPosition.z >= 0.44) phase = -1;
                break;
            }
        }

        imageTrans.localScale = new Vector3(.60f*imageTrans.localPosition.z,
                                            .60f*imageTrans.localPosition.z,
                                            .60f*imageTrans.localPosition.z);
        
        if (Input.GetKeyDown(KeyCode.S)) start = !start;
        
        if (Input.GetKeyDown(KeyCode.RightBracket)){
            Speed += 5;
        }
        if (Input.GetKeyDown(KeyCode.LeftBracket)){
            if(Speed != 0){
                Speed -= 5;
            }
        }
        
    }

    public void reset(){
        thisTransform.position = startPosCar;

    }
    
}
            
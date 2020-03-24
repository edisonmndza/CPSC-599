using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerHandler : DefaultTrackableEventHandler{
    
    [SerializeField]
    
    protected override void OnTrackingFound(){
        base.OnTrackingFound ();
        moveCar.onTrackFound = true;
    }

    protected override void OnTrackingLost(){
        base.OnTrackingLost ();
        moveCar.onTrackFound = false;
    }
}


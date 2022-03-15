using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerHandler : MonoBehaviour
{
    // Start is called before the first frame update
    
    public ActionBasedController rightHand;
    [SerializeField]
    XRRayInteractor rayInteractor;
    public void OnSelectHide()
    {
        //rightHand.hideControllerModel = true;
       // rightHand.enableInputTracking = false;
        //rayInteractor.enabled = false;
        
    }
    public void OnDeSelectShow()
    {
        //rightHand.hideControllerModel = false;
        //rightHand.enableInputTracking = true;
        //rayInteractor.enabled = true;
        
    }
}

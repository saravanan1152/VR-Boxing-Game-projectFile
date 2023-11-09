using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class ControllerInput : MonoBehaviour
{
   private InputDevice inputDevice;
    private void Start()
    {
        List<InputDevice> Devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCher = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCher, Devices);

        foreach(var item in Devices)
        {
            Debug.Log("button1"+item.name + item.characteristics);
        }
        if (Devices.Count > 0)
        {
            inputDevice = Devices[0];
        }
    }

    private void Update()
    {
       if( inputDevice.TryGetFeatureValue(CommonUsages.primaryButton,out bool button)&&button)
        {
            Debug.Log("Button");
        }

    
       if(inputDevice.TryGetFeatureValue(CommonUsages.trigger,out float triggerValue) &&triggerValue > 0.1f)
        {
            Debug.Log("Button Play");
        }

        
      
    }
}

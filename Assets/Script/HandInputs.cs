using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
public class HandInputs : MonoBehaviour
{

    public InputDevice rightHand;
    public InputDevice leftHand;
    public InputDevice hmd;

    public HandInputs hand;
    public float leftMaxScore;
    public float rightMaxScore;

    public float leftSpeed;
    public float rightSpeed;
    private void Start()
    {
    }
    private void Update()
    {
       if(!rightHand.isValid||!leftHand.isValid || ! hmd.isValid)
            InitializedInputDevices();

       HandSpeedCalculate();
      
         
      

    }
    private void InitializedInputDevices()
    {
        if (!rightHand.isValid)
        {
            InitializedInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right,ref rightHand);
           
         
        }
        if (!leftHand.isValid)
        {
            InitializedInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref leftHand);
        }
        if (!hmd.isValid)
        {
            InitializedInputDevice(InputDeviceCharacteristics.HeadMounted,ref hmd);
        }
        
    }
    private void InitializedInputDevice(InputDeviceCharacteristics inputcharacteristics,ref InputDevice inputdevice)
    {
        List<InputDevice>devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(inputcharacteristics, devices);

            if (devices.Count > 0)
        {
            inputdevice = devices[0];
        }
    }
    
    public void HandSpeedCalculate()
    {

        if (leftHand.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 leftVelocity))
        {
            leftMaxScore = Mathf.Max(leftVelocity.magnitude, leftMaxScore);

        }
        if (rightHand.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity))
        {
            rightMaxScore = Mathf.Max(rightVelocity.magnitude, rightMaxScore);

        }

        leftSpeed = leftVelocity.magnitude * 100;
        rightSpeed = rightVelocity.magnitude * 100;
    }

    
}

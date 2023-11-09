using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;
using Unity.Mathematics;

public class DisplayInputData : MonoBehaviour
{
   // public TextMeshProUGUI leftScore;
  //  public TextMeshProUGUI rightScore;

    public HandInputs hand;
    public float leftMaxcore;
    public float rightMaxcore;

    public TextMeshProUGUI leftvalue;
    public TextMeshProUGUI rightvalue;

    public float leftSpeed;
    public float rightSpeed;
    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<HandInputs>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(hand.leftHand.TryGetFeatureValue(CommonUsages.deviceVelocity,out Vector3 leftVelocity))
        {
            leftMaxcore=Mathf.Max(leftVelocity.magnitude,leftMaxcore);
            //leftScore.text=leftMaxcore.ToString("F2");
        }
        if (hand.rightHand.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity))
        {
            rightMaxcore = Mathf.Max(rightVelocity.magnitude, rightMaxcore);
          //  rightScore.text = rightMaxcore.ToString("F2");
        }

        leftSpeed=leftVelocity.magnitude;
        rightSpeed=rightVelocity.magnitude;
        Debug.Log($"left{leftSpeed} right {rightSpeed}");
        leftvalue.text=leftSpeed.ToString();
        rightvalue.text=rightSpeed.ToString();
    }
    
}

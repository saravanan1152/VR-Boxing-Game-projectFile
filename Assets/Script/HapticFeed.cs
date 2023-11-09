using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[SerializeField]
public class HapticFeedBack : MonoBehaviour
{
    public XRBaseController xrControllerRight;
    public XRBaseController xrControllerLeft;
   [Range(0, 1)][SerializeField] float intencity=0.4f;
    private float duration=2f;
    void Start()
    {
      //  xrControllerRight = (XRBaseController)GameObject.FindObjectOfType(typeof(XRBaseController));
   //  xrControllerLeft=GameObject.FindObjectOfType<XRBaseController>();
    }

 
    public void Haptic()
    {
        if (intencity > 0)
        {
            xrControllerRight.SendHapticImpulse(intencity, duration);
            xrControllerLeft.SendHapticImpulse(intencity,duration);
        }
    }
}

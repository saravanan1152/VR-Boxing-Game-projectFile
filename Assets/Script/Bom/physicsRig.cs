using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsRig : MonoBehaviour
{
    public Transform PlayerHead;
    public CapsuleCollider bodyCollider;
  

    public float bodyHeightMin = 0.5f;
    public float bodyHeightMax = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       bodyCollider.height = Mathf.Clamp(PlayerHead.localPosition.y, bodyHeightMin, bodyHeightMax);
        bodyCollider.center=new Vector3(PlayerHead.localPosition.x,bodyCollider.height/2,PlayerHead.localPosition.z);
    
    }
}

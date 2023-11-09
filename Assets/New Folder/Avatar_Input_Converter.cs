using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar_Input_Converter : MonoBehaviour
{

    public Transform MainAvatarTransform;

    public Transform AvatarHead;
    public Transform AvatarBody;

    public Transform AvatarHand_Left;
    public Transform AvatarHand_Right;

    public Transform XRHead;

    public Transform XRHand_Left;
    public Transform XRHand_Right;

    public SphereCollider LocoSphereCollider;
    
    public Vector3 headPositionOffset;
    public Vector3 handRotationOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        //MainAvatarTransform.position =  XRHead.position + headPositionOffset;
        AvatarHead.position =  XRHead.position;
        AvatarHead.rotation =  XRHead.rotation;

        MainAvatarTransform.position = LocoSphereCollider.transform.position - new Vector3(0, LocoSphereCollider.radius, 0);
        
        AvatarBody.rotation =  Quaternion.Euler(new Vector3(0, AvatarHead.rotation.eulerAngles.y, 0));

        AvatarHand_Right.position = Vector3.Lerp(AvatarHand_Right.position, XRHand_Right.position, 1f);
        AvatarHand_Right.rotation = Quaternion.Lerp(AvatarHand_Right.rotation, XRHand_Right.rotation, 1f) * Quaternion.Euler(handRotationOffset);

        AvatarHand_Left.position = Vector3.Lerp(AvatarHand_Left.position, XRHand_Left.position, 1f);
        AvatarHand_Left.rotation=Quaternion.Lerp(AvatarHand_Left.rotation, XRHand_Left.rotation,1f)*Quaternion.Euler(handRotationOffset);
    }
}

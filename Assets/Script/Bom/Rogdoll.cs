using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Animations;

public class Rogdoll : MonoBehaviour
{
    public BoxCollider mainCollider;
    public GameObject thisgayrig;
    public Animator animator;

   public Collider[] ragDollColliders;
   public Rigidbody[] limbsRigidbodies;
    // Start is called before the first frame update
    void Start()
    {
        GetRogdollBits();
        RagdollModeOff();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            RagdollModeOn();
        }
        
    }
    

    private void OnCollisionEnter(Collision collision)
    {
      if (collision .gameObject.tag=="Collision")
        {
            Debug.Log("Enter");
            RagdollModeOn();
        }
    }

 //   Collider[] ragDollColliders;
  //  Rigidbody[] limbsRigidbodies;

    private void GetRogdollBits()
    {
        ragDollColliders = thisgayrig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = thisgayrig.GetComponentsInChildren<Rigidbody>();
    }
    private void RagdollModeOff()
    {
        foreach(Collider col in ragDollColliders)
        {
            col.enabled = false;
        }
        foreach (var rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }
        animator.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
    private void RagdollModeOn()
    {
        animator.enabled = false;
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }
        foreach (var rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }
       
        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}

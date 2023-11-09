using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBom : MonoBehaviour
{
    Rigidbody rigitbody;
    public Rigidbody otherR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigitbody.MovePosition(transform.position);
        rigitbody.MoveRotation(transform.rotation);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bom"))
        {
            Debug.Log("h");
             otherR = collision.gameObject.GetComponentInChildren<Rigidbody>();

            if (collision == null)
            {
                return;
            }
            Vector3 avgPoint = Vector3.zero;
            foreach (ContactPoint p in collision.contacts)
            {
                avgPoint += p.point;
            }
            avgPoint /= collision.contacts.Length;

            Vector3 dir = (avgPoint - transform.position).normalized;

            otherR.AddForce(dir * 100 * rigitbody.velocity.magnitude);
            Debug.Log("Hit" + 100 * rigitbody.velocity.magnitude);

        }
       
    }
}

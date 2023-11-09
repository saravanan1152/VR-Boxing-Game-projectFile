using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
  
    public GameObject Fractured;
    public float breakForce;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ButtonClick();
        }
    }

    void ButtonClick()
    {
        GameObject fra = Instantiate(Fractured, transform.position, Quaternion.identity);

        foreach (Rigidbody rb in fra.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - rb.transform.position).normalized * breakForce;
            rb.AddForce(force);
        }
        Destroy(gameObject);
    }
}

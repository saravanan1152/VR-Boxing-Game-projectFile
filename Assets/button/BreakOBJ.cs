using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOBJ : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        Breaking();
    }

    public void Breaking()
    {
        Instantiate(obj,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

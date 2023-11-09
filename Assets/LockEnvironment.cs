using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockEnvironment : MonoBehaviour
{
    public GameObject[] lockE;

    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
   pos= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = Vector3.zero;
      //  transform.position = Vector3.zero;

        foreach (GameObject go in lockE)
        {
            go.transform.position= Vector3.zero;
        }
    }
}

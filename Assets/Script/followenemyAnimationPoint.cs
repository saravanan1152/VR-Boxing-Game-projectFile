using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followenemyAnimationPoint : MonoBehaviour
{
    public GameObject d;
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position=d.transform.position;
    }
}

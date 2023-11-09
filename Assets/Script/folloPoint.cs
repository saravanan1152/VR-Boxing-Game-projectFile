using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folloPoint : MonoBehaviour
{
    private Vector3 ob;
    public GameObject followPonit;
    public GameObject camera;
    public float XRHightPos=9.8f;
    public float FollowPointPos=9.3f;

    private PlayerHealth playerhealth;
    public Vector3 reSpawnPos;
    // Start is called before the first frame update
    void Start()
    {
        playerhealth=GetComponentInChildren<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
       
      ob=new Vector3(transform.position.x, XRHightPos, transform.position.z);
        transform.position=ob;

       followPonit.transform.position=new Vector3(camera.transform.position.x,FollowPointPos,camera.transform.position.z);



         if (playerhealth.HealthAmound <= 0)
        {
          
          playerhealth.  HealthAmound = playerhealth.maximumHealth;
            transform.position = reSpawnPos;

        }

    }
}

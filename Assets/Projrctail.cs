
using UnityEngine;


public class Projrctail : MonoBehaviour
{
    public GameObject projectailObject;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ProjectailFun",1,Random.Range(5,20));
        InvokeRepeating("LaserSpawn", 5, Random.Range(10,25));
    }

   void ProjectailFun()
    {
        Instantiate(projectailObject, transform.position, transform.rotation);
       
    }
    void LaserSpawn()
    {
        Instantiate(laser, transform.position, transform.rotation);

    }
}

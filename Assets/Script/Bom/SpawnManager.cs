using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform Rig;
    public GameObject[] balls;
  //  public ParticleSystem particls;


   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBomTime());
        
    }

    IEnumerator SpawnBomTime()
    {
        while (true)
        {

            GameObject ball = Instantiate(balls[Random.Range(0, balls.Length)]);
            float angle = Random.Range(0f, 360f);
            float radius = Random.Range(1f, 1f);
            ball.transform.position = Rig.position + new Vector3(radius * Mathf.Sin(angle),Random.Range(1.2f,1.75f),radius*Mathf.Cos(angle));

            yield return new WaitForSeconds(Random.Range(1f,10f));

        }
    }

   

   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnDelay = 2f;
    private GameObject currentEnemy;

    public Enemy enemyScript;
    private void Start()
    {
       // StartCoroutine(SpawnEnemies());
    }
    private void Update()
    {
        enemyScript=GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
      if(enemyScript.healthAmount == 0)
        {
            StartCoroutine(SpawnDelya());
        }
    }

    /* private System.Collections.IEnumerator SpawnEnemies()
     {
         while (true)
         {
             SpawnEnemy();
             yield return new WaitForSeconds(spawnDelay);
         }
     }*/

    IEnumerator SpawnDelya()
    {
        yield return new WaitForSeconds(2);
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {

        currentEnemy = Instantiate(enemyPrefab, GetRandomSpawnPoint(), Quaternion.identity);
    }

    private Vector3 GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex].position;
    }
    
}

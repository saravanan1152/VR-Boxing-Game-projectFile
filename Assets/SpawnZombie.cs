using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] public GameObject ZombiePrefab;
    [SerializeField] private int spawnIndex;
    [SerializeField] public Transform[] SpawnLocation;
    [SerializeField] private GameObject SpawnPrefabZombie;
    [SerializeField] public Canvas PlayerHealthCanvas;
    [SerializeField] private Win winScript;
    // Start is called before the first frame update
    void Start()
    {

        winScript = FindAnyObjectByType<Win>();

        InvokeRepeating("spawnEnemys", 1, 5);
    }

    private void Update()
    {

    }

    void spawnEnemys()
    {
        if (SpawnPrefabZombie == null && !winScript.winBool)
        {

            SpawnLocation[spawnIndex].gameObject.SetActive(true);
            StartCoroutine(Timeing());
            spawnIndex = Random.Range(0, SpawnLocation.Length);
            SpawnPrefabZombie = Instantiate(ZombiePrefab, SpawnLocation[spawnIndex].position, SpawnLocation[spawnIndex].rotation);

            SpawnLocation[spawnIndex].gameObject.SetActive(false);



        }


    }
    IEnumerator Timeing()
    {
        PlayerHealthCanvas.enabled = true;
        yield return new WaitForSeconds(5);
        PlayerHealthCanvas.enabled = false;

    }

}

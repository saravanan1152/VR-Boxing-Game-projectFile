using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    public float Timer,hitForce;
    public Slider ZombieSlider;
    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Timer -= Time.deltaTime;
        if (ZombieSlider.value == 0)
        {
          
            FindObjectOfType<SpawnZombie>().scoreCount+= 1;
            Destroy(zombie);
        }
       if ( Timer < 0)
        {
          
            FindObjectOfType<SpawnZombie>().PlayerHealth.value -= 1;
            Destroy(zombie);
        }*/
        if(Input.GetKeyUp(KeyCode.D))
        {
            Destroy(zombie);
        }
      
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            Debug.Log("hit");
            ZombieSlider.value -= hitForce;

           
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bom : MonoBehaviour
{
    public ParticleSystem boomSparticle;
    public AudioSource source;
    public AudioClip explotionclip;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
      
    }
    private void Update()
    {
      
     
        
      
    }

    private void OnCollisionEnter(Collision collision)
    {
       


      
        Debug.Log("enter");
        StartCoroutine(BlostTime());
        
       
        Destroy(gameObject,3 );
       

       
    }
    IEnumerator BlostTime()
    {
        yield return new WaitForSeconds(2);
        ParticleSystem spawnedParticle =Instantiate(boomSparticle, transform.position,Quaternion.identity);
        spawnedParticle.transform.SetParent(transform);
        source.PlayOneShot(explotionclip);
        boomSparticle.Play();


    }

}

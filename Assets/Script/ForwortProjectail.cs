using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ForwortProjectail : MonoBehaviour
{
    public float speed;
    public AudioSource source;
    public AudioClip BoomClip;
    public ParticleSystem particle;

 
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            source.PlayOneShot(BoomClip, 1);
            particle.transform.position = transform.position;
            particle.Play(BoomClip);
            Destroy(gameObject,1);
            Debug.Log("Collide");

        }


    }
}

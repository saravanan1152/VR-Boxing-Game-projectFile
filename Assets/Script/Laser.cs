using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Laser : MonoBehaviour
{
    public float Speed;
    public AudioSource source;
    public AudioClip laserclip;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*Speed);

        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            source.PlayOneShot(laserclip);
            Destroy(gameObject,1);
        }
    }
}

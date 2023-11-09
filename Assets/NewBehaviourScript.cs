using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Material borterCollorMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) { borterCollorMaterial.color = Color.green; }
        if (Input.GetKeyDown(KeyCode.E)) { borterCollorMaterial.color = Color.red; }
    }
}

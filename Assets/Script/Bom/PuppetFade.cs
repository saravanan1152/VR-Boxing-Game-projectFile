using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetFade : MonoBehaviour
{
    //pupet death
    [Tooltip("Reference to the PuppetMaster component.")]
    public PuppetMaster puppetMaster;

    [Tooltip("The speed of fading out PuppetMaster.pinWeight.")]
    public float fadeOutPinWeightSpeed = 5f;

    [Tooltip("The speed of fading out PuppetMaster.muscleWeight.")]
    public float fadeOutMuscleWeightSpeed = 5f;

    [Tooltip("The muscle weight to fade out to.")]
    public float deadMuscleWeight = 0.3f;


    private Vector3 defaultPosition;
    private Quaternion defaultRotation = Quaternion.identity;
    // Start is called before the first frame update
    void Start()
    {
          puppetMaster = GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<PuppetMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.R)) { fadeIn(); }
        if(Input.GetKeyUp(KeyCode.E)) { FadeOut(); }
    }
    public void FadeOut()
    {
        while (puppetMaster.pinWeight > 0f)
        {
            puppetMaster.pinWeight = Mathf.MoveTowards(puppetMaster.pinWeight, 0f, Time.deltaTime * fadeOutPinWeightSpeed);

        }
    }
    public void fadeIn()
    {
        while (puppetMaster.pinWeight < 1f)
        {
            puppetMaster.pinWeight = Mathf.MoveTowards(puppetMaster.pinWeight, 0f, Time.deltaTime * fadeOutPinWeightSpeed);

        }
    }
}

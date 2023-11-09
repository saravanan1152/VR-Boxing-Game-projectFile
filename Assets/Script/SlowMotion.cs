using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowMOtionTimeScale;
    private float startTimeScale;
    private float startFixedDeltaTime;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        startTimeScale = Time.timeScale;
        startFixedDeltaTime = Time.timeScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        

     
      
    }
    public void StratSlowmMotion()
    {
        Time.timeScale= slowMOtionTimeScale;
        Time.fixedDeltaTime= startFixedDeltaTime*slowMOtionTimeScale;
    }
    public void StopSlowMotion()
    {
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime;
    }

  public  IEnumerator Timeing()
    {
        StratSlowmMotion();
        yield return new WaitForSeconds(2f);
        StopSlowMotion();
    }
   
}

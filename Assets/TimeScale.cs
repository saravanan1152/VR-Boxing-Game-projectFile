using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public float slowDown=0.05f;
    public float slowdownLength = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = math.clamp(Time.timeScale, 0f, 1f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoSlowmotion();
        }

    }

    public void DoSlowmotion()
    {
        Time.timeScale = slowDown;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}

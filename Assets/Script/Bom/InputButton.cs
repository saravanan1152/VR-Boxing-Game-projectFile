using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class InputButton : MonoBehaviour
{
    public Canvas canvas;
    public InputActionProperty showButton;
    public InputActionProperty hideButton;

   // public Slider slider;
   // public TextMeshProUGUI textSlide;

   
    public XRRayInteractor rayInteractor;
    private Projrctail projrctail;

   
    // Start is called before the first frame update
    void Start()
    {



       

        canvas.enabled = false;
        rayInteractor.enabled = false;
       
      
    }

    private void Update()
    {

        projrctail = GameObject.FindGameObjectWithTag("Projectail").GetComponent<Projrctail>();

        if (showButton.action.WasPressedThisFrame())
        {    
            canvas.enabled = true; rayInteractor.enabled = true;projrctail.enabled = false; 
        }
        if (hideButton.action.WasPressedThisFrame())
        {
            canvas.enabled = false; rayInteractor.enabled = false; projrctail.enabled = true; 
        }
        

         
       // Debug.Log(slider.value + "slider valuer");
       // textSlide.text =slider.value.ToString("0.0");
        
     

    }
    public void AdjustSpeed(float speed)
    {
     
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealth : MonoBehaviour
{
    [Header("Player Heath")]
    [SerializeField] public float HealthAmound=1000;
   [Serialize] public float maximumHealth;
   [Serialize] public Image healthBar;
    [SerializeField] Slider slider;
   [Serialize] public TextMeshProUGUI textHealth;
   [Serialize]  public AudioSource audioSource;
   [Serialize] public AudioClip punchClip;
    bool punchTrue;
    public float DamageHealth=15;

    public GameObject loss;

   
    private void Start()
    {
        maximumHealth = HealthAmound;
        audioSource=GetComponent<AudioSource>();


    }
    private void Update()
    {
      
      
        TextHealth();
       
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand")&&!punchTrue)
        {
           // HeathDamage(DamageHealth);
            audioSource.PlayOneShot(punchClip);
            Debug.Log("Enter1");
            punchTrue = true;
        }

        if (other.gameObject.CompareTag("Projectile"))
        {
            HeathDamage(20);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        punchTrue=false;
    }


    public void HeathDamage(float damage)
    {
        if(HealthAmound>=0)
        HealthAmound -= damage;
        healthBar.fillAmount = HealthAmound / maximumHealth;
        slider.value = HealthAmound / maximumHealth * 10;
    }
    public void TextHealth()
    {
        int number = Mathf.RoundToInt(HealthAmound/maximumHealth*maximumHealth);
        textHealth.text = number.ToString()+"%";

    }

    public void UI()
    {
        loss.SetActive(false);
    }
   

}

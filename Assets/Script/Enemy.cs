using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] public float healthAmount = 5000;
    [SerializeField] public float maxHealth;
    [SerializeField] public TextMeshProUGUI percentageText;
    [SerializeField] TextMeshProUGUI timerUI;
    [SerializeField] public float livetimer = 120;
    [SerializeField] public Image healthbar;
   
   [SerializeField] public Transform FollowPoint;
     float rotationSpeed = 5.0f;
    float attackDistance = 1.2f;

    private NavMeshAgent agent;
    private RandomAnimatorClip animatorClip;
    private HapticFeedBack haptic;
    bool walk;
    bool allow = false;


    public GameObject VFXRed;
    public GameObject VFXGreen;
    //Haptic 
   

    public Canvas runImage;

    private float distance;
    [SerializeField]
    [Range(3, 10)] private int reachEnemyTime = 4;
    [SerializeField]
    [Range(1.5f, 3)] private float reachDestance = 2;
    private float time;
    private bool reach;
  [SerializeField]  private bool timeDie;
    bool die;

    [SerializeField] private Win winScript;
  
    
    void Start()
    {
        maxHealth = healthAmount;


        animator = GetComponentInChildren<Animator>();
        animatorClip = GetComponentInChildren<RandomAnimatorClip>();
        agent = GetComponent<NavMeshAgent>();
        FollowPoint = GameObject.FindGameObjectWithTag("FollowPoint").GetComponent<Transform>();
        playerHealth = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerHealth>();
        haptic = GameObject.FindAnyObjectByType<HapticFeedBack>();
        runImage = GameObject.FindGameObjectWithTag("Run").GetComponent<Canvas>();
        winScript = FindAnyObjectByType<Win>();
        VFXRed.SetActive(false);
        VFXGreen.SetActive(false);

       

     

    }

    void Update()
    {

        FollowPlayer();
        TimerFun();
        HealthBar();
        HealthPercentageText();

        Death();
       

    }


    void FollowPlayer()
    {
        Vector3 directionToPlayer = FollowPoint.position - transform.position;
        Quaternion desiredRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

        float Distance = Vector3.Distance(transform.position, FollowPoint.transform.position);
        if (Distance <= attackDistance)
        {
          
           
            animatorClip.T = false;
            
        }
        else
        {
            if (healthAmount > 0)
            {
                if (livetimer > 0.1f)
                {
                    Debug.Log("idle");
                    animatorClip.T = true;
                    animator.Play("FIGHTING SWAY");
                }

            }

        }
        if (Distance <= 1.5f)
        {
            Debug.Log("di");
           
            if (!timeDie)
            {
                agent.SetDestination(FollowPoint.transform.position);
                agent.stoppingDistance = attackDistance;
                Debug.Log("di1");
            }
          
           
        }
        //runImage true & false with distance

        RunImage();
        hapticTime();
        PlayerReachEnemy();


    }
    void RunImage()
    {
        if (distance > 2f)
        {
            runImage.enabled = true;

        }
        else
        {
            runImage.enabled = false;

        }
    }
    void hapticTime()
    {
        distance = Vector3.Distance(transform.position, FollowPoint.transform.position);
        if (distance >= 2)
        {

            haptic.Haptic();


        }

     

    }
    void PlayerReachEnemy()
    {
        time += Time.deltaTime;
        if (distance < 2)
        {
            reach = true;
        }

        if (time > reachEnemyTime)
        {
            runImage.enabled = false;
          //  runImage.SetActive(false);

            if (!reach)
            {
                Destroy(gameObject);
            }
        }
    }

    void TimerFun()
    {
        livetimer -= Time.deltaTime;
        Debug.Log("Time" + livetimer);
        livetimer = Mathf.Clamp(livetimer, 0f, livetimer);
        int times = Mathf.RoundToInt(livetimer);
        timerUI.text = times.ToString();

    }

    private void HealthBar()
    {
        healthbar.fillAmount = healthAmount / maxHealth;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);
    }

    private void HealthPercentageText()
    {
        int healthPercentage = Mathf.RoundToInt(healthAmount / maxHealth * 100f);
        percentageText.text = healthPercentage.ToString() + "%";
    }

    void Death()
    {
      

        if (livetimer <= 0)
        {
            timeDie = true;
            animatorClip.T = true;
            VFXRed.SetActive(true);
            agent.stoppingDistance = 0;
            agent.SetDestination(FollowPoint.transform.position);
            animator.Play("Z_Run_InPlace");

            if (!allow && playerHealth.HealthAmound < playerHealth.maximumHealth)
            {
                playerHealth.HealthAmound -= 20f;
                allow = true;
            }



            if (Vector3.Distance(transform.position, FollowPoint.transform.position) < 0.4f)
            {
                Destroy(gameObject);
            }

        }

        if (healthAmount <= 0)
        {
            if (!allow && playerHealth.HealthAmound < playerHealth.maximumHealth)
            {
                playerHealth.HealthAmound += 20;
                allow = true;
            }

            healthAmount = 0;
            
            animatorClip.PuppetMasterUpdate();
           
            Destroy(gameObject, 5);
            if (!die)
            {
                die = true;
                winScript.numberofDeathEnemes++;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, reachDestance);


    }

}

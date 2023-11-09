using UnityEngine;
using TMPro;
using Unity.XR.Oculus.Input;
using DamageNumbersPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.VFX;

[RequireComponent(typeof(AudioSource))]
public class Gloves : MonoBehaviour
{
    public AudioSource source;
    [SerializeField] public Enemy enemy;
    [SerializeField] public DisplayInputData inputData;
    [SerializeField] AudioClip punchSound;
    [SerializeField] int leftmove;
    [SerializeField] int rightmove;
    // public TextMeshProUGUI ui;
    // public Canvas canves;
    public int reduceHealth;
    public GearVRTrackedController hand;
    public bool co;
    //   public GameObject[] prefabs;
    public DamageNumber damage;

    //enemy Animation
    public Animator ani;
    public RandomAnimatorClip randomAnimationClip;
    public float animationDuration;
    public float currentPlayTime;
    string animationName = "Stunned";
    Rigidbody rigitbody;
    bool aniBool;
    public int score;
    public TextMeshProUGUI Score;
    


    public float timer = 0;


    //Parameters
    [SerializeField] float controllerSpeed = 4.5f;
    [SerializeField] float timeOverlLay = 2f;
    [SerializeField] float increaseHealthSpeed = 4f;

    //TeasCanvas
    [Header("Assaing Text")]
    public TextMeshProUGUI controllerSpeedText;
    public TextMeshProUGUI timeOverLayText;
    public TextMeshProUGUI increaseHealthSpeedTime;


    public Button PlusButton;
    public Button minusButton;

    public Button overLayPlusButton;
    public Button overLayminusButton;

    public Button increseHealthPlusButton;
    public Button increaseHealthMinusButton;

   
    //XR Haptic
    public XRBaseController controller;

    // Start is called before the first frame update
    private void Awake()
    {
        controllerSpeed = 4.5f;
        timeOverlLay = 3f;
        score = 0;
    }
    void Start()
    {
        
        source = GetComponent<AudioSource>();

        rigitbody = GetComponent<Rigidbody>();

        controller = GetComponentInParent<XRBaseController>();
        //Test
        controllerSpeedText = GameObject.FindGameObjectWithTag("C").GetComponent<TextMeshProUGUI>();
        timeOverLayText = GameObject.FindGameObjectWithTag("T").GetComponent<TextMeshProUGUI>();
        increaseHealthSpeedTime = GameObject.FindGameObjectWithTag("I").GetComponent<TextMeshProUGUI>();

        PlusButton = GameObject.FindGameObjectWithTag("Plus").GetComponent<Button>();
        minusButton = GameObject.FindGameObjectWithTag("Minus").GetComponent<Button>();

        overLayPlusButton = GameObject.FindGameObjectWithTag("OverLayPlus").GetComponent<Button>();
        overLayminusButton = GameObject.FindGameObjectWithTag("OverLayMinus").GetComponent<Button>();

        increseHealthPlusButton = GameObject.FindGameObjectWithTag("IncreasePlus").GetComponent<Button>();
        increaseHealthMinusButton = GameObject.FindGameObjectWithTag("IncreaseMinus").GetComponent<Button>();
        // canves=GameObject.FindGameObjectWithTag("HealthUI").GetComponent<Canvas>();
       

        PlusButton.onClick.AddListener(PlusuButton);
        minusButton.onClick.AddListener(MinusButton);
        overLayPlusButton.onClick.AddListener(OverLayPlusuButton);
        overLayminusButton.onClick.AddListener(OverLayMinusButton);
        increseHealthPlusButton.onClick.AddListener(TimerIncreaseSpeeedPlusuButton);
        increaseHealthMinusButton.onClick.AddListener(TimerIncreaseSpeedMinusButton);


    }

    // Update is called once per frame
    void Update()
    {

       

     

        TagUpdates();


        timer += Time.deltaTime;

        rigitbody.MovePosition(transform.position);
        rigitbody.MoveRotation(transform.rotation);

        leftmove = (int)(inputData.leftSpeed);
        rightmove = (int)(inputData.rightSpeed);
        if (!aniBool)
        {
            AnimationPlay();
        }

        Score.text = score.ToString();
        TimerIncreaseEnemyHealth();

        //test
        UIUpdates();

    }
    void TagUpdates()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        inputData = GameObject.FindGameObjectWithTag("Player").GetComponent<DisplayInputData>();
        ani = GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<Animator>();
        randomAnimationClip = GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<RandomAnimatorClip>();
        Score = GameObject.FindGameObjectWithTag("Score").GetComponentInChildren<TextMeshProUGUI>();
    }
    void UIUpdates()
    {
        controllerSpeedText.text = controllerSpeed.ToString("0.0");
        timeOverLayText.text = timeOverlLay.ToString();
        increaseHealthSpeedTime.text = increaseHealthSpeed.ToString();


        controllerSpeed = Mathf.Clamp(controllerSpeed, 1, 10);
        timeOverlLay = Mathf.Clamp(timeOverlLay, 0, 10);
    }
  
    private void OnCollisionEnter(Collision collision)
    {



        //   foreach (GameObject can in prefabs)
        //{
        if (inputData.leftSpeed > controllerSpeed || inputData.rightSpeed > controllerSpeed)
        {
            timer = 0;


            if (collision.gameObject.CompareTag("Head") && !co)
            {
                Debug.Log("head1");
                if (gameObject.CompareTag("LeftGloves"))
                {
                    Debug.Log("head");
                    source.PlayOneShot(punchSound, 1);
                    reduceHealth = 15 + leftmove * 4;
                    HealthDamage(reduceHealth);
                    damage.Spawn(transform.position, reduceHealth);
                    score += 10;
                    //  Instantiate(can, transform.position, can.transform.rotation);
                    //   ui.text = "-" + reduceHealth.ToString();
                    //  ui.tag = "Untagged";
                    Debug.Log("LEft");
                }


                if (gameObject.CompareTag("RightGloves"))
                {
                    source.PlayOneShot(punchSound, 1);
                    reduceHealth = 15 + rightmove * 4;
                    HealthDamage(reduceHealth);
                    Debug.Log("Right");
                    damage.Spawn(transform.position, reduceHealth);
                    score += 10;
                    // Instantiate(can, transform.position, can.transform.rotation);
                    // ui.text = "-" + reduceHealth.ToString();
                    // ui.tag = "Untagged";

                }
            }
            else if (collision.gameObject.CompareTag("Spine"))
            {
                if (gameObject.CompareTag("LeftGloves"))
                {
                    source.PlayOneShot(punchSound, 1);
                    reduceHealth = 8 + leftmove * 4;
                    HealthDamage(reduceHealth);
                    score += 5;
                    damage.Spawn(transform.position, reduceHealth);
                    //   Instantiate(can, transform.position, can.transform.rotation);
                    //  ui.text = "-" + reduceHealth.ToString();
                    // ui.tag = "Untagged";
                    Debug.Log("LEft");


                }


                if (gameObject.CompareTag("RightGloves"))
                {
                    source.PlayOneShot(punchSound, 1);
                    reduceHealth = 8 + rightmove * 4;
                    HealthDamage(reduceHealth);

                    damage.Spawn(transform.position, reduceHealth);
                    score += 5;
                    // Instantiate(can, transform.position, can.transform.rotation);
                    //   ui.text = "-" + reduceHealth.ToString();
                    //   ui.tag = "Untagged";
                    Debug.Log("Right");

                }

                else if (collision.gameObject.CompareTag("Hip"))
                {
                    if (gameObject.CompareTag("LeftGloves"))
                    {
                        source.PlayOneShot(punchSound, 1);
                        reduceHealth = 10 + leftmove * 4;
                        HealthDamage(reduceHealth);
                        score += 5;
                        damage.Spawn(transform.position, reduceHealth);
                        // Instantiate(can, transform.position, can.transform.rotation);
                        //  ui.text = "-" + reduceHealth.ToString();
                        //  ui.tag = "Untagged";
                        Debug.Log("LEft");

                    }


                    if (gameObject.CompareTag("RightGloves"))
                    {
                        source.PlayOneShot(punchSound, 1);
                        reduceHealth = 10 + rightmove * 4;
                        HealthDamage(reduceHealth);
                        score += 5;
                        damage.Spawn(transform.position, reduceHealth);
                        //   Instantiate(can, transform.position, can.transform.rotation);
                        //  ui.text = "-" + reduceHealth.ToString();
                        //  ui.tag = "Untagged";
                        //  Debug.Log("Right");


                    }
                }
                else
                {
                    HealthDamage(10);
                }
                co = true;
            }


            /* if (collision.gameObject.CompareTag("Bom"))
             {
                 Debug.Log("h");
                 Rigidbody otherR = collision.gameObject.GetComponentInChildren<Rigidbody>();

                 if (collision == null)
                 {
                     return;
                 }
                 Vector3 avgPoint = Vector3.zero;
                 foreach (ContactPoint p in collision.contacts)
                 {
                     avgPoint += p.point;
                 }
                 avgPoint /= collision.contacts.Length;

                 Vector3 dir = (avgPoint - transform.position).normalized;

                 otherR.AddForceAtPosition(dir* 1000 * rigitbody.velocity.magnitude, avgPoint);
                 Debug.Log("Hit" +(dir * 1000 ));
             }*/
        }








        if (collision.gameObject.CompareTag("Head"))
        {

            if (inputData.leftSpeed > 6 || inputData.rightSpeed > 6)
            {
                randomAnimationClip.enabled = false;
               ani.Play(animationName);
              
                Haptic();
                aniBool = false;


            }



        }



    }


    void AnimationPlay()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            Debug.Log("aNI");
            float animationTime = ani.GetCurrentAnimatorStateInfo(0).normalizedTime;
            animationDuration = ani.GetCurrentAnimatorStateInfo(0).length;
            currentPlayTime = animationTime * animationDuration;


            if (currentPlayTime >= animationDuration)
            {
                aniBool = true;
                randomAnimationClip.enabled = true;
                randomAnimationClip.T = false;
                Debug.Log("animat" + animationDuration);

            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        co = false;
    }
    void HealthDamage(int damageHealth)
    {
        enemy.healthAmount -= damageHealth;
    }
    void TimerIncreaseEnemyHealth()
    {
        if (timer > timeOverlLay)
        {
          
            if (enemy.healthAmount > 0 && enemy.healthAmount < enemy.maxHealth) 
            {
              
              
                enemy.healthAmount += Time.deltaTime * increaseHealthSpeed;
               enemy.VFXGreen.SetActive(true);
               
            }
            else
            {
                enemy.VFXGreen.SetActive(false);
            }


        }
        else
        {
        
         enemy.VFXGreen.SetActive(false) ;
        }




    }

    public void PlusuButton()
    {
        Debug.Log("ENYERR");
        controllerSpeed += 0.5f;
    }
    public void MinusButton()
    {
        controllerSpeed -= 0.5f;
    }

    public void OverLayPlusuButton()
    {

        timeOverlLay += 1f;
    }
    public void OverLayMinusButton()
    {
        timeOverlLay -= 1f;
    }
    public void TimerIncreaseSpeeedPlusuButton()
    {

        increaseHealthSpeed += 1f;
    }
    public void TimerIncreaseSpeedMinusButton()
    {
        increaseHealthSpeed -= 1f;
    }


    public void Haptic()
    {

        controller.SendHapticImpulse(0.4f, 2f);

    }
}

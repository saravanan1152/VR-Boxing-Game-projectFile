using RootMotion.Dynamics;
using UnityEngine;
using System.Collections;




    public class RandomAnimatorClip : MonoBehaviour
    {
     [SerializeField] public  Animator animator;
     [SerializeField]   public string[] animationNames;
     [SerializeField]   public int animationIndex;
      [SerializeField]  public float animationDuration;
      [SerializeField]  public bool T;
       [SerializeField] public int randomIndex;

     [SerializeField]   public string[] deathAnimationNames;
      [SerializeField]  public int deathAnimationIndex;
      [SerializeField]  public float deathAnimationDuration;
       [SerializeField] public float D_animationTime;
    [SerializeField] public int D_randomIndex;
        [SerializeField] bool D;
    public bool puppet=false;


    public Enemy enemy;

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


    bool deathBool;

   

    // Start is called before the first frame update
    void Start()
        {
            if (animator == null)
                animator = GetComponent<Animator>();
            puppetMaster = GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<PuppetMaster>();

      
            //pupet 
            defaultPosition = transform.position;
            defaultRotation = transform.rotation;

        }

        // Update is called once per frame
        void Update()
        {
     
        RandomAnimation();

       
           
        }
        void RandomAnimation()
        {
       
            AnimationTiming();
            playRantomAnimation();

      
        DeathAnimationTiming();
           
        }



        public void playRantomAnimation()
        {
            if (animationIndex >= animationNames.Length)
                animationIndex = 0;
            if (!T)
            {

                randomIndex = Random.Range(0, animationNames.Length);
                animator.Play(animationNames[randomIndex]);
            }
        }

        void AnimationTiming()
        {


            if (animator.GetCurrentAnimatorStateInfo(0).IsName(animationNames[randomIndex]))
            {
                float animationTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
                animationDuration = animator.GetCurrentAnimatorStateInfo(0).length;
                float currentPlayeTime = animationTime * animationDuration;
                T = true;

                if (animationDuration <= currentPlayeTime)
                {
                    T = false;
                }
            }



        }

   
    void DeathAnimationPlay()
    {
        if (deathAnimationIndex >= deathAnimationNames.Length)
        {
            deathAnimationIndex = 0;

        }
        if (!deathBool)
        {
            D_randomIndex = Random.Range(0, deathAnimationNames.Length);
            animator.Play(deathAnimationNames[deathAnimationIndex]);
        }
    }

    void DeathAnimationTiming()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(deathAnimationNames[deathAnimationIndex]))
        {
            D_animationTime= animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
          deathAnimationDuration = animator.GetCurrentAnimatorStateInfo(0).length;
            float currentPlayeTime = D_animationTime * deathAnimationDuration;
            T = true;
        }
    }
    public  void PuppetMasterUpdate()
        {
        if (!puppet)
        {
            T = true;
          
            DeathAnimationPlay();

            if (puppetMaster != null)
            {
                StopAllCoroutines();
                StartCoroutine(FadeOutPinWeight());
                StartCoroutine(FadeOutMuscleWeight());
            }
            puppet = true;

        }




    }

       
        public IEnumerator FadeOutPinWeight()
        {
            while (puppetMaster.pinWeight > 0f)
        {
         
            puppetMaster.pinWeight = Mathf.MoveTowards(puppetMaster.pinWeight, 0f, Time.deltaTime * fadeOutPinWeightSpeed);
                yield return null;
            }
        }

     
        private IEnumerator FadeOutMuscleWeight()
        {
            while (puppetMaster.muscleWeight > 0f)
            {
                puppetMaster.muscleWeight = Mathf.MoveTowards(puppetMaster.muscleWeight, deadMuscleWeight, Time.deltaTime * fadeOutMuscleWeightSpeed);
                yield return null;
            }
        }

    
}
    
    


    


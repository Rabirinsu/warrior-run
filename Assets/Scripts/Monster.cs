using System.Collections;
using UnityEngine;


public class Monster : MonoBehaviour
{
    private CharInteraction playerInteraction;
    public static Animator monsterAnimator;
    public static int PlayerHealth = 500;
    public static float spiderHealth = 1000;
    public static float golemHealth = 3000;
    public static float BlackSpiderHealth = 5000;
    public static float BlackGolemHealth = 8000;
    public static float SkeletonHealth = 15000;
    public static float DragonHealth = 20000;
    [SerializeField]private int spiderDamage;
    [SerializeField] private int golemDamage;
    [SerializeField] private int blackspiderDamage;
    [SerializeField] private int blackgolemDamage;
    [SerializeField] private int skeletonDamage;
    [SerializeField] private int dragonDamage;

    [SerializeField] private ParticleSystem hitParticle;

    [SerializeField] private GameObject Spider;
    [SerializeField] private GameObject Golem;
    [SerializeField] private GameObject BlackSpider;
    [SerializeField] private GameObject BlackGolem;
    [SerializeField] private GameObject Skeleton;
    [SerializeField] private GameObject Dragon;
    private string monsterName;
    [SerializeField]private float sphereRadius;
    private bool isSpiderDefeated = false;
    private bool isGolemDefeated = false;
    private bool isBlackSpiderDefeated = false;
    private bool isBlackGolemDefeated = false;
    private bool isSkeletonDefeated = false;
    private bool isDragonDefeated = false;
    private RaycastHit hit;
    private int layerMask;
    private Touch touch;


    private void Awake()
    {
       var  thePlayer = GameObject.Find("Player");
        playerInteraction = thePlayer.GetComponent<CharInteraction>();
    resetHeals();


    }
    [SerializeField] private float rayMaxDistance;
  

    private void Start()
    {
        layerMask = 1 << 8;
      
    }
    public void resetHeals()
    {
        spiderHealth = 1000;
        golemHealth = 3000;
        BlackSpiderHealth = 5000;
        BlackGolemHealth = 8000;
        SkeletonHealth = 15000;
        DragonHealth = 20000;
        isSpiderDefeated = false;
        isGolemDefeated = false;
        isBlackSpiderDefeated = false;
        isBlackGolemDefeated = false;
        isSkeletonDefeated = false;
        isDragonDefeated = false;
    }

    private void Update()
    {

     if(PlayerHealth>0 )
        {
            OnFight();
            
            DamageToMonster();
        }
    }
    IEnumerator TakeDamage() // TODO at two sec;
    {
      
        yield return new WaitForSeconds(1);
      
        switch (monsterName)
        {

            case "SPIDER(Clone)":
                spiderHealth -= Sword.Damage;
                StartCoroutine(monsterAttack(MonsterSpawner.SpiderClone, spiderDamage));
                break;
            case "Golem(Clone)":
              
                golemHealth -= Sword.Damage;
                StartCoroutine(monsterAttack(MonsterSpawner.GolemClone, golemDamage));
                break;
            case "BlackSpider(Clone)":
             
                BlackSpiderHealth -= Sword.Damage;
                StartCoroutine(monsterAttack(MonsterSpawner.BlackSpiderClone, blackspiderDamage));
                break;
            case "BlackGolem(Clone)":
            
                BlackGolemHealth -= Sword.Damage;
                StartCoroutine(monsterAttack(MonsterSpawner.BlackGolemClone, blackgolemDamage));
                break;
            case "Skeleton(Clone)":
            
                SkeletonHealth -= Sword.Damage;
                StartCoroutine(monsterAttack(MonsterSpawner.SkeletonClone, skeletonDamage));
                break;
            case "Dragon(Clone)":
                
                DragonHealth -= Sword.Damage;
                StartCoroutine(monsterAttack(MonsterSpawner.DragonClone, dragonDamage));
                break;


        }

        StopCoroutine(nameof(TakeDamage));
    }
    IEnumerator monsterAttack(GameObject fightMonster, int monsterDamage)
    {
       
        monsterAnimator = fightMonster.GetComponent<Animator>();
        monsterAnimator.SetBool("Idle", false);
        monsterAnimator.SetBool("Attack", true);
        playerInteraction.player_SFX.PlayOneShot(playerInteraction.playerHitClip[Random.Range(0, playerInteraction.playerDamagedClip.Count)], .3f); // PLAYER HITTIN MONSTER SOUND
        hitParticle.Play();
        yield return new WaitForSeconds(.75f);
        PlayerHealth -= monsterDamage;
        //sounds
        playerInteraction.player_SFX.PlayOneShot(playerInteraction.playerDamagedClip[Random.Range(0, playerInteraction.playerDamagedClip.Count)], 1f); // PLAYER TAKING DAMAGE SOUND
      
        StopCoroutine(nameof(monsterAttack));
        monsterAnimator.SetBool("Attack", false);
        monsterAnimator.SetBool("Idle", true);   
    }
  
      

    protected void DamageToMonster()
    {
        
        if (CharInteraction.charAnim.GetCurrentAnimatorStateInfo(0).IsName("Fight"))
        {
            StartCoroutine(nameof(TakeDamage));

        }// TODO JUST ONE SHOT

        if (spiderHealth <= 0 && !isSpiderDefeated)
        {
           
            Destroy(MonsterSpawner.SpiderClone);
            Run();
            isSpiderDefeated = true;
        }
        if (golemHealth <= 0 && !isGolemDefeated)
        {
          
            Destroy(MonsterSpawner.GolemClone);
            Run();
            isGolemDefeated = true;
        }
        if (BlackSpiderHealth <= 0 && !isBlackSpiderDefeated)
        {
           
            Destroy(MonsterSpawner.BlackSpiderClone);
            Run();
            isBlackSpiderDefeated = true;
        }
        if (BlackGolemHealth <= 0 && !isBlackGolemDefeated)
        {
            Destroy(MonsterSpawner.BlackGolemClone);
            Run();
            isBlackGolemDefeated = true;
        }
        if (SkeletonHealth <= 0 && !isSkeletonDefeated)
        {
            Destroy(MonsterSpawner.SkeletonClone);
            Run();
            isSkeletonDefeated = true;
        }
        if (DragonHealth <= 0 && !isDragonDefeated)
        {
            Destroy(MonsterSpawner.DragonClone);
            Run();
            isDragonDefeated = true;
        }
   
    }
    void Run()
    {
        CharInteraction.CharState = CharInteraction.CharachterState.Run;
        CharInteraction.SetAnimation();

    }
    protected virtual void OnFight()
    {
  
        if (Physics.SphereCast(transform.position, sphereRadius,Vector3.left, out hit, rayMaxDistance, layerMask, QueryTriggerInteraction.UseGlobal)) // TODO: Monster Seen Player Stop And Animate Camera Change
        {
         
            monsterName = transform.name; // IMPORTANT !
            if (CharInteraction.CharState != CharInteraction.CharachterState.Attack )
            {
               
                CharInteraction.CharState = CharInteraction.CharachterState.Idle;
                CharInteraction.SetAnimation();
            }
         
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

/*
#######################################################
#                                                     #
#   Combat Simulator                                  #
#   Designed by Michael Noseworthy                    #
#                                                     #
#######################################################
*/

public class Character : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletSpawnPoint;
    [SerializeField]
    private GameObject MeleeBulletPrefab;
    private GameObject Bullet;
    public GameObject DeathAnimation;

    public Collider entityCollider;
    //public float playerID = 0;
    //public float EnemyID = 0;

    private String entityName;
    [SerializeField]
    public bool Melee = false;
    [SerializeField]
    public bool Ranged = false;
    [SerializeField]
    public bool RockThrower = false;
    [SerializeField]
    public bool MagicUser = false;
    [SerializeField]
    public float distanceFromTargetToAttack = 0.0f;

    [SerializeField]
    int damageToDeal;
    private Character EnemyScript;//Gives current player the ability to control his enemy, like take damage

    

    public RectTransform healthBar;
    public const int maxHealth = 100;
    [SerializeField]
    public int currentHealth = maxHealth;
    //[SerializeField]
    //public int dealDamage;
    public float rockTimer = 0.0f;
    public float waitingForRockTimer = 3;


    private GameObject MagicUserBullet;
    private VolumetricLineSettings ScriptTest;

    public bool isDead;
    public bool isNearestEntityDead;

    Animator m_Animator;

    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float rotateSpeed = 3f;

    private State currentState;
    public Transform nearestEntity;
    public float checkRadius;
    public LayerMask checkLayers;

    public static Collider[] colliders;

    public bool amIDead()
    {
        return isDead;
    }

    public int GetHealth()
    {
        return currentHealth;
    }
    /*
    public void TakeRangedDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }
    */
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    public void setAnimation(string anim)
    {
        m_Animator.Play(anim);
    }
    public void onFire()
    {
        if (Melee == true)
        {
            //Instantiate(MeleeBulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            EnemyScript.TakeDamage(damageToDeal);

        }

        if (Ranged == true)
        {
            Instantiate(MeleeBulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        }

        if (RockThrower == true)
        {
           GetComponent<CannonBall>().fireCannonBall(nearestEntity.transform);
        }

        if (MagicUser == true)
        {
            float SetValue = (nearestEntity.transform.position.z - transform.position.z);
            MagicUserBullet = Instantiate(MeleeBulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            MagicUserBullet.SendMessageUpwards("SetValue", SetValue, SendMessageOptions.DontRequireReceiver);
            EnemyScript.TakeDamage(damageToDeal);
        }
    }

    private void Start()
    {
        //playerID = UnityEngine.Random.value;

        entityName = this.gameObject.name;
        m_Animator = GetComponent<Animator>();
        
        //setAnimation("1handedWalk");
        //m_Animator.Play("2handedWalk");
        isDead = false;
        entityCollider = GetComponent<CapsuleCollider>();
        SetState(new IdleState(this));
    }

    private void Update()
    {
        
        bool pausegame = GameObject.FindWithTag("GameController").GetComponent<GameManager>().PauseGame;
        if (pausegame)
        currentState.Tick();
        
        colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        if (colliders[0] != null)
            Array.Sort(colliders, new DistanceComparer(transform));

        if (colliders[0] != null)
        nearestEntity = colliders[0].GetComponent<Transform>();
        isNearestEntityDead = colliders[0].GetComponent<Character>().amIDead();
        EnemyScript = colliders[0].GetComponent<Character>();
        if (isNearestEntityDead)
        {
            
            nearestEntity = null;
            colliders = null;
            //colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
            //Array.Sort(colliders, new DistanceComparer(transform));
            

        }

        if (nearestEntity == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
            Array.Sort(colliders, new DistanceComparer(transform));
            nearestEntity = colliders[0].GetComponent<Transform>();
        }
    }

    public void SetState(State state)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;
        gameObject.name = entityName + " - " + state.GetType().Name;
        

        if (currentState != null)
            currentState.OnStateEnter();
    }

    //public void MoveToward(Vector3 destination)
    public void MoveToward(Transform destination)
    {
        // rotate and move towards object

        Vector3 targetDirection = destination.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(targetDirection.x, 0, targetDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);

        transform.transform.position += transform.transform.forward * moveSpeed * Time.deltaTime;



        /*
        float step = rotateSpeed;// * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, destination, step, 0.0f);
        //draw line for rotation in the editor
        // Move our rotation position a step closer to the target
        
        transform.rotation = Quaternion.LookRotation(direction * Time.deltaTime * moveSpeed);
        //Debug.DrawRay(transform.position, newDir, Color.red);
        */
        // move towards object
        //transform.rotation = Quaternion.LookRotation(destination);

        //transform.rotation = Quaternion.LookRotation(direction * Time.deltaTime * moveSpeed);
        //var direction = GetDirection(destination);
        //transform.Translate(direction * Time.deltaTime * moveSpeed);

    }

    
    public void RotateToward(Vector3 destination)
    {
        
        //var direction = GetDirection(destination);
        //transform.Translate(direction * Time.deltaTime * moveSpeed);
        
        var direction = GetDirection(destination);
        float step = rotateSpeed;// * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, destination, step, 0.0f);
        //draw line for rotation in the editor
        // Move our rotation position a step closer to the target
        //transform.rotation = Quaternion.LookRotation(newDir);
        transform.rotation = Quaternion.LookRotation(direction * Time.deltaTime * moveSpeed);
        //Debug.DrawRay(transform.position, newDir, Color.red);

        //Vector3 targetDir = nearestEntity.transform.position;
        
    }
     
     
    private Vector3 GetDirection(Vector3 destination)
    {
        return (destination - transform.position).normalized;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }

    public void destroyAI()
    {
        Destroy(this.gameObject);
    }

    public void onDeath()
    {

        Instantiate(DeathAnimation, transform.position, transform.rotation);
    }
}
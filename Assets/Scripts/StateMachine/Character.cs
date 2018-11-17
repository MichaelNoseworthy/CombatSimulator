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
    private GameObject bulletSpawnPoint;//Where bullets/attacks spawn from
    [SerializeField]
    private GameObject BulletPrefab; //The bullet used to attack with if any
    //private GameObject Bullet;
    public GameObject DeathAnimation;

    public Collider entityCollider;
    //public float playerID = 0;
    //public float EnemyID = 0;

    public String entityName; //Name of current entity
    [SerializeField]
    public bool Melee = false;//character type
    [SerializeField]
    public bool Ranged = false;//character type
    [SerializeField]
    public bool RockThrower = false;//character type
    [SerializeField]
    public bool MagicUser = false;//character type
    [SerializeField]
    public float distanceFromTargetToAttack = 0.0f;//Distance before AI Entity decides to attack

    [SerializeField]
    int damageToDeal;
    private Character EnemyScript;//Gives current AI Enitity the ability to control his enemy, like take damage

    

    public RectTransform healthBar;
    public const int maxHealth = 100;
    [SerializeField]
    public int currentHealth = maxHealth;
    //[SerializeField]
    //public int dealDamage;
    public float rockTimer = 0.0f;//initial time For the RockThrower
    public float waitingForRockTimer = 3;//max time for the rock thrower to shoot


    private GameObject MagicUserBullet;//Gives the ability to control the beam/bullet

    //isDead is for the current AI, isNearestEntityDead is for getting that information from another AI.
    public bool isDead;//Reports whether or not the current AI is in DeathState
    public bool isNearestEntityDead;//Gets the report of whether the enemy AI is in DeathState

    Animator m_Animator;//Gets the animations for this AI

    [SerializeField]
    private float moveSpeed = 3f;//How fast the AI moves
    //[SerializeField]
    //private float rotateSpeed = 3f;

    private State currentState;
    public Transform nearestEntity;//Gets the location of the nearest enemy AI
    public float checkRadius;//Range to check for enemy AI
    public LayerMask checkLayers;//Which layer to check for the enemy.

    public static Collider[] colliders;//Array to place where the closest enemy AI is

    public bool amIDead()
    {
        return isDead;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

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
            EnemyScript.TakeDamage(damageToDeal);
        }

        if (Ranged == true)
        {
            Instantiate(BulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        }

        if (RockThrower == true)
        {
           GetComponent<CannonBall>().fireCannonBall(nearestEntity.transform);
        }

        if (MagicUser == true)
        {
            //For the animation to work one needs to get the distance from the current AI to the enemy AI, then cast the beam/bullet
            float SetValue = (nearestEntity.transform.position.z - transform.position.z);
            MagicUserBullet = Instantiate(BulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            MagicUserBullet.SendMessageUpwards("SetValue", SetValue, SendMessageOptions.DontRequireReceiver);//Sends the coordinates to the beam/bullet
            EnemyScript.TakeDamage(damageToDeal);//deals damage to the enemy
        }
    }

    private void Start()
    {
        entityName = this.gameObject.name;
        m_Animator = GetComponent<Animator>();
        
        //setAnimation("1handedWalk");
        //m_Animator.Play("2handedWalk");
        isDead = false;
        entityCollider = GetComponent<CapsuleCollider>();
        SetState(new IdleState(this));//default state
    }

    private void Update()
    {
        
        bool pausegame = GameObject.FindWithTag("GameController").GetComponent<GameManager>().PauseGame;
        if (pausegame)
        {
            

            colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
            try
            {
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
                }

                if (nearestEntity == null)
                {
                    colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
                    Array.Sort(colliders, new DistanceComparer(transform));
                    nearestEntity = colliders[0].GetComponent<Transform>();
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                //Suppressing the error that the array is out of bounds when checking if colliders are null
                //Debug.Log("Index error intentional");
            }

            currentState.Tick();
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

    //Used to move the AI towards a destination
    public void MoveToward(Transform destination)
    {
        // rotate and move towards object

        Vector3 targetDirection = destination.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(targetDirection.x, 0, targetDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
        transform.transform.position += transform.transform.forward * moveSpeed * Time.deltaTime;
    }

    //Used during attacks to move the AI's front position towards the enemy AI
    public void RotateToward(Vector3 destination)
    {
        
        var direction = GetDirection(destination);
        transform.rotation = Quaternion.LookRotation(direction * Time.deltaTime * moveSpeed);
        Debug.DrawRay(transform.position, direction, Color.red);
        
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
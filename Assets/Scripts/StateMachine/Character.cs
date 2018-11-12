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

    public Collider entityCollider;

    private String entityName;


    public RectTransform healthBar;
    public const int maxHealth = 100;
    [SerializeField]
    public int currentHealth = maxHealth;
    [SerializeField]
    public int dealDamage;

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

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    public void setAnimation(string anim)
    {
        m_Animator.Play(anim);
    }
    public void onFire()
    {
        Instantiate(MeleeBulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
    }

    private void Start()
    {
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
        currentState.Tick();
        
        colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        if (colliders[0] != null)
            Array.Sort(colliders, new DistanceComparer(transform));

        if (colliders[0] != null)
        nearestEntity = colliders[0].GetComponent<Transform>();
        isNearestEntityDead = colliders[0].GetComponent<Character>().amIDead();

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

    public void MoveToward(Vector3 destination)
    {
        // rotate and move towards object


        var direction = GetDirection(destination);
        /*
        float step = rotateSpeed;// * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, destination, step, 0.0f);
        //draw line for rotation in the editor
        // Move our rotation position a step closer to the target
        //transform.rotation = Quaternion.LookRotation(newDir);
        transform.rotation = Quaternion.LookRotation(direction * Time.deltaTime * moveSpeed);
        //Debug.DrawRay(transform.position, newDir, Color.red);
        */
        // move towards object
        transform.Translate(direction * Time.deltaTime * moveSpeed);
        //transform.rotation = Quaternion.LookRotation(direction * Time.deltaTime * moveSpeed);

    }
    public void RotateToward(Vector3 destination)
    {
        /*
        var direction = GetDirection(destination);
        transform.Translate(direction * Time.deltaTime * moveSpeed);
        */
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
    
}
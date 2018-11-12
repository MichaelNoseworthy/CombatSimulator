using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sense : MonoBehaviour {

    public float checkRadius;
    public LayerMask checkLayers;

    public Transform nearestEntity;

    // The target marker.
    public Transform target;

    // Speed in units per sec.
    public float speed = 3;
    private bool isMoving = false;

    Animator m_Animator;

    public Transform getNearest()
    {
        return nearestEntity.transform.transform;
    }

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }
    private void Update()
    {
        isMoving = !isMoving;
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceComparer(transform));

        /*
        foreach (Collider item in colliders)
        {
            Debug.Log(item.name);
        }
        */
        nearestEntity = colliders[0].GetComponent<Transform>();
        Debug.Log(nearestEntity.transform.transform);
        
        processAI();
    }

    private void processAI()
    {
        target = nearestEntity;
        if (isMoving == true)
        {
            m_Animator.Play("2handedWalk");

            Vector3 targetDir = target.position - transform.position;

            // The step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);

            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);

            // The step size is equal to speed times frame time.
            

            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

        float angle = 45;
 if (Vector3.Angle(target.transform.forward, transform.position - target.transform.position) < angle)
            if ((transform.position.magnitude - target.transform.position.magnitude) < 0.00005 )
        {
            isMoving = false;
            m_Animator.Play("1handedAttack1");
        }
        /*
               if (  0.2 < (transform.position.z - target.position.z))
               {
                   isMoving = false;
                   m_Animator.Play("1handedAttack1");
               }

               if ((transform.position.x - target.position.x) < 0.002)
               {
                   isMoving = false;
                   m_Animator.Play("1handedAttack1");
               }
               */
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}

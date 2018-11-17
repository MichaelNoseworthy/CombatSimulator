using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBullet : MonoBehaviour
{

    protected bool m_AlreadyHitSomething = false;
    public float Force = 700;
    public int TakeDamage;
    Rigidbody m_rb;
    public string LayerToDamage;


    private void FixedUpdate()
    {
         Destroy(gameObject, 3);
    }

    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        //startTime = Time.time;
        //Physics.IgnoreCollision(GetComponent<Collider>(), GetComponent<Collider>());
        //Physics.IgnoreLayerCollision(0, 8);

        m_rb = GetComponent<Rigidbody>();
        m_rb.AddForce(transform.forward * Force);

    }


    /// <summary>
    /// 
    /// </summary>
    void OnTriggerEnter(Collider col)
    {

        //if (m_AlreadyHitSomething)
        //    return;

        // we can only damage something upon first collision. this means that
        // as soon as the arrow bounces around against stone walls or whatnot,
        // it has already been disarmed
        //m_AlreadyHitSomething = true;

        // see if arrow should stick & do damage
        // TIP: add more logic to this if-statement to identify possible target objects
        // (this is a little brute force but does the trick)


        
            if (col.gameObject.tag == LayerToDamage) //Enemies

        {
            // attach arrow to target object
            //transform.parent = col.transform;
            //transform.localPosition = col.transform.InverseTransformPoint(col.contacts[0].point);

            // disable the arrow's own physics
            //Destroy(gameObject); // unfortunately there is no good way of disabling physics without doing this :/

            // we may want to disable the collider too. if so, wait a sec so
            // all the collision logic has time to finish:
            // vp_Timer.In(1.0f, delegate () { if (collider != null) collider.enabled = false; });

            // do damage to the target
            // NOTE: your target object must have a vp_DamageHandler script ...
            // ... OR a script with a method called 'Damage' which takes a float argument
            col.GetComponent<Collider>().SendMessageUpwards("TakeDamage", TakeDamage, SendMessageOptions.DontRequireReceiver);

            // TIP: play a meaty impact sound here
            Destroy(gameObject);
            return;

        }

        // TIP: play a hard surface impact sound here

        // TIP: if we get here without doing damage, remove the arrow and replace it
        // with an arrow pickup of some kind!

    }

}

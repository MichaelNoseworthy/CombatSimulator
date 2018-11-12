using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBullet : MonoBehaviour {

    [SerializeField]
    public int damage;
    
    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<Character>();
        
        if (health != null)
        {
            health.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        damage = 10;
    }

}

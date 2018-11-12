using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State {

    private Vector3 destination = Vector3.zero;

    public float m_timeElapsed = 0.0f;

    public AttackState(Character character) : base(character)
    {
    }

    public override void Tick()
    {
        if (character.nearestEntity != null)
            character.RotateToward(character.nearestEntity.transform.position);
        else
        {
            character.SetState(new IdleState(character));
        }

        if (!character.isNearestEntityDead)
        {
            if (m_timeElapsed >= 0.99f)
            character.onFire();
        }
        //bullet.rigidbody.AddForce(transform.forward * force);
        //gameObject bullet = Instantiate(BulletPrefab,GameObject.Find("spawnPoint").transform.position,Quaternion.identity
        if (character.currentHealth == 0)
        {
            character.SetState(new DeathState(character));
            //character.setAnimation("2handedDeath");
        }

        if (character.isNearestEntityDead)
        {
            character.SetState(new IdleState(character));
        }


        m_timeElapsed += Time.fixedDeltaTime;
        if (m_timeElapsed >= 1.0f)
            m_timeElapsed = 0.0f;

    }

    public override void OnStateEnter()
    {
        //character.GetComponent<Renderer>().material.color = Color.blue;
        character.setAnimation("1handedAttack1Forward");
        character.onFire();

    }

    public override void OnStateExit()
    {
       // delete IdleState(character);
    }

    private void FixedUpdate()
    {
    }

}

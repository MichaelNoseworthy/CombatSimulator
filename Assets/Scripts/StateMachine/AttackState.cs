using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State {

    //private Vector3 destination = Vector3.zero;

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
            if (character.Melee == true)
            {
                if (m_timeElapsed >= 0.99f)
                {
                    character.RotateToward(character.nearestEntity.transform.position);
                    character.onFire();
                }
            }
            if (character.Ranged == true)
            {
                if (m_timeElapsed >= 0.99f)
                {
                    character.RotateToward(character.nearestEntity.transform.position);
                    character.onFire();
                }
            }
            if (character.RockThrower == true)
            {
                character.rockTimer += Time.deltaTime;
                if (character.rockTimer > character.waitingForRockTimer)
                {
                    character.RotateToward(character.nearestEntity.transform.position);
                    character.setAnimation("attack2");
                    character.onFire();
                    if (character.rockTimer > 0.5f)
                    {
                        character.setAnimation("idle");
                    }
                    character.rockTimer = 0;
                }
                //character.setAnimation("idle");
            }
            if (character.MagicUser == true)
            {
                if (m_timeElapsed >= 0.99f)
                {
                    character.RotateToward(character.nearestEntity.transform.position);
                    character.onFire();
                }
            }

            if (character.currentHealth <= 0)
            {
                character.SetState(new DeathState(character));
                //character.setAnimation("2handedDeath");
            }
        }
        //bullet.rigidbody.AddForce(transform.forward * force);
        //gameObject bullet = Instantiate(BulletPrefab,GameObject.Find("spawnPoint").transform.position,Quaternion.identity
        

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
        if (character.Melee == true)
        {
            //character.GetComponent<Renderer>().material.color = Color.blue;
            character.setAnimation("1handedAttack1Forward");
            character.onFire();
        }
        if (character.Ranged == true)
        {
            character.RotateToward(character.nearestEntity.transform.position);
            character.setAnimation("attack2");
            character.onFire();
        }
        if (character.RockThrower == true)
        {
            character.RotateToward(character.nearestEntity.transform.position);
            character.setAnimation("idle");
            character.onFire();


        }
        if (character.MagicUser == true)
        {
            character.RotateToward(character.nearestEntity.transform.position);
            character.setAnimation("getHit");
            character.onFire();
        }

    }

    public override void OnStateExit()
    {
        character.nearestEntity = null;
        // delete IdleState(character);
    }

    private void FixedUpdate()
    {
    }

    IEnumerator RockAnimationWait(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            character.setAnimation("idle");
        }
        
    }
}

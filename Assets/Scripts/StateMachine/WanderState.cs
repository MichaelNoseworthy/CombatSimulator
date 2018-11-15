using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WanderState : State
{
    private Vector3 nextDestination;
    

    public WanderState(Character character) : base(character)
    {
    }

    public override void OnStateEnter()
    {
        
        nextDestination = GetDestination();
        if (character.Melee == true)
        {
            character.setAnimation("2handedWalk");
        }
        if (character.Ranged == true)
        {
            character.setAnimation("walk");
        }
        if (character.RockThrower == true)
        {
            character.setAnimation("walk");
        }
        if (character.MagicUser == true)
        {

        }
        
        character.isNearestEntityDead = character.nearestEntity.GetComponent<Character>().amIDead();

        //character.GetComponent<Renderer>().material.color = Color.green;
    }

    private Vector3 GetDestination()
    {
        Vector3 targetDir = character.nearestEntity.position;// - character.transform.position;
            return targetDir;
    }

    public override void Tick()
    {
        if (ReachedDestination())
        {
            character.SetState(new AttackState(character));
        }

        character.isNearestEntityDead = character.nearestEntity.GetComponent<Character>().amIDead();

        if (!character.isNearestEntityDead)
            character.MoveToward(character.nearestEntity);
        else
            character.SetState(new IdleState(character));

        if (character.currentHealth <= 0)
        {
            character.currentHealth = 0;
            Debug.Log("Dead!");
            character.SetState(new DeathState(character));
        }
        //timer += Time.deltaTime;
        /*
        if (character.nearestEntity != null)
            if (Vector3.Distance(character.transform.position, character.nearestEntity.position) < 1.0f)
        {
            character.SetState(new AttackState(character));
        }
        */
    }

    private bool ReachedDestination()
    {
        if (character.Melee == true)
        return Vector3.Distance(character.transform.position, character.nearestEntity.position) < character.distanceFromTargetToAttack;
        if (character.Ranged == true)
            return Vector3.Distance(character.transform.position, character.nearestEntity.position) < character.distanceFromTargetToAttack;
        if (character.RockThrower == true)
            return Vector3.Distance(character.transform.position, character.nearestEntity.position) < character.distanceFromTargetToAttack;
        if (character.MagicUser == true)
            return Vector3.Distance(character.transform.position, character.nearestEntity.position) < character.distanceFromTargetToAttack;

        else return true;
    }
}
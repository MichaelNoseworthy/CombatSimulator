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
        character.setAnimation("2handedWalk");
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
        
        

        character.MoveToward(GetDestination());
        

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

        return Vector3.Distance(character.transform.position, character.nearestEntity.position) < 1.5f;
    }
}
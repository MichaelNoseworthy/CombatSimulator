using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHomeState : State
{
    private Vector3 destination;

    public ReturnHomeState(Character character) : base(character)
    {
    }

    public override void Tick()
    {
        character.MoveToward(destination);

        if (ReachedHome())
        {
            character.SetState(new WanderState(character));
        }
    }

    public override void OnStateEnter()
    {
        destination = character.transform.position;
        //character.GetComponent<Renderer>().material.color = Color.blue;
        //character.setAnimation("1handedWalk");
    }

    private bool ReachedHome()
    {
        return Vector3.Distance(character.transform.position, destination) < 0.5f;
    }
}
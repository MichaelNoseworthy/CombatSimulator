using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class IdleState : State {
    

    public IdleState(Character character) : base(character)
    {
    }

    public override void Tick()
    {
        if (character.nearestEntity != null)
        {
            character.SetState(new WanderState(character));
        }

        
    }

    public override void OnStateEnter()
    {
        character.setAnimation("idleProtected");
    }
    
}

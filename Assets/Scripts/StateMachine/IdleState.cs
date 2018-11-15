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


        if (character.currentHealth <= 0)
        {
            character.currentHealth = 0;
            Debug.Log("Dead!");
            character.SetState(new DeathState(character));
        }


    }

    public override void OnStateEnter()
    {
        if (character.Melee == true)
        {
            character.setAnimation("idleProtected");
        }
        if (character.Ranged == true)
        {
            character.setAnimation("idle");
        }
        if (character.RockThrower == true)
        {

        }
        if (character.MagicUser == true)
        {
            character.setAnimation("sleep");
        }
        
    }
    
}

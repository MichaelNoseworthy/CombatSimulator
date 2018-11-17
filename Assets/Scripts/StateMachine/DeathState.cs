using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State {

    public DeathState(Character character) : base(character)
    {
    }

    public override void Tick()
    {
        character.destroyAI();
    }

    public override void OnStateEnter()
    {
        character.isDead = true;//Tells the other AI's that this player is dead

        Debug.Log(character.entityName + " - Dead!");
        character.onDeath();//Creates a death animation
        if (character.Melee == true)
        {
            
        }
        if (character.Ranged == true)
        {
            
        }
        if (character.RockThrower == true)
        {
            
        }
        if (character.MagicUser == true)
        {
            
        }
    }
    /*
    IEnumerator changeLayer()
    {
        yield return new WaitForSeconds(0.2f);
        character.gameObject.layer = 0;
    }

    IEnumerator destroyCharacter()
    {
        yield return new WaitForSeconds(0.1f);
        if (character.Melee == true)
        {
            character.destroyAI();
        }
        if (character.Ranged == true)
        {
            character.destroyAI();
        }
        if (character.RockThrower == true)
        {
            character.destroyAI();
        }
        if (character.MagicUser == true)
        {
            character.destroyAI();
        }
        character.destroyAI();
    }

    */

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State {

    public DeathState(Character character) : base(character)
    {
    }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {
        character.isDead = true;
        character.setAnimation("2handedDeath");
        changeLayer();
        
        destroyCharacter();
    }

    IEnumerator changeLayer()
    {
        yield return new WaitForSeconds(0.1f);
        character.gameObject.layer = 0;
    }

    IEnumerator destroyCharacter()
    {
        yield return new WaitForSeconds(0.5f);
        character.entityCollider.enabled = false;
        character.destroyAI();
    }

    

}

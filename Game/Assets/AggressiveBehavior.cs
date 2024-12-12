using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveBehavior : IMobBehavior
{
    public void Act(MobBehavior mob, Transform player)
    {
        Vector3 direction = (player.position - mob.transform.position).normalized;
        float distance = Vector3.Distance(mob.transform.position, player.position);

        if (distance > 1f) // «алишайте м≥н≥мальну дистанц≥ю до гравц€
        {
            mob.transform.position += direction * mob.speed * Time.deltaTime;
        }
        else
        {
            mob.AttackPlayer(player); // јтака гравц€, €кщо близько
        }
    }
}

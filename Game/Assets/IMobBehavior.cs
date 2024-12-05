using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMobBehavior
{
    void Act(MobBehavior mob, Transform player);
}
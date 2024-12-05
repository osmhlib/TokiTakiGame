using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BehaviorFactory
{
    public static IMobBehavior Create(string behaviorType)
    {
        return behaviorType switch
        {
            "Aggressive" => new AggressiveBehavior(),
            // Можна додати інші типи, наприклад, "Evasive".
            _ => null,
        };
    }
}


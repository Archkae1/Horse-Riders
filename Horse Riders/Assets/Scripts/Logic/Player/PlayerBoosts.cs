using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoosts
{
    private Dictionary<Type, Coroutine> coroutines;

    public Dictionary<Type, Coroutine> getCoroutines => coroutines;

    public void LoadPlayerBoosts()
    {
        coroutines = new Dictionary<Type, Coroutine>()
        {
            [typeof(ScoreMultiplierBoost)] = null
        };
    }

    public void StartCoroutine(Type type, Coroutine coroutine) => coroutines[type] = coroutine;

    public void StopCoroutine(Type type) => coroutines[type] = null;
}

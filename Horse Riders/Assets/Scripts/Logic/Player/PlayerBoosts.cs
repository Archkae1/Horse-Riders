using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoosts
{
    private Dictionary<Type, Coroutine> coroutines;

    public Dictionary<Type, Coroutine> getCoroutines => coroutines;

    public void Load()
    {
        coroutines = new Dictionary<Type, Coroutine>()
        {
            [typeof(ScoreMultiplierBoost)] = null
        };
    }

    public void SetDictCoroutine(Type type, Coroutine coroutine) => coroutines[type] = coroutine;

    public void RemoveDictCoroutine(Type type) => coroutines[type] = null;
}

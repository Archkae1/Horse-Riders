using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    private Boost[] boosts;

    public void Load(GameObject pickupablesRoot)
    {
        boosts = pickupablesRoot.GetComponentsInChildren<Boost>();
        TrySpawnBoosts();
    }

    public void TrySpawnBoosts()
    {
        foreach (Boost _boost in  boosts)
        {
            int random = Random.Range(0, 99);
            if (random <= _boost.getSpawnChance) _boost.SpawnBoost();
        }
    }
}
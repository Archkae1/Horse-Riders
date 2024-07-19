using UnityEngine;

public class BoostsContainer : MonoBehaviour
{
    private Boost[] boosts;

    public void Load()
    {
        boosts = GetComponentsInChildren<Boost>();
    }

    public void TrySpawnBoosts()
    {
        foreach (Boost _boost in  boosts)
        {
            int random = Random.Range(0, 99);
            if (random <= _boost.getSpawnChance) _boost.EnablePickupable();
        }
    }
}

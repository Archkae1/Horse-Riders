using UnityEngine;

public class BoostsContainer : MonoBehaviour
{
    private Boost[] boosts;

    public void Load(GameInstance gameInstance)
    {
        boosts = GetComponentsInChildren<Boost>(true);
        foreach (Boost _boost in boosts) _boost.Load(gameInstance);
    }

    public void TrySpawnBoosts()
    {
        foreach (Boost _boost in boosts)
        {
            int random = Random.Range(0, 100);
            if (random <= _boost.getSpawnChance) _boost.EnablePickupable();
        }
    }
}

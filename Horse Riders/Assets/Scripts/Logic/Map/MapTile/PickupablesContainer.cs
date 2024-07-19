using UnityEngine;

public class PickupablesContainer : MonoBehaviour
{
    private Pickupable[] pickupables;

    public void Load(GameInstance gameInstance)
    {
        pickupables = GetComponentsInChildren<Pickupable>();
        foreach (Pickupable _pickupable in pickupables) _pickupable.Load(gameInstance);
    }

    public void EnablePickupables()
    {
        foreach (Pickupable _pickupable in pickupables) _pickupable.EnablePickupable();
    }
}

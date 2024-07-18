using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class Pickupable : MonoBehaviour
{
    private GameObject root;
    private SphereCollider sphereCollider;

    public static Action<Collider, Player> triggerPickupable;

    public abstract void OnPickup(Player player);

    public abstract void LoadComponents(GameInstance gameInstance);

    public void Load(GameInstance gameInstance)
    {
        sphereCollider = GetComponent<SphereCollider>();
        root = transform.parent.gameObject;
        LoadComponents(gameInstance);
    }

    private void OnTriggerPickupable(Collider triggeredSphereCollider, Player player)
    {
        if (triggeredSphereCollider == sphereCollider)
        {
            OnPickup(player);
            Destroy(root);
        }
    }

    private void OnEnable()
    {
        triggerPickupable += OnTriggerPickupable;
    }

    private void OnDisable()
    {
        triggerPickupable -= OnTriggerPickupable;
    }
}

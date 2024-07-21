using System;
using UnityEngine;
using Zenject;

public class Magnet : MonoBehaviour
{
    [SerializeField] private GameObject magnetFX;
    private SphereCollider sphereCollider;
    private MeshRenderer meshRenderer;
    private int pickupableLayer => LayerMask.NameToLayer("Pickupable");

    [Inject] private Player player;

    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
        sphereCollider.enabled = false;
        meshRenderer.enabled = false;
    }

    private void OnBoostStart(Type type, int time)
    {
        if (type == typeof(MagnetBoost))
        {
            sphereCollider.enabled = true;
            meshRenderer.enabled = true;
            magnetFX.SetActive(true);
        }
    }

    private void OnBoostEnd(Type type)
    {
        if (type == typeof(MagnetBoost))
        {
            sphereCollider.enabled = false;
            meshRenderer.enabled = false;
            magnetFX.SetActive(false);
        }
    }

    private void OnAllBoostEnd()
    {
        sphereCollider.enabled = false;
        meshRenderer.enabled = false;
        magnetFX.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == pickupableLayer) player.TriggerPickupable(collider);
    }

    private void OnEnable()
    {
        Boost.boostStart += OnBoostStart;
        Boost.boostEnd += OnBoostEnd;
        Boost.allBoostEnd += OnAllBoostEnd;
    }

    private void OnDisable()
    {
        Boost.boostStart -= OnBoostStart;
        Boost.boostEnd -= OnBoostEnd;
        Boost.allBoostEnd -= OnAllBoostEnd;
    }
}

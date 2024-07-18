using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObstaclesContainer), typeof(BoostSpawner))]
public class MapTile : MonoBehaviour
{
    [SerializeField] private BoxCollider triggerCollider;
    [SerializeField] private bool destroyOnTrigger = true;
    [SerializeField] private List<GameObject> staticRoots;
    [SerializeField] private GameObject pickupablesRoot; 
    private bool createNewTiles = true;

    [SerializeField] private ObstaclesContainer obstaclesContainer;
    [SerializeField] private BoostSpawner boostSpawner;
    private Pickupable[] pickupables;

    public bool setCreateNewTiles { set { createNewTiles = value; } }
    public bool setDestroyOnTrigger { set { destroyOnTrigger = value; } }
    public BoxCollider getTriggerCollider { get { return triggerCollider; } }

    public static Action<MapTile, bool> outOfTrigger;
    public static Action enterEndGameState;

    public void Load(GameInstance gameInstance)
    {
        pickupables = pickupablesRoot.GetComponentsInChildren<Pickupable>();
        foreach (Pickupable _pickupable in pickupables) _pickupable.Load(gameInstance);

        obstaclesContainer.Load(gameInstance);
        boostSpawner.Load(pickupablesRoot);

        triggerCollider.enabled = true;

        foreach(GameObject _staticRoot in staticRoots)
        {
            StartCoroutine(LateCombine(_staticRoot));
        }
    }

    public void ActiveObstacles() => obstaclesContainer.ActiveObstacles();

    private void OnEnterEndGameState()
    {
        obstaclesContainer.DisableObstacles();
    }

    private IEnumerator LateCombine(GameObject staticRoot)
    {
        yield return null;
        StaticBatchingUtility.Combine(staticRoot);
    }


    private void OnTriggerExit(Collider collider)
    {
        if (collider.name != "Player") return;
        if (createNewTiles) outOfTrigger?.Invoke(this, destroyOnTrigger);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name != "Player") return;
        ActiveObstacles();
    }

    private void OnEnable()
    {
        enterEndGameState += OnEnterEndGameState;
    }

    private void OnDisable()
    {
        enterEndGameState -= OnEnterEndGameState;
    }
}

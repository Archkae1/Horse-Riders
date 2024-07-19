using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObstaclesContainer), typeof(BoostsContainer), typeof(PickupablesContainer))]
public class MapTile : MonoBehaviour
{
    [SerializeField] private List<GameObject> staticRoots;
    private BoxCollider triggerCollider;
    private bool createNewTiles;

    private ObstaclesContainer obstaclesContainer;
    private BoostsContainer boostsContainer;
    private PickupablesContainer pickupablesContainer;

    public ObstaclesContainer getObstaclesContainer => obstaclesContainer;
    public bool setCreateNewTiles { set { createNewTiles = value; } }
    public BoxCollider getTriggerCollider { get { return triggerCollider; } }

    public static Action<MapTile> outOfTrigger;
    public static Action enterEndGameState;

    public void Load(GameInstance gameInstance)
    {
        LoadComponents(gameInstance);

        foreach(GameObject _staticRoot in staticRoots)
        {
            StaticBatchingUtility.Combine(_staticRoot);
        }
    }

    public void EnableMapTile()
    {
        obstaclesContainer.ResetObstacles();
        pickupablesContainer.EnablePickupables();
        boostsContainer.TrySpawnBoosts();
        triggerCollider.enabled = true;
        createNewTiles = true;
    }

    private void LoadComponents(GameInstance gameInstance)
    {
        obstaclesContainer = GetComponent<ObstaclesContainer>();
        boostsContainer = GetComponent<BoostsContainer>();
        pickupablesContainer = GetComponent<PickupablesContainer>();
        triggerCollider = GetComponent<BoxCollider>();
        pickupablesContainer.Load(gameInstance);
        obstaclesContainer.Load(gameInstance);
        boostsContainer.Load();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.name != "Player") return;
        if (createNewTiles) outOfTrigger?.Invoke(this);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name != "Player") return;
        obstaclesContainer.ActiveObstacles();
    }
}

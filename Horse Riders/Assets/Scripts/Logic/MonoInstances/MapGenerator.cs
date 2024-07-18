using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Transform mapParent;
    [SerializeField] private List<MapTile> mapTilesPrefabs, startMapTile;
    private List<MapTile> mapTilesOnScene = new List<MapTile>();
    private GameInstance gameInstance;

    public void Load(GameInstance gameInstance)
    {
        this.gameInstance = gameInstance;
        ClearMap();
        GenerateMap();
    }

    public void ClearMap()
    {
        for (int i = 0; i < mapTilesOnScene.Count; i++)
        {
            if (startMapTile.Contains(mapTilesOnScene[i])) continue;
            mapTilesOnScene[i].setCreateNewTiles = false;
            Destroy(mapTilesOnScene[i].gameObject);
        }
        for (int i = 0; i < mapTilesOnScene.Count; i++) mapTilesOnScene.Remove(mapTilesOnScene[i]);
        mapTilesOnScene.Clear();
    }

    private void GenerateStartMap()
    {
        foreach (MapTile _mapTile in startMapTile)
        {
            mapTilesOnScene.Add(_mapTile);
            _mapTile.gameObject.SetActive(true);
            _mapTile.Load(gameInstance);
        }
    }

    private void ReleaseOldMapTile(MapTile mapTile, bool destroy)
    {
        mapTilesOnScene.Remove(mapTile);
        if (destroy) Destroy(mapTile.gameObject);
        else mapTile.gameObject.SetActive(false);
    }

    private void InsertMapTileInScene(MapTile mapTile)
    {
        Transform _lastGroundTransform = mapTilesOnScene[mapTilesOnScene.Count - 1].transform;
        float _lastGroundHalfSizeZ = mapTilesOnScene[mapTilesOnScene.Count - 1].getTriggerCollider.size.z / 2;
        float _thisGroundHalfSizeZ = mapTile.getTriggerCollider.size.z / 2;
        mapTile.transform.position = new Vector3(_lastGroundTransform.position.x, 0f, _lastGroundTransform.position.z + _lastGroundHalfSizeZ + _thisGroundHalfSizeZ);

        mapTilesOnScene.Add(mapTile);
        mapTile.Load(gameInstance);
    }

    private void GenerateNewMapTile()
    {
        var _mapTile = Instantiate(mapTilesPrefabs[Random.Range(0, mapTilesPrefabs.Count)], mapParent);
        InsertMapTileInScene(_mapTile);
    }

    private void GenerateMap()
    {
        GenerateStartMap();
        for (int i = 0; i < 3; i++) GenerateNewMapTile();
    }

    private void OnOutOfTrigger(MapTile mapTile, bool destroy)
    {

        GenerateNewMapTile();
        ReleaseOldMapTile(mapTile, destroy);
    }

    private void OnEnable()
    {   
        MapTile.outOfTrigger += OnOutOfTrigger;
    }

    private void OnDisable()
    {
        MapTile.outOfTrigger -= OnOutOfTrigger;
    }
}

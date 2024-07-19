using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Transform mapRoot;
    [SerializeField] private List<MapTile> mapTilesPrefabs, startMapTile;
    private List<MapTile> mapTilesOnScene = new List<MapTile>();
    private CustomPool<MapTile> pool;

    public void Load(GameInstance gameInstance)
    {
        if (pool != null) pool.ReleaseAll();
        else 
        {
            pool = new CustomPool<MapTile>(mapTilesPrefabs, mapRoot);
            foreach (MapTile _mapTile in pool.getObjects) _mapTile.Load(gameInstance);
            foreach (MapTile _mapTile in startMapTile) _mapTile.Load(gameInstance);
        }
    }

    public void ClearMap()
    {
        for (int i = 0; i < mapTilesOnScene.Count; i++)
        {
            if (startMapTile.Contains(mapTilesOnScene[i])) continue;
            mapTilesOnScene[i].setCreateNewTiles = false;
            pool.Release(mapTilesOnScene[i]);
        }
        for (int i = 0; i < mapTilesOnScene.Count; i++) mapTilesOnScene.Remove(mapTilesOnScene[i]);
        mapTilesOnScene.Clear();
    }

    public void GenerateMap()
    {
        GenerateStartMap();
        for (int i = 0; i < 3; i++) GenerateNewMapTile();
    }

    public void GenerateNewMapTile()
    {
        MapTile _mapTile = pool.Get();
        if (_mapTile) InsertMapTileInScene(_mapTile);
    }

    public void ReleaseOldMapTile(MapTile mapTile)
    {
        mapTilesOnScene.Remove(mapTile);
        mapTile.gameObject.SetActive(false);
    }

    public void DisableObstacles()
    {
        foreach (MapTile _mapTile in mapTilesOnScene)
        {
            _mapTile.getObstaclesContainer.DisableObstacles();
        }
    }

    private void GenerateStartMap()
    {
        foreach (MapTile _mapTile in startMapTile)
        {
            mapTilesOnScene.Add(_mapTile);
            _mapTile.EnableMapTile();
            _mapTile.gameObject.SetActive(true);
        }
    }

    private void InsertMapTileInScene(MapTile mapTile)
    {
        Transform _lastGroundTransform = mapTilesOnScene[mapTilesOnScene.Count - 1].transform;
        float _lastGroundHalfSizeZ = mapTilesOnScene[mapTilesOnScene.Count - 1].getTriggerCollider.size.z / 2;
        float _thisGroundHalfSizeZ = mapTile.getTriggerCollider.size.z / 2;
        mapTile.transform.position = new Vector3(_lastGroundTransform.position.x, 0f, _lastGroundTransform.position.z + _lastGroundHalfSizeZ + _thisGroundHalfSizeZ);

        mapTilesOnScene.Add(mapTile);
        mapTile.EnableMapTile();
    }
}

using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Transform mapParent;
    [SerializeField] private List<MapTile> mapTilesPrefabs, startMapTile;
    private List<MapTile> mapTilesOnScene = new List<MapTile>();

    public void OnEnterLoadGameState()
    {
        LoadStartMap();
        GenerateMap();
    }

    public void ClearMap()
    {
        for (int i = 0; i < mapTilesOnScene.Count; i++)
        {
            if (startMapTile.Contains(mapTilesOnScene[i]))
            {
                mapTilesOnScene.Remove(mapTilesOnScene[i]);
                i -= 1;
                continue;
            }
            mapTilesOnScene[i].setCreateNewTiles = false;
            Destroy(mapTilesOnScene[i].gameObject);
        }
        mapTilesOnScene.Clear();
    }

    private void LoadStartMap()
    {
        foreach (MapTile _mapTile in startMapTile)
        {
            mapTilesOnScene.Add(_mapTile);
            _mapTile.gameObject.SetActive(true);
            _mapTile.LoadMapTile();
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
        if (mapTilesOnScene.Count > 0)
        {
            Transform _lastGroundTransform = mapTilesOnScene[mapTilesOnScene.Count - 1].transform;
            float _lastGroundHalfSizeZ = mapTilesOnScene[mapTilesOnScene.Count - 1].getTriggerCollider.size.z / 2;
            float _thisGroundHalfSizeZ = mapTile.getTriggerCollider.size.z / 2;
            mapTile.transform.position = new Vector3(_lastGroundTransform.position.x, 0f, _lastGroundTransform.position.z + _lastGroundHalfSizeZ + _thisGroundHalfSizeZ);
        }

        mapTilesOnScene.Add(mapTile);
        mapTile.LoadMapTile();
    }

    private void GenerateNewMapTile()
    {
        var _mapTile = Instantiate(mapTilesPrefabs[Random.Range(0, mapTilesPrefabs.Count)], mapParent);
        InsertMapTileInScene(_mapTile);
    }

    private void GenerateMap()
    {
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

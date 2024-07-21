using System.Collections;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private MapGenerator mapGenerator;
    [SerializeField] private PlayableLines playableLines;

    public PlayableLines getPlayableLines => playableLines;

    public void Load(GameInstance gameInstance)
    {
        LoadComponents(gameInstance);
        mapGenerator.ClearMap();
        mapGenerator.GenerateMap();
    }

    public void LoadComponents(GameInstance gameInstance)
    {
        playableLines.Load();
        mapGenerator.Load(gameInstance);
    }

    public void OnEnterEndGameState()
    {
        mapGenerator.DisableObstacles();
    }

    private void OnOutOfTrigger(MapTile mapTile)
    {
        StartCoroutine(LateGenerateMap(mapTile));
    }

    private IEnumerator LateGenerateMap(MapTile mapTile)
    {
        yield return new WaitForSeconds(1f);
        mapGenerator.GenerateNewMapTile();
        mapGenerator.ReleaseOldMapTile(mapTile);
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

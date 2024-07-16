using System;
using System.Collections;
using UnityEngine;

public abstract class Boost : MonoBehaviour
{
    [SerializeField] private int spawnChance;
    [SerializeField] private int boostTime;
        
    public int getSpawnChance => spawnChance;
    public int getBoostTime => boostTime;

    public static Action<Type> boostStarted, boostEnded;
    public static Action allBoostEnd;

    public void SpawnBoost() => gameObject.SetActive(true);

    private void StartCoroutineOnPlayer(PlayerBoosts playerBoosts, Type thisType, Player player)
    {
        playerBoosts.StartCoroutine(thisType, player.StartCoroutine(StartBoost(playerBoosts)));
    }

    private void OnEndCoroutine(PlayerBoosts playerBoosts) => playerBoosts.StopCoroutine(GetType());

    private void OnPlayerTriggerBoost(Player player)
    {
        PlayerBoosts playerBoosts = player.getPlayerBoosts;
        Type _thisType = GetType(); 
        if (playerBoosts.getCoroutines[_thisType] == null) StartCoroutineOnPlayer(playerBoosts, _thisType, player);
        else
        {
            player.StopCoroutine(playerBoosts.getCoroutines[_thisType]);
            StartCoroutineOnPlayer(playerBoosts, _thisType, player);
        }
    }

    private IEnumerator StartBoost(PlayerBoosts playerBoosts)
    {
        boostStarted?.Invoke(GetType());
        yield return new WaitForSeconds(getBoostTime);
        boostEnded?.Invoke(GetType());
        OnEndCoroutine(playerBoosts);
    }

    private void OnEnable()
    {
        Player.playerTriggerBoost += OnPlayerTriggerBoost;
    }

    private void OnDisable()
    {
        Player.playerTriggerBoost -= OnPlayerTriggerBoost;
    }
}

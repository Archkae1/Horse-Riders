using System;
using System.Collections;
using UnityEngine;

public abstract class Boost : Pickupable
{
    [SerializeField] private int spawnChance;
    [SerializeField] private int boostTime;
        
    public int getSpawnChance => spawnChance;
    public int getBoostTime => boostTime;

    public static Action<Type> boostStarted, boostEnded;
    public static Action allBoostEnd;

    public override void LoadComponents(GameInstance gameInstance) { }

    public override void OnPickup(Player player)
    {
        EnableBoost(player);
        player.getPlayerSounds.PlayBoostSound();
    }

    public void SpawnBoost() => gameObject.SetActive(true);

    private void StartCoroutineOnPlayer(PlayerBoosts playerBoosts, Type thisType, Player player)
    {
        playerBoosts.SetDictCoroutine(thisType, player.StartCoroutine(StartBoost(playerBoosts)));
    }

    private void RemoveCoroutineFromDict(PlayerBoosts playerBoosts) => playerBoosts.RemoveDictCoroutine(GetType());

    private void EnableBoost(Player player)
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
        RemoveCoroutineFromDict(playerBoosts);
    }
}

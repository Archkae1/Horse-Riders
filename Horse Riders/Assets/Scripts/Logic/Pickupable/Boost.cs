using System;
using System.Collections;
using UnityEngine;

public abstract class Boost : Pickupable
{
    [SerializeField] private int spawnChance;
    [SerializeField] private int boostTime;
        
    public int getSpawnChance => spawnChance;
    public int getBoostTime => boostTime;

    public static Action<Type, int> boostStart;
    public static Action<Type> boostEnd;
    public static Action allBoostEnd;

    public override void LoadComponents(GameInstance gameInstance) { }

    public override void OnPickup(Player player)
    {
        EnableBoost(player);
        player.getPlayerSounds.PlayBoostSound();
    }

    private void StartCoroutineOnPlayer(PlayerBoosts playerBoosts, Type thisType, Player player)
    {
        playerBoosts.SetDictCoroutine(thisType, player.StartCoroutine(StartBoost(playerBoosts)));
    }

    private void RemoveCoroutineFromDict(PlayerBoosts playerBoosts) => playerBoosts.RemoveDictCoroutine(GetType());

    private void EnableBoost(Player player)
    {
        PlayerBoosts playerBoosts = player.getPlayerBoosts;
        Type _thisType = GetType(); 
        if (playerBoosts.getCoroutines[_thisType] != null)
            player.StopCoroutine(playerBoosts.getCoroutines[_thisType]);
        StartCoroutineOnPlayer(playerBoosts, _thisType, player);
    }

    private IEnumerator StartBoost(PlayerBoosts playerBoosts)
    {
        boostStart?.Invoke(GetType(), boostTime);
        yield return new WaitForSeconds(boostTime);
        boostEnd?.Invoke(GetType());
        RemoveCoroutineFromDict(playerBoosts);
    }
}

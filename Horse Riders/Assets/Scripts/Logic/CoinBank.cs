using UnityEngine;

public class CoinBank : MonoBehaviour
{
    private int coins;
    private int bankCoins;

    [SerializeField] private CoinBankPanel inGameCoinBankUI;
    [SerializeField] private CoinBankPanel maxCoinBankUI;

    public void Load()
    {
        inGameCoinBankUI.LoadCoinBankUI();
        if (PlayerPrefs.HasKey("BankCoins")) bankCoins = PlayerPrefs.GetInt("BankCoins");
        coins = 0;
        maxCoinBankUI.ChangeCoinsText(bankCoins);
    }

    public void OnEnterEndGameState()
    {
        bankCoins += coins;
        PlayerPrefs.SetInt("BankCoins", bankCoins);
        PlayerPrefs.Save();
    }

    public void AddCoin()
    {
        coins++;
        inGameCoinBankUI.ChangeCoinsText(coins);
    }
}

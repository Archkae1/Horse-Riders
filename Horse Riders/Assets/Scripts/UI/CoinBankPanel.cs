using TMPro;
using UnityEngine;

public class CoinBankPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;

    public void LoadCoinBankUI()
    {
        coinsText.text = "0";
    }

    public void ChangeCoinsText(int coins)
    {
        coinsText.text = coins.ToString();
    }
}

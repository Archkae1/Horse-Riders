public class Coin : Pickupable
{
    private CoinBank coinBank;

    public override void LoadComponents(GameInstance gameInstance)
    {
        coinBank =  gameInstance.getCoinBank;
    }

    public override void OnPickup(Player player)
    {
        coinBank.AddCoin();
        player.getPlayerSounds.PlayCoinSound();
    }
}

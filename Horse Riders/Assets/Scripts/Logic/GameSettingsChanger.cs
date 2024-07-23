using UnityEngine;
using Zenject;

public class GameSettingsChanger : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    private float basePlayerSpeed;
    private float baseTumbleweedSpeed;

    [Inject] private Score score;
    private GameInstance gameInstance;

    public void Load(GameInstance gameInstance)
    {
        this.gameInstance = gameInstance;
        gameSettings.playerSpeed = 5.8f;
        gameSettings.tumbleweedSpeed = 4f;
        basePlayerSpeed = gameSettings.playerSpeed;
        baseTumbleweedSpeed = gameSettings.tumbleweedSpeed;
    }

    private void Update()
    {
        if (gameInstance.getTypeOfCurrentStateGSM == typeof(LoadGameState))
        {
            gameSettings.playerSpeed = basePlayerSpeed;
            gameSettings.tumbleweedSpeed = baseTumbleweedSpeed;
        }

        float _additionSpeed;
        if (score.getScore > 900000) _additionSpeed = 3f;
        else _additionSpeed = score.getScore / 300000f;

        gameSettings.playerSpeed = basePlayerSpeed + _additionSpeed;
        gameSettings.tumbleweedSpeed = baseTumbleweedSpeed + _additionSpeed;
    }

    private void OnDisable()
    {
        gameSettings.playerSpeed = basePlayerSpeed;
        gameSettings.tumbleweedSpeed = baseTumbleweedSpeed;
    }
}

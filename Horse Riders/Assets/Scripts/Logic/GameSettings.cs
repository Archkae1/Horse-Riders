using UnityEngine;

[CreateAssetMenu(fileName = "New Game Settings", menuName = "ScriptableObjects/Game Settings", order = -1)]
public class GameSettings : ScriptableObject
{
    public float playerSpeed;
    public float tumbleweedSpeed;
}

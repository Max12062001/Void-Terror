using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/GameConstants", order = 1)]
public class GameConstants : ScriptableObject
{
    [Header("Player Movement")]
    public float jumpHeight = 7f;
    public float gravity = 10f;

  
}

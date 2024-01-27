using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log($"Player index is {playerInput.playerIndex}");
    }
}

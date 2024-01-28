using UnityEngine;

public class PlayerConfiguration : MonoBehaviour
{
    public int amountOfPlayers;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetAmountOfPlayers(int players)
    {
        amountOfPlayers = players;
    }
}

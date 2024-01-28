using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas canvasGO;
    public DrawController drawController;
    public List<Color> playerColors;
    int _playerIndex = 0;
    private List<Player> _players = new List<Player>();
    private List<Vector2> _positions = new List<Vector2> { new Vector2(-8, 4), new Vector2(8, 4), new Vector2(-8, -4), new Vector2(-8, -4), };

    public void AddPlayer(Player player)
    {
        player.transform.localScale = Vector3.one;
        Vector3 newPos = _positions[_playerIndex];
        newPos.z = 0;
        player.transform.position = newPos;
        player.SetColor(playerColors[_playerIndex]);
        _players.Add(player);
        _playerIndex++;
    }

    public void Draw(Vector2Int position)
    {
        drawController.AddPointToList(position);
    }

    public void ActivatePlayer()
    {
        foreach (Player player in _players)
        {
            player.ActivatePlayer();
        }
    }
}

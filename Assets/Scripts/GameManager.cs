using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxAmountOfPlayers = 2;
    public int timeToStartRound = 10;
    public int timeToEndRound = 5;
    public Canvas canvasGO;
    public DrawController drawController;
    public List<Color> playerColors;
    public AudioSource tickingAudio;
    
    private int _playerIndex = 0;
    private List<Player> _players = new List<Player>();
    private List<Vector2> _positions = new List<Vector2> { new Vector2(-8, 4), new Vector2(8, 4), new Vector2(-8, -4), new Vector2(-8, -4), };
    private ImageManager _imageManager;
    private Timer _timer;
    private UIManager _uIManager;
    private PlayerConfiguration _playerConfiguration;
    private bool _gameStarted;
    private AudioSource _persistentMusic;

    private void Awake()
    {
        _imageManager = FindObjectOfType<ImageManager>();
        _playerConfiguration = FindObjectOfType<PlayerConfiguration>();
        _timer = FindObjectOfType<Timer>();
        _uIManager = FindObjectOfType<UIManager>();
        _persistentMusic = FindObjectOfType<PersistentMusic>().GetComponent<AudioSource>();
    }

    public void StartRound()
    {
        StartCoroutine(StartSequence());
    }

    public void AddPlayer(Player player)
    {
        if (_gameStarted)
        {
            return;
        }
        player.transform.localScale = Vector3.one;
        Vector3 newPos = _positions[_playerIndex];
        newPos.z = 0;
        player.transform.position = newPos;
        player.SetColor(playerColors[_playerIndex]);
        _players.Add(player);
        _playerIndex++;

        int playerCount = _playerConfiguration == null ? maxAmountOfPlayers : _playerConfiguration.amountOfPlayers;
        if (_playerIndex >= playerCount)
        {
            _uIManager.ShowStart();
        }
    }

    public void Draw(Vector2Int position)
    {
        drawController.AddPointToList(position);
    }

    public void ActivatePlayer(bool status)
    {
        foreach (Player player in _players)
        {
            player.ActivatePlayer(status);
        }
    }

    private IEnumerator StartSequence()
    {
        yield return _imageManager.SelectImage();
        yield return _timer.CountDown(timeToStartRound);
        _persistentMusic.Stop();
        tickingAudio.Play();
        yield return _imageManager.Fade(0, () => ActivatePlayer(true));
        yield return _timer.SliderTimer();
        yield return _timer.CountDown(timeToEndRound, () => ActivatePlayer(false));
        tickingAudio.Stop();
        _persistentMusic.Play();
        yield return _imageManager.Fade(1, () => _uIManager.ShowEndPanel());
        _gameStarted = true;
    }
}

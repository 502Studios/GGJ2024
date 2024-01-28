using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float damping = 2f;
    public LineRenderer prefab;
    private GameManager _gameManager;
    private Vector2 _velocity;
    private Vector2 _currentDirection;
    private bool _isPainting;
    private LineRenderer _lineRenderer;
    private List<Vector3> _currentPoints;
    private SpriteRenderer _spriteRenderer;
    private bool _canMove;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.AddPlayer(this);
    }

    public void ActivatePlayer()
    {
        _canMove = true;
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log($"Player index is {playerInput.playerIndex}");
    }

    public void OnHorizontalMovement(CallbackContext context)
    {
        _currentDirection = context.ReadValue<Vector2>();
    }

    public void SetColor(Color col)
    {
        _spriteRenderer.color = col;
    }

    public void OnPaint(CallbackContext context)
    {
        if (context.performed)
        {
            _isPainting = true;
        }
        if (context.canceled)
        {
            _isPainting = false;
        }
        if (_isPainting)
        {
            _lineRenderer = Instantiate(prefab);
            _lineRenderer.startColor = _spriteRenderer.color;
            _lineRenderer.endColor = _spriteRenderer.color;
            _lineRenderer.positionCount = 0;
            _currentPoints = new List<Vector3>();
        }
    }

    private void Update()
    {
        if (!_canMove)
        {
            return;
        }
        if (_currentDirection.sqrMagnitude > 0)
        {
            _velocity = Vector2.Lerp(_velocity, _currentDirection.normalized * movementSpeed, Time.deltaTime * damping);
            transform.position += new Vector3(_velocity.x, _velocity.y) * Time.deltaTime;
        } else {
            _velocity = Vector3.zero;
        }
        Debug.Log($"Player is painting {_isPainting}");
        if (_isPainting)
        {
            _currentPoints.Add(transform.position);
            _lineRenderer.positionCount = _currentPoints.Count;
            _lineRenderer.SetPositions(_currentPoints.ToArray());
        }
    }
}

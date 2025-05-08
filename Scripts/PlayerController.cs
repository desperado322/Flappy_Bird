using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IContrallable
{

    [SerializeField] private float _jumpHeigth;

    public static event Action AddScore;
    public static event Action OnGameOver;

    private Rigidbody2D _rigidbody;

    private float _timer = 0f;
    private int _countJumps = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!GameOver.IsGameStopped)
        {
            _timer += Time.deltaTime;

            if (_timer > 1.5f)
            {
                _rigidbody.gravityScale = 3;
            }
            if (_timer > 0.5f)
            {
                _countJumps = 0;
            }
        }

    }
    private void OnEnable()
    {
        Menu.OnMenu += OnMenuActivate;
        Menu.OffMenu += OnMenuDisactivate;
    }

    private void OnDisable()
    {
        Menu.OnMenu -= OnMenuActivate;
        Menu.OffMenu -= OnMenuDisactivate;
    }
    private void OnMenuActivate()
    {
        _rigidbody.Sleep();
    }

    private void OnMenuDisactivate()
    {
        _rigidbody.WakeUp();
    }

    public void Jump()
    {
        _countJumps++;
        _rigidbody.linearVelocity = Vector2.up * (_jumpHeigth + _countJumps * 1.5f);
        _timer = 0f;
        _rigidbody.gravityScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddScore?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            OnGameOver?.Invoke();
        }
    }
}
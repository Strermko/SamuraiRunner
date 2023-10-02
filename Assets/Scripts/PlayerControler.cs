using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 5f;
    [SerializeField] private float _fallMultiplier = 1.5f;
    [SerializeField] private float _lowJumpMultiplier = 1f;

    private PlayerState _playerState;
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;

    [Header("Events")]
    public UnityEvent OnPlayerDeath;

    void Start()
    {
        _playerState = PlayerState.Runing;

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _playerState == PlayerState.Runing)
        {
            Jump();
        }
        
        if(_rigidbody2D.velocity.y < 0) _rigidbody2D.velocity += Vector2.up * (Physics2D.gravity.y * _fallMultiplier * Time.deltaTime);
        else if(_rigidbody2D.velocity.y > 0 && !Input.GetKey(KeyCode.Mouse0)) _rigidbody2D.velocity += Vector2.up * (Physics2D.gravity.y * _lowJumpMultiplier * Time.deltaTime);

        UpdatePlayerState();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Obstacle"))
            OnPlayerDeath?.Invoke();
    }

    void UpdatePlayerState()
    {
        if (IsGrounded() && _playerState == PlayerState.InAir)
            _playerState = PlayerState.Runing;
        else if (!IsGrounded() && _playerState == PlayerState.Runing)
            _playerState = PlayerState.InAir;
    }

    void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        var groundLayer = LayerMask.GetMask("Ground");
        var bounds = _boxCollider2D.bounds;
        var raycastHit2D = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down,
            0.1f, groundLayer);
        return raycastHit2D.collider;
    }

}
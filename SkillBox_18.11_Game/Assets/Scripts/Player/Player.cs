using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Controller _inputs;
    private Rigidbody2D _rb;
    private Vector3 _movementVector;

    [SerializeField] private PlayerShoot _playerShoot;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private CapsuleCollider2D _capsuleCollider;
    

    private void OnEnable()
    {
        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
    }

    private void Awake()
    {
        _inputs = new Controller(); 
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _inputs.Main.Jump.performed += context => Jump(); // прижочек
        _inputs.Main.Shoot.performed += context => Shoot(); // стрельба
    }

    private void Shoot()
    {
        _playerShoot.ShootBullet();
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        _movementVector = _inputs.Main.Move.ReadValue<Vector2>();

        Move();
        Flip();

        bool check = Physics2D.OverlapArea(transform.position, new Vector2(transform.position.x, transform.position.y - 1f), _layerMask); // Проверка на косание земли
        Debug.Log(check);
    }

    /// <summary>
    /// Передвижение игрока
    /// </summary>
    private void Move()
    {
        _rb.AddForce(_movementVector * _speed, ForceMode2D.Force);
        _playerAnimation.StateMove(_movementVector.x);
        
    }

    /// <summary>
    /// Метод для поворота игрока
    /// </summary>
    private void Flip()
    {
        if(_movementVector.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        if( _movementVector.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}

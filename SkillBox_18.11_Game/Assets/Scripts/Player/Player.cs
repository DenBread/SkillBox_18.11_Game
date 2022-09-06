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
    private bool _isGround;
    [HideInInspector] public bool isLadder;

    [SerializeField] private PlayerShoot _playerShoot;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _speed; // скорость передвижения по горизонтали
    [SerializeField] private float _powerUp; // скорость перемещение по летницы
    [SerializeField] private float _jumpPower; // сила прыжка

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
        if (_isGround)
        {
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        _isGround = Physics2D.OverlapArea(transform.position, new Vector2(transform.position.x, transform.position.y - 1f), _layerMask); // Проверка на косание земли
        

        _movementVector = _inputs.Main.Move.ReadValue<Vector2>();

        Move();
        Flip();

        if (isLadder)
        {
            MoveLadder();
        }

        
    }

    /// <summary>
    /// Передвижение игрока по горизонтальной оси
    /// </summary>
    private void Move()
    {
        Vector3 vec = new Vector3(_movementVector.x, 0f);
        _rb.AddForce(vec * _speed, ForceMode2D.Force);
        _playerAnimation.StateMove(_movementVector.x);
        
    }

    /// <summary>
    /// Передвижения по лестницы
    /// </summary>
    public void MoveLadder()
    {
        Vector3 vec = new Vector3(0, _movementVector.y);
        _rb.AddForce(vec * _powerUp, ForceMode2D.Force);
    }

    /// <summary>
    /// Метод для поворота игрока
    /// </summary>
    private void Flip()
    {
        if(_movementVector.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if( _movementVector.x > 0)
        {
            transform.localScale = Vector3.one;
        }
    }
}

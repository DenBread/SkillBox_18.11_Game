using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    [Header("For Petrolling")]
    [SerializeField] private float _moveSpeed;
    private float moveDirection = -1f;
    private bool facingLeft = true;
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private Transform _wallChackPoint;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _circleRadius;
    private bool _checkingGround;
    private bool _checkingWall;

    [Header("For JumpAttacting")]
    [SerializeField] private float _jumpHeight;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Vector2 _boxSize;
    private bool _isGrounded;

    [Header("For SeeingPlayer")]
    [SerializeField] private Vector2 _lineOfSite;
    [SerializeField] private LayerMask _playerLayer;
    private bool _canSeePlayer;

    [Header("Other")]
    private Rigidbody2D _enemyRB;
    [SerializeField] float _timeWaitJump;
    private float _saveTime;

    private void Start()
    {
        _enemyRB = GetComponent<Rigidbody2D>();
        _saveTime = _timeWaitJump;
    }


    private void FixedUpdate()
    {
        _checkingGround = Physics2D.OverlapCircle(_groundCheckPoint.position, _circleRadius, _groundLayer);
        _checkingWall = Physics2D.OverlapCircle(_wallChackPoint.position, _circleRadius, _groundLayer);
        _isGrounded = Physics2D.OverlapBox(_groundCheck.position, _boxSize,0, _groundLayer);
        _canSeePlayer = Physics2D.OverlapBox(transform.position, _lineOfSite, 0, _playerLayer);
        
        if(!_canSeePlayer && _isGrounded)
        {
            Petrolling();
        }
        else if (_canSeePlayer)
        {
            FlipTowardsPlayer();


            if(_timeWaitJump> 0)
            {
                _timeWaitJump -= Time.deltaTime;
            }
            else
            {
                JumpAttack();
                _timeWaitJump = _saveTime;
            }
        }
    }

    private void Petrolling()
    {
        if(!_checkingGround || _checkingWall)
        {
            if (facingLeft)
            {
                Flip();
            }
            else if (!facingLeft)
            {
                Flip();
            }
        }
        _enemyRB.velocity = new Vector2(_moveSpeed * moveDirection, _enemyRB.velocity.y);
    }

    private void JumpAttack()
    {
        float distanceFromPlayer = _player.position.x - transform.position.x;

        if (_isGrounded)
        {
            _enemyRB.AddForce(new Vector2(distanceFromPlayer, _jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void FlipTowardsPlayer()
    {
        float playerPosition = _player.position.x - transform.position.x;
        if(playerPosition < 0 && !facingLeft)
        {
            Flip();
        }
        else if(playerPosition > 0 && facingLeft)
        {
            Flip();
        }
    }

    private void Flip()
    {
        moveDirection *= -1;
        facingLeft = !facingLeft;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_groundCheckPoint.position, _circleRadius);
        Gizmos.DrawSphere(_wallChackPoint.position, _circleRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(_groundCheck.position, _boxSize);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _lineOfSite);
    }
}

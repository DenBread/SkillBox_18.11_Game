using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _powerJump;
    private Transform _playerPoint;


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
    [SerializeField] float _jumpHeight;

    [Header("Other")]
    private Rigidbody2D _enemyRB;

    private void Start()
    {
        _enemyRB = GetComponent<Rigidbody2D>();
        }


    private void FixedUpdate()
    {
        _checkingGround = Physics2D.OverlapCircle(_groundCheckPoint.position, _circleRadius, _groundLayer);
        _checkingWall = Physics2D.OverlapCircle(_wallChackPoint.position, _circleRadius, _groundLayer);
        Petrolling();
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
    }
}

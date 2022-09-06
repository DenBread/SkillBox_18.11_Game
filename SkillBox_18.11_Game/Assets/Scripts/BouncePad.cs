using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private float _power;
    private Animator _anim;
    private static readonly int StartPad = Animator.StringToHash("BouncePad");
    private static readonly int BouncePadStop = Animator.StringToHash("BouncePadStop");

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            _anim.CrossFade(StartPad, 0, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * _power, ForceMode2D.Impulse);
        }
    }
}

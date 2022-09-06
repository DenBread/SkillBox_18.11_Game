using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float _impulse; // ������� �� �������, ����� ������������ ���
    [SerializeField] private �hanges�olor �hanges�olor; // ����� ��� ��������� ������� �� ������
    private Health health;

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Sprikes>() != null)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.TransformVector(Vector2.up) * _impulse, ForceMode2D.Impulse);
            StartCoroutine(�hanges�olor.Color());

            gameObject.GetComponent<Health>().DepriveHealth();
        }
    }
}

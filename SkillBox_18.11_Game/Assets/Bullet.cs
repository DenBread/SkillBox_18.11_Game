using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _vfxExplosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(_vfxExplosion, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        Destroy(gameObject);
    }
}

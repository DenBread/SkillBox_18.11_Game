using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSlime : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _vfxDieSlime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() || collision.gameObject.GetComponent<Player>())
        {
            _health--;

            if(_health <= 0)
            {
                Instantiate(_vfxDieSlime, transform.position, Quaternion.Euler(-90, 0, 0));
                Destroy(gameObject);
            }
        }
    }
}

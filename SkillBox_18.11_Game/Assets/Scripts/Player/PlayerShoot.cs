using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _pointBullet;

    [SerializeField] private float _power;

    public void ShootBullet()
    {
        GameObject bullet = Instantiate(_bullet, _pointBullet.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * _power, ForceMode2D.Impulse);
    }
}

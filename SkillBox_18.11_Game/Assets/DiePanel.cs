using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePanel : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GameObject _diePanel;
    [SerializeField] private Player _player;

    private void Update()
    {
        ChackHealth();
    }

    private void ChackHealth()
    {
        if(_health.HealthObj == 0)
        {
            _diePanel.SetActive(true);
            _player.GetComponent<Rigidbody2D>().freezeRotation = false;
            _player.enabled = false;
        }
    }
}

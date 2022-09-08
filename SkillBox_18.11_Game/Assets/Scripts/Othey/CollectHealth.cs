using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHealth : MonoBehaviour
{
    [SerializeField] private Health health;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<HealthTrigger>() != null)
        {
            health.AddHealth();
            Destroy(collision.gameObject);
        }
    }
}

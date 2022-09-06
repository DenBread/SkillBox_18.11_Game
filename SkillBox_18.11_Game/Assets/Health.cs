using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth; // максимальное кол-во хп
    [SerializeField] private HealthBar _healthBar; // спрайты хп в меню игры 
    public bool IsStun { get; private set; }
    public int HealthObj { get; private set; }

    private void Start()
    {
        HealthObj = _maxHealth;
    }

    public void DepriveHealth()
    {
        if(HealthObj > 0 && !IsStun)
        {
            HealthObj--;
            StartCoroutine(Stun());
            _healthBar.DepriveImageHealth();
        }
    }

    public void AddHealth()
    {
        if(HealthObj < _maxHealth && !IsStun)
        {
            HealthObj++;
            _healthBar.AddImageHealth();
        }
    }

    IEnumerator Stun()
    {
        IsStun = true;
        yield return new WaitForSeconds(2f);
        IsStun = false;
    }
}

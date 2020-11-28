using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerStats : MonoBehaviour
{
    [SerializeField] float Health = 100.0f;
    [SerializeField] bool IsAlive = true;
    public Transform HPBar;

    void CheckAlive()
    {
        if(Health <= 0)
        {
            Health = 0;
            IsAlive = false;
        }
    }

    void ApplyDamage(float damage)
    {
        Health -= damage;
        CheckAlive();
        UpdateHPBar();
    }

    void UpdateHPBar()
    {
        Vector2 sc = HPBar.localScale;
        sc.x = Health / 100.0f;
        HPBar.localScale = sc;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            ApplyDamage(15.0f);
        }

        if (collision.tag == "Bullet")
        {
            ApplyDamage(5.0f);
        }
    }
}

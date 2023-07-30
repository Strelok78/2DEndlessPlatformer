using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] LayerMask _waterLayer;
    [SerializeField] LayerMask _enemyLayer; 
    [SerializeField] private int _maxHealth;

    private int _health;

    public event UnityAction<string> OnActionDone;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _waterLayer)
            Death();

        if (collision.gameObject.layer == _enemyLayer)
            RecieveDamage();
    }

    private void Attack()
    {
        OnActionDone?.Invoke("Attack");
    }

    private void Defence()
    {
        OnActionDone?.Invoke("Defence");
    }

    private void RecieveDamage()
    {
        OnActionDone?.Invoke("RecieveDamage");
    }

    private void Death()
    {
        OnActionDone?.Invoke("Death");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] LayerMask _waterLayer;
    [SerializeField] LayerMask _enemyLayer;

    private void Attack()
    {

    }

    private void Defence()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == _waterLayer)
            Death();

        if(collision.gameObject.layer == _enemyLayer)
            Damage();
    }

    private void Damage()
    {

    }

    private void Death()
    {

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayermMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2d;

    public event UnityAction<float> OnPlayerMoving;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            Move(Vector2.left);
        if (Input.GetKey(KeyCode.D))
            Move(Vector2.right);
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Move(Vector2 direction)
    {
        _spriteRenderer.flipX = direction.x < 0;
        transform.Translate(direction * _speed * Time.deltaTime);
        OnPlayerMoving?.Invoke(direction.x);
    }

    private void Jump()
    {
        _rigidbody2d.velocity = Vector2.up * _jumpForce;
    }
}

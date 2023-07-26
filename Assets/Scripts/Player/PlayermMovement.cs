using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayermMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    [SerializeField] LayerMask _layerMask;

    private CapsuleCollider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2d;

    public event UnityAction<string> OnMovementMade;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            Move(Vector2.left);

        if (Input.GetKey(KeyCode.D))
            Move(Vector2.right);

        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) && IsGrounded())
            OnMovementMade?.Invoke("Idle");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            Jump();

        if (!IsGrounded())
            OnMovementMade?.Invoke("Jump");
    }

    private void Move(Vector2 direction)
    {
        if (IsGrounded())
            OnMovementMade?.Invoke("Run");

        _spriteRenderer.flipX = direction.x < 0;
        _collider.offset = _spriteRenderer.flipX ? new Vector2 (0.1f, 0) : new Vector2(-0.1f, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void Jump()
    {
        _rigidbody2d.velocity = Vector2.up * _jumpForce;
        OnMovementMade?.Invoke("Jump");
    }

    private bool IsGrounded()
    {
        float angle = 0f;
        float rayLength = 0.05f;
        float boxCastSizeY = 0.1f;
        float boxCastSizeX = _collider.size.x;

        Vector2 feetCenter = new Vector2(_collider.bounds.min.x + _collider.size.x / 2, _collider.bounds.min.y);
        Vector2 feetBox = new Vector2(boxCastSizeX, boxCastSizeY);
        RaycastHit2D groundRay = Physics2D.BoxCast(feetCenter, feetBox, angle, Vector2.down, rayLength, _layerMask);

        return groundRay.collider != null;
    }
}
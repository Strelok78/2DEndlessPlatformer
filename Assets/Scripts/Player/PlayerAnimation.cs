using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayermMovement _playerMovement;

    private Animator _animator;
    private Animation _animation;
    private string _previousAnimationName;

    private void OnEnable()
    {
        _playerMovement.OnMovementMade += MakeAnimation;
    }

    private void OnDisable()
    {
        _playerMovement.OnMovementMade -= MakeAnimation;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animation = GetComponent<Animation>();
    }

    private void MakeAnimation(string animationName)
    {
        _animator.Play(animationName);
    }
}
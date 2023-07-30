using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Character))]
public class CharacterAnimation : MonoBehaviour
{
    private PlayermMovement _playerMovement;
    private Character _character;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _character = GetComponent<Character>();
        TryGetComponent(out _playerMovement);
    }

    private void OnEnable()
    {
        _playerMovement.OnMovementMade += MakeAnimation;
        _character.OnActionDone += MakeAnimation;
    }

    private void OnDisable()
    {
        _playerMovement.OnMovementMade -= MakeAnimation;
        _character.OnActionDone -= MakeAnimation;
    }

    private void MakeAnimation(string animationName)
    {
        foreach (AnimationClip clip in _animator.runtimeAnimatorController.animationClips)
            if (clip.name == animationName)
                _animator.Play(animationName);
    }
}
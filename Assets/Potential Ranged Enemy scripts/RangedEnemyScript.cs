using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyScript : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rigidbody;

    private PlayerAwarenessController _playerAwarenessController;

    private Vector2 _targetDirection;

    public Transform Target;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        
    }

    private void FixedUpdate() // Executes multiple times a second to check for player awareness
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();

    }

    private void UpdateTargetDirection() // Checks the enemy is aware of the player
    {
        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget() // Manages rotation of the enemy
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

       //_rigidbody.SetRotation(rotation);
    }

    private void SetVelocity() // sets enemy move speed
    {
        if (_targetDirection == Vector2.zero)
        {
            _rigidbody.linearVelocity = Vector2.zero;
        }
        else
        {
            _rigidbody.linearVelocity = transform.up * _speed;
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private float _obstacleCheckCircleRadius;
    
    [SerializeField]
    private float _obstacleCheckDistance;

    [SerializeField]
    private LayerMask _obstacleLayerMask;
    

    private Rigidbody2D _rigidbody;

    private PlayerAwarenessController _playerAwarenessController;

    private Vector2 _targetDirection;

    public Transform Target;

    private RaycastHit2D[] _obstacleCollisions;

    private float _obstacleAvoidanceCooldown;

    private Vector2 _obstacleAvoidanceTargetDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _obstacleCollisions = new RaycastHit2D[10];
        
    }

    private void FixedUpdate() // Executes multiple times a second to check for player awareness
    {
        HandleObstacles();
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

        _rigidbody.SetRotation(rotation);
    }

    private void HandleObstacles()
    {
        _obstacleAvoidanceCooldown -= Time.deltaTime;
        var contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(_obstacleLayerMask);

        int numberOfCollisions = Physics2D.CircleCast(transform.position,_obstacleCheckCircleRadius,transform.up,contactFilter,_obstacleCollisions,_obstacleCheckDistance);

        for (int index = 0; index < numberOfCollisions; index++)
        {
            var obstacleCollision = _obstacleCollisions[index];

            if (obstacleCollision.collider.gameObject == gameObject)
            {
                continue;
            }

            if (_obstacleAvoidanceCooldown <= 0)
            {
                _obstacleAvoidanceTargetDirection = obstacleCollision.normal;
                _obstacleAvoidanceCooldown = 0.5f;
            }

            var targetRotation = Quaternion.LookRotation(transform.forward, _obstacleAvoidanceTargetDirection);
            var rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,_rotationSpeed * Time.deltaTime);

            _targetDirection = rotation * Vector2.up;
            break;
        }
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



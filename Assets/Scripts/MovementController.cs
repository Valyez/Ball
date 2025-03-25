using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private const float MIN_VALUE = 0.05f;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _horizontalForce;

    private Rigidbody _rigidbody;
    private bool _isJumpKeyDown;
    private float _horizontalRaw;
    private float _verticalRaw;
    private bool _isOnGround;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _horizontalRaw = Input.GetAxisRaw("Horizontal");
        _verticalRaw = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.Space))
        {
            _isJumpKeyDown = true;
        }
    }
    
    private void FixedUpdate()
    {
        if (_isJumpKeyDown && _isOnGround)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumpKeyDown = false;
        }

        if (Math.Abs(_horizontalRaw) > MIN_VALUE && _isOnGround)
        {
            _rigidbody.AddForce(Vector3.right * (_horizontalRaw * _horizontalForce));
        }

        if (Math.Abs(_verticalRaw) > MIN_VALUE && _isOnGround)
        {
            _rigidbody.AddForce(Vector3.forward * (_verticalRaw * _horizontalForce));
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        Floor floor = other.collider.GetComponent<Floor>();

        if (floor != null)
        {
            _isOnGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        Floor floor = other.collider.GetComponent<Floor>();

        if (floor != null)
        {
            _isOnGround = false;
        }
    }
}
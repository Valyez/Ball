using System;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _zOffset;

    private void LateUpdate()
    {
        Vector3 position = _targetTransform.position;
        transform.position = new Vector3(position.x, _yOffset, position.z + _zOffset);
    }
}

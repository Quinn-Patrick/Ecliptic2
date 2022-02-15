using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicEntity : MonoBehaviour
{
    private Vector3 _velocity;
    private Vector3 _acceleration;
    [SerializeField] private Transform _transform;
    private void Awake()
    {
        _transform = gameObject.transform;
    }
    private void Update()
    {
        _velocity += _acceleration;
        _transform.position += _velocity;
        _acceleration = Vector3.zero;
    }
    public void UpdateAcceleration(Vector3 DeltaA)
    {
        _acceleration += DeltaA;
    }
}

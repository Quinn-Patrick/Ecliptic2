using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicEntity : MonoBehaviour
{
    protected Vector3 _velocity;
    protected Vector3 _acceleration;
    protected Rigidbody2D _body;
    protected Transform _transform;
    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _transform = gameObject.transform;
    }
    private void Update()
    {
        if (_body == null) return;
        _body.AddForce(_acceleration);
        _acceleration = Vector3.zero;
    }
    public void UpdateAcceleration(Vector3 DeltaA)
    {
        _acceleration += DeltaA;
    }
}

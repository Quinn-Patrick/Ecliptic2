using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Rigidbody2D _body;
    [SerializeField] private IInputReader _input;
    [SerializeField] private float _rotationSpeed;
    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _input = gameObject.GetComponent<IInputReader>();
    }
    void FixedUpdate()
    {
        if (_input == null) return;
        _body.MoveRotation(transform.eulerAngles.z + (_input.GetRotation() * Time.fixedDeltaTime * _rotationSpeed));
    }
}

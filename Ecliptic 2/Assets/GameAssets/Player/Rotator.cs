using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Transform _tranform;
    [SerializeField] private IInputReader _input;
    [SerializeField] private float _rotationSpeed;
    private void Awake()
    {
        _tranform = gameObject.transform;
        _input = gameObject.GetComponent<IInputReader>();
    }
    void FixedUpdate()
    {
        if (_input == null) return;
        _tranform.eulerAngles += new Vector3(0f, 0f, _input.GetRotation() * Time.fixedDeltaTime * _rotationSpeed);
    }
}

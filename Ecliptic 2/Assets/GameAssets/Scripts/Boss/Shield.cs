using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using Unity.Mathematics;

namespace EclipticTwo.Boss
{
    public class Shield : MonoBehaviour
    {
        private float _angularSpeed;
        private Rigidbody2D _body;
        [SerializeField] private float _targetAngularSpeed;
        [SerializeField] private float _angularAcceleration;

        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }
        public void SetTargetAngularSpeed(float targetAngularSpeed)
        {
            _targetAngularSpeed = targetAngularSpeed;
        }

        private void FixedUpdate()
        {
            float angularSpeedDifference = _targetAngularSpeed - _angularSpeed;
            _angularSpeed += (_angularAcceleration * math.sign(angularSpeedDifference) * Time.fixedDeltaTime);

            if (_body == null) return;
            _body.angularVelocity = _angularSpeed;
        }
    }
}
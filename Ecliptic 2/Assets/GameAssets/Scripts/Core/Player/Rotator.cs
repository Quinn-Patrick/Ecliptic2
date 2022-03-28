using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class Rotator : MonoBehaviour
    {
        private Rigidbody2D _body;
        [SerializeField] private IInputReader _input;
        [SerializeField] private float _rotationSpeed;
        private bool _canReverse = true;
        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            _input = gameObject.GetComponent<IInputReader>();
        }
        void FixedUpdate()
        {
            if (_input == null) return;
            Rotate();
            Reverse();
        }

        private void Rotate()
        {
            if (Mathf.Abs(_input.GetRotation()) < 0.001) return;
            _body.MoveRotation(transform.eulerAngles.z + (_input.GetRotation() * Time.fixedDeltaTime * _rotationSpeed));
        }
        private void Reverse()
        {
            if(_input.GetThrust() < -0.5f)
            {
                if (_canReverse)
                {
                    StartCoroutine(DoReverse());
                }
                _canReverse = false;
            }
            else
            {
                _canReverse = true;
            }
        }

        private IEnumerator DoReverse()
        {
            for(int i = 0; i < 180; i += 6)
            {
                _body.MoveRotation(transform.eulerAngles.z + 6f);
                yield return null;
            }
        }
    }
}
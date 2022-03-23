using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Guns
{
    public class ShotParticles : MonoBehaviour
    {
        [SerializeField] private Shot _source;
        [SerializeField] private ParticleSystem _system;
        ParticleSystem.ShapeModule _systemShape;

        private float _lastRadius;

        private void Awake()
        {
            _systemShape = _system.shape;
        }
        private void Update()
        {
            _lastRadius = _systemShape.radius;
            _systemShape.radius = _source.GetRange() * 10;

            if(Mathf.Abs(_lastRadius - _systemShape.radius) > 0.1)
            {
                _system.Pause();
                _system.Stop();
                _system.Play();
            }
        }
    }
}

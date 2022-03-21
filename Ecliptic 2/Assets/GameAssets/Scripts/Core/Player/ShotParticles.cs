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

        private void Awake()
        {
            _systemShape = _system.shape;
        }
        private void Update()
        {
            _systemShape.radius = _source.GetRange() * 10;
        }
    }
}

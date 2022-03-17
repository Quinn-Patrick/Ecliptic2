using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class ExhaustParticles : MonoBehaviour
    {
        [SerializeField] private Transform _sourceTransform;
        [SerializeField] private ParticleSystem _system;
        ParticleSystem.ShapeModule _systemShape;

        private void Awake()
        {
            _systemShape = _system.shape;
        }
        private void Update()
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
            _systemShape.rotation = new Vector3(_sourceTransform.eulerAngles.z, 0, 0);
        }
    }
}
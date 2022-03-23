using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class MassiveBody : MonoBehaviour
    {
        [SerializeField] private float _mass;
        private float _radius;

        public delegate void DestructionHandler(MassiveBody planet);
        public event DestructionHandler Destroyed;
        private void Awake()
        {
            _radius = this.transform.localScale.x;
        }
        private void Start()
        {
            if (!Game.planets.Contains(this))
            {
                Game.planets.Add(this);
            }
        }
        private void OnDestroy()
        {
            Game.planets.Remove(this);
            Destroyed?.Invoke(this);
        }
        public float GetMass()
        {
            return _mass;
        }
        public float GetRadius()
        {
            return _radius;
        }
    }
}


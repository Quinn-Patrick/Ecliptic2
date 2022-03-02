using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;


namespace EclipticTwo.Trajectory
{
    public class TrajectoryPoint : MonoBehaviour
    {
        public Transform _transform;
        public Vector3 velocity;
        public Vector3 acceleration;
        public SpriteRenderer rend;
        private void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
            _transform = gameObject.transform;
        }
        
    }
}
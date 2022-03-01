using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using static Unity.Mathematics.math;

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
        private void FixedUpdate()
        {
            transform.localScale = new Vector2(velocity.magnitude * 16f, 1f);
            float angle = Vector3.Angle(velocity, new Vector3(1f, 0f, 0f)) * sign(velocity.y);
            transform.eulerAngles = new Vector3(0f, 0f, angle);
        }
    }
}
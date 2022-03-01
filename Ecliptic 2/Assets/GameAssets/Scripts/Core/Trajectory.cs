using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Trajectory
{
    public class Trajectory : MonoBehaviour
    {
        [SerializeField] TrajectoryPoint _pointTemplate;
        List<TrajectoryPoint> _points = new List<TrajectoryPoint>();
        [SerializeField] private int _length;
        [SerializeField] private float _timestep;
        [SerializeField] private GravitatingBody _player;
        private void Awake()
        {
            for (int i = 0; i < _length; i++)
            {
                _points.Add(GameObject.Instantiate(_pointTemplate));
            }
        }
        private void FixedUpdate()
        {
            if (_player.GetBody() == null) return;
            CalculatePointVelocity();
        }

        private void CalculatePointVelocity()
        {
            TrajectoryPoint lastPoint = _points[0];
            lastPoint.velocity = _player.GetBody().velocity;
            lastPoint.transform.position = _player.transform.position;
            int index = -1;
            foreach (TrajectoryPoint p in _points)
            {

                index++;
                if (index == 0) continue;
                p.velocity = lastPoint.velocity;
                p.transform.position = lastPoint.transform.position;
                p.acceleration = Vector3.zero;
                foreach (MassiveBody m in Game.planets)
                {
                    if (IsTooClose(p.transform.position, m))
                    {
                        p.velocity = Vector3.zero;
                        p.acceleration = Vector3.zero;
                        break;
                    }
                    p.acceleration += Game.ComputeInstantAcceleration(p.transform.position, m.transform.position, m.GetMass(), 1) * 0.005f;
                }
                p.velocity += p.acceleration * _timestep;
                p.transform.position += p.velocity * _timestep;
                lastPoint = p;
            }
        }

        private bool IsTooClose(Vector3 position, MassiveBody m)
        {
            return Vector3.Distance(position, m.transform.position) < m.GetRadius() / 2;
        }
    }
}
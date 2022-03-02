using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

namespace EclipticTwo.Core
{
    public class Game : MonoBehaviour
    {
        public static List<MassiveBody> planets = new List<MassiveBody>();
        public static List<GravitatingBody> gravitators = new List<GravitatingBody>();

        private static Game Instance = null;
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }

            planets = new List<MassiveBody>();
            gravitators = new List<GravitatingBody>();
        }
        public static List<MassiveBody> GetPlanets()
        {
            return planets;
        }
        private void FixedUpdate()
        {
            foreach (GravitatingBody g in gravitators)
            {
                AccelerateGravitator(g);
            }
        }

        public static float FindEntityAngle(Vector3 Point_1, Vector3 Point_2)
        {
            float angle = atan2(Point_2.y - Point_1.y, Point_2.x - Point_1.x);
            return Mathf.Rad2Deg * angle;
        }
        public static Vector3 ComputeTotalAcceleration(GravitatingBody g)
        {
            Vector3 acceleration = Vector3.zero;
            foreach (MassiveBody m in planets)
            {
                acceleration += ComputeAcceleration(g, m);
            }
            return acceleration;
        }
        public static void AccelerateGravitator(GravitatingBody g)
        {
            Vector3 acceleration = ComputeTotalAcceleration(g);
            g.UpdateAcceleration(acceleration);
        }
        private static Vector3 ComputeAcceleration(GravitatingBody g, MassiveBody m)
        {
            return ComputeInstantAcceleration(g.transform.position, m.transform.position, m.GetMass(), g.GetBody().mass) * Time.fixedDeltaTime;
        }
        public static Vector3 ComputeInstantAcceleration(Vector3 positionG, Vector3 positionM, float mass, float gMass)
        {
            float distance = Vector3.Distance(positionG, positionM);
            
            float mag = -mass * gMass / (distance * distance);

            if (abs(mag) < 2)
            {
                return Vector3.zero;
            }

            float angle = FindEntityAngle(positionM, positionG);
            float forcex = mag * cos(Mathf.Deg2Rad * angle);
            float forcey = mag * sin(Mathf.Deg2Rad * angle);
            return new Vector3(forcex, forcey, 0f);
        }
    }
}

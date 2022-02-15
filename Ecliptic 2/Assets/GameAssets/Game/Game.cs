using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

public class Game : MonoBehaviour
{
    public static List<MassiveBody> planets = new List<MassiveBody>();
    public static List<GravitatingBody> gravitators = new List<GravitatingBody>();
    public static List<MassiveBody> GetPlanets()
    {
        return planets;
    }
    private void FixedUpdate()
    {
        foreach(GravitatingBody g in gravitators)
        {
            foreach(MassiveBody m in planets)
            {
                if(g != m)
                {
                    float distance = Vector3.Distance(g.transform.position, m.transform.position);
                    float angle = FindEntityAngle(m.transform.position, g.transform.position);
                    float mag = -m.GetMass() / (distance * distance);
                    float forcex = mag * cos(Mathf.Deg2Rad * angle);
                    float forcey = mag * sin(Mathf.Deg2Rad * angle);
                    g.UpdateAcceleration(new Vector3(forcex, forcey, 0f) * Time.fixedDeltaTime);
                }
            }
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), $"Angle: {FindEntityAngle(planets[0].transform.position, gravitators[0].transform.position)}");
    }

    public static float FindEntityAngle(Vector3 Point_1, Vector3 Point_2)
    {
        float angle = Mathf.Atan2(Point_2.y - Point_1.y, Point_2.x - Point_1.x);
        return Mathf.Rad2Deg * angle;
    }
}

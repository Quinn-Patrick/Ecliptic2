using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Missions
{
    [CreateAssetMenu(fileName = "New Orbit Mission", menuName = "Missions/Orbit Mission")]
    public class OrbitMissionData : ScriptableObject
    {
        public string missionName;
        public string description;
        public bool isRequired;

        public string orbitID;
    }

}
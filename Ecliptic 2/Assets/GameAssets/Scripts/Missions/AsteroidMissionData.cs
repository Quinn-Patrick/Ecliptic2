using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Missions
{
    [CreateAssetMenu(fileName = "New Asteroid Mission", menuName = "Missions/Asteroid Mission")]
    public class AsteroidMissionData : ScriptableObject
    {
        public string missionName;
        public string description;
        public bool isRequired;

        public string asteroidID;
    }
}
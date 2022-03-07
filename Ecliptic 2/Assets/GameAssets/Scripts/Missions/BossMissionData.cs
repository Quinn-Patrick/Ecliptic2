using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Missions
{
    [CreateAssetMenu(fileName = "New Boss Mission", menuName = "Missions/Boss Mission")]
    public class BossMissionData : ScriptableObject
    {
        public string missionName;
        public string description;
        public bool isRequired;
        public int baseScore;
        public int baseTimeBonus;
        public int bonusTime;

        public string planetID;
    }
}
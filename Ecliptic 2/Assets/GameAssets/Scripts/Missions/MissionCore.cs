using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Missions
{
    public class MissionCore : MonoBehaviour
    {
        public static MissionCore Instance;
        public List<IMission> Missions = new List<IMission>();

        public delegate void MissionGainHandler(IMission mission);
        public event MissionGainHandler MissionGained;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }

        public void GainMission(IMission mission)
        {
            if (!Missions.Contains(mission))
            {
                Missions.Add(mission);
                MissionGained?.Invoke(mission);
            }
        }
        public void RemoveMission(IMission mission)
        {
            Missions.Remove(mission);
        }
        public bool AllMissionsClear()
        {
            bool allClear = true;
            foreach(IMission m in Missions)
            {
                if(m.IsRequired() && !m.IsComplete())
                {
                    allClear = false;
                }
            }
            return allClear;
        }
    }
}
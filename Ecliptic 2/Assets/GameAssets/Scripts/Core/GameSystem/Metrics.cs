using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.TimingAndScoring;

namespace EclipticTwo.Core
{
    public class Metrics : MonoBehaviour
    {
        public int MissionsCompleted { get; set; }
        public int Crashes { get; set; }
        public float FuelUsed { get; set; }
        public float TotalDamage { get; set; }
        public float TopSpeed { get; set; }
        public float DistanceTraveled { get; set; }

        public static Metrics Instance;
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

        public string[] GetFormattedMetrics()
        {
            return new string[] { Score.Instance.GetFormattedScore(),
                Timer.Instance.GetElapsedTimeFormatted(),
                $"{MissionsCompleted} / 16",
                $"{Crashes}",
                $"{FuelUsed:0000.00}",
                $"{TotalDamage:0000000.00}",
                $"{TopSpeed:000.00}",
                $"{DistanceTraveled:00000}"};
        }

        public void ResetMetrics()
        {
            MissionsCompleted = 0;
            Crashes = 0;
            FuelUsed = 0;
            TotalDamage = 0;
            TopSpeed = 0;
            DistanceTraveled = 0;
        }
    }
}
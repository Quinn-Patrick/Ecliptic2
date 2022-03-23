using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.TimingAndScoring;
using EclipticTwo.Core;

namespace EclipticTwo.Missions
{
    public abstract class Mission : MonoBehaviour, IMission
    {
        protected MissionType _type;
        protected string _name;
        protected string _description;
        protected bool _isRequired;
        protected bool _isComplete;

        protected int _baseScore;
        protected int _baseTimeBonus;
        protected float _bonusTime;

        public delegate void CompletionHandler();
        public event CompletionHandler MissionCompleted;
        protected void Start()
        {
            AcquireMission();
        }
        public void AcquireMission()
        {
            MissionCore.Instance.GainMission(this);
        }

        public void CompleteMission()
        {
            _isComplete = true;
            Metrics.Instance.MissionsCompleted++;
            Score.Instance.GainScoreTimeBonus(_baseScore, _baseTimeBonus, _bonusTime);
            MissionCompleted?.Invoke();
        }

        public string GetMissionDescription()
        {
            return _description;
        }

        public string GetMissionName()
        {
            return _name;
        }

        public abstract string GetMissionProgress();

        public MissionType GetMissionType()
        {
            return _type;
        }

        public bool IsComplete()
        {
            return _isComplete;
        }

        public bool IsRequired()
        {
            return _isRequired;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.TimingAndScoring;
using EclipticTwo.Core;

namespace EclipticTwo.Missions
{
    public class BossMission : MonoBehaviour, IMission
    {
        private MissionType _type = MissionType.Boss;
        private List<MassiveBody> _bossList = new List<MassiveBody>();
        private int _bossesDestroyed = 0;
        private int _totalBosses;
        private string _name;
        private string _description;
        private bool _isRequired;
        private bool _isComplete;
        [SerializeField] private BossMissionData _data;

        private int _baseScore;
        private int _baseTimeBonus;
        private float _bonusTime;
        private void Start()
        {
            AcquireMission();
            _name = _data.missionName;
            _description = _data.description;
            _isRequired = _data.isRequired;

            _baseScore = _data.baseScore;
            _baseTimeBonus = _data.baseTimeBonus;
            _bonusTime = _data.bonusTime;

            foreach (GameObject b in GameObject.FindGameObjectsWithTag(_data.planetID))
            {
                MassiveBody boss = b.GetComponent<MassiveBody>();
                if (boss == null) continue;
                _bossList.Add(boss);
            }

            foreach (MassiveBody b in _bossList)
            {
                b.Destroyed += (b) => DestroyBoss(b);
            }
            _totalBosses = _bossList.Count;
        }
        private void Update()
        {
            if (!_isComplete)
            {
                if (_bossList.Count == 0)
                {
                    CompleteMission();
                }
            }
        }
        public void AcquireMission()
        {
            MissionCore.Instance.GainMission(this);
        }

        public void CompleteMission()
        {
            Metrics.Instance.MissionsCompleted++;
            _isComplete = true;
            foreach (MassiveBody b in _bossList)
            {
                b.Destroyed -= (b) => DestroyBoss(b);
            }
            Score.Instance.GainScoreTimeBonus(_baseScore, _baseTimeBonus, _bonusTime);
        }

        public string GetMissionDescription()
        {
            return _description;
        }

        public string GetMissionName()
        {
            return _name;
        }

        public string GetMissionProgress()
        {
            if (_isComplete) return $"{_name}: Complete!";
            return $"{_name}: {_totalBosses - _bossesDestroyed} Remaining";
        }

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
        private void DestroyBoss(MassiveBody boss)
        {
            _bossesDestroyed++;
            _bossList.Remove(boss);
            boss.Destroyed -= (boss) => DestroyBoss(boss);
        }
    }
}
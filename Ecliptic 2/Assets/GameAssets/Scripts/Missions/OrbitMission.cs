using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using EclipticTwo.TimingAndScoring;
using EclipticTwo.Rings;

namespace EclipticTwo.Missions
{
    public class OrbitMission : MonoBehaviour, IMission
    {
        [SerializeField] private OrbitMissionData _data;
        [SerializeField] private Player _player;

        private string _name;
        private string _description;
        private bool _isRequired;
        private int _ringsTarget;
        private int _ringsCleared;
        private bool _isComplete;
        private MissionType _type = MissionType.Orbit;
        private List<GoalRing> _rings = new List<GoalRing>();

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
            foreach (GameObject goalRingObject in GameObject.FindGameObjectsWithTag(_data.orbitID))
            {
                GoalRing ring = goalRingObject.GetComponent<GoalRing>();
                if (ring == null) continue;
                _rings.Add(ring);
                ring.Cleared += ClearRing;
            }
            _ringsTarget = _rings.Count;
            _player.Impacted += ResetMission;
        }
        public void AcquireMission()
        {
            MissionCore.Instance.GainMission(this);
        }
        private void Update()
        {
            if (!_isComplete)
            {
                if (_ringsCleared >= _ringsTarget)
                {
                    CompleteMission();
                }
            }
        }

        public void CompleteMission()
        {
            _isComplete = true;
            _player.Impacted -= ResetMission;
            foreach (GoalRing ring in _rings)
            {
                ring.gameObject.SetActive(false);
                ring.Cleared -= ClearRing;
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
            return $"{_name}: {_ringsCleared} / {_ringsTarget}";
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

        private void ClearRing(GoalRing ring)
        {
            _ringsCleared++;
        }
        private void ResetMission(Collision2D collision)
        {
            if (_isComplete) return;
            _ringsCleared = 0;
            foreach (GoalRing ring in _rings)
            {
                ring.UnClear();
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Missions
{
    public class OrbitMission : MonoBehaviour, IMission
    {
        [SerializeField] private OrbitMissionData _missionData;
        [SerializeField] private Player _player;

        private string _name;
        private string _description;
        private bool _isRequired;
        private int _ringsTarget;
        private int _ringsCleared;
        private bool _isComplete;
        private MissionType _type = MissionType.Orbit;
        private List<GoalRing> _rings = new List<GoalRing>();
        private void Start()
        {
            AcquireMission();
            _name = _missionData.missionName;
            _description = _missionData.description;
            _isRequired = _missionData.isRequired;
            foreach (GameObject goalRingObject in GameObject.FindGameObjectsWithTag(_missionData.orbitID))
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
                ring.Cleared -= ClearRing;
            }
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
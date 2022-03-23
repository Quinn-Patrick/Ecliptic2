using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using EclipticTwo.TimingAndScoring;
using EclipticTwo.Rings;

namespace EclipticTwo.Missions
{
    public class OrbitMission : Mission
    {
        [SerializeField] private OrbitMissionData _data;
        [SerializeField] private Player _player;
        private int _ringsTarget;
        private int _ringsCleared;
        private List<GoalRing> _rings = new List<GoalRing>();
        new private void Start()
        {
            base.Start();
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

        new public void CompleteMission()
        {
            base.CompleteMission();
            _player.Impacted -= ResetMission;
            foreach (GoalRing ring in _rings)
            {
                ring.gameObject.SetActive(false);
                ring.Cleared -= ClearRing;
            }
        }

        override public string GetMissionProgress()
        {
            if (_isComplete) return $"{_name}: Complete!";
            return $"{_name}: {_ringsCleared} / {_ringsTarget}";
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
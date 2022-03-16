using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.TimingAndScoring;
using EclipticTwo.Core;

namespace EclipticTwo.Missions
{
    public class BossMission : Mission
    {
        private List<MassiveBody> _bossList = new List<MassiveBody>();
        private int _bossesDestroyed = 0;
        private int _totalBosses;
        [SerializeField] private BossMissionData _data;
        new private void Start()
        {
            base.Start();
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

        new public void CompleteMission()
        {
            base.CompleteMission();
            foreach (MassiveBody b in _bossList)
            {
                b.Destroyed -= (b) => DestroyBoss(b);
            }
        }

        override public string GetMissionProgress()
        {
            if (_isComplete) return $"{_name}: Complete!";
            return $"{_name}: {_totalBosses - _bossesDestroyed} Remaining";
        }
        private void DestroyBoss(MassiveBody boss)
        {
            _bossesDestroyed++;
            _bossList.Remove(boss);
            boss.Destroyed -= (boss) => DestroyBoss(boss);
        }
    }
}
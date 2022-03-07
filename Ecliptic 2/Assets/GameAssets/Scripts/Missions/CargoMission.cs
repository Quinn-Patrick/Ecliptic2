using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using EclipticTwo.TimingAndScoring;
using EclipticTwo.Cargo;

namespace EclipticTwo.Missions
{
    public class CargoMission : MonoBehaviour, IMission
    {
        [SerializeField] private CargoMissionData _data;
        private string _name;
        private string _description;
        private bool _isRequired;
        private readonly List<CargoStation> _stations = new List<CargoStation>();
        private int _stationsComplete;
        private int _targetStations;
        private readonly MissionType _type = MissionType.Cargo;
        private bool _isComplete = false;

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
            foreach (GameObject cs in GameObject.FindGameObjectsWithTag(_data.cargoID))
            {
                CargoStation station = cs.GetComponent<CargoStation>();
                if (station == null) continue;
                _stations.Add(station);
                station.Complete += CompleteStation;
            }
            _targetStations = _stations.Count;
        }
        private void Update()
        {
            if (!_isComplete)
            {
                if (_stationsComplete >= _targetStations)
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
            _isComplete = true;
            foreach (CargoStation station in _stations)
            {
                station.Complete -= CompleteStation;
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
            return $"{_name}: {_stationsComplete} / {_targetStations}";
        }

        public MissionType GetMissionType()
        {
            return _type;
        }

        public bool IsRequired()
        {
            return _isRequired;
        }

        private void CompleteStation(CargoStation cs)
        {
            _stationsComplete++;
        }

        public bool IsComplete()
        {
            return _isComplete;
        }
    }
}
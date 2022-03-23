using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using EclipticTwo.TimingAndScoring;
using EclipticTwo.Cargo;

namespace EclipticTwo.Missions
{
    public class CargoMission : Mission
    {
        [SerializeField] private CargoMissionData _data;
        private readonly List<CargoStation> _stations = new List<CargoStation>();
        private int _stationsComplete;
        private int _targetStations;
        new private void Start()
        {
            base.Start();
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

        new public void CompleteMission()
        {
            base.CompleteMission();
            foreach (CargoStation station in _stations)
            {
                station.Complete -= CompleteStation;
            }
        }

        override public string GetMissionProgress()
        {
            if (_isComplete) return $"{_name}: Complete!";
            return $"{_name}: {_stationsComplete} / {_targetStations}";
        }

        private void CompleteStation(CargoStation cs)
        {
            _stationsComplete++;
        }
    }
}
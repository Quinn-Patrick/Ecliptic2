using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoMission : MonoBehaviour, IMission
{
    [SerializeField] private CargoMissionData _missionData;
    private string _name;
    private string _description;
    private bool _isRequired;
    private List<CargoStation> _stations = new List<CargoStation>();
    private int _stationsComplete;
    private int _targetStations;
    private MissionType _type = MissionType.Cargo;
    private bool _isComplete = false;
    private void Start()
    {
        _name = _missionData.name;
        _description = _missionData.description;
        _isRequired = _missionData.isRequired;
        foreach(GameObject cs in GameObject.FindGameObjectsWithTag(_missionData.cargoID))
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
            if(_stationsComplete >= _targetStations)
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
        foreach(CargoStation station in _stations)
        {
            station.Complete -= CompleteStation;
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
        return $"{_stationsComplete} / {_targetStations}";
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

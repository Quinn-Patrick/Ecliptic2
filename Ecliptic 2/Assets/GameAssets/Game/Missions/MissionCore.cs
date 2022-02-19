using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCore : MonoBehaviour
{
    public static MissionCore Instance;
    [SerializeField] private List<IMission> _missions;
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

    public void GainMission(IMission mission)
    {
        if (!_missions.Contains(mission))
        {
            _missions.Add(mission);
        }
    }
    public void RemoveMission(IMission mission)
    {
        _missions.Remove(mission);
    }
}

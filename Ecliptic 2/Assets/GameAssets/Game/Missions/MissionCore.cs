using System.Collections.Generic;
using UnityEngine;

public class MissionCore : MonoBehaviour
{
    public static MissionCore Instance;
    public List<IMission> Missions = new List<IMission>();

    public delegate void MissionGainHandler(IMission mission);
    public event MissionGainHandler missionGained;
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
        if (!Missions.Contains(mission))
        {
            Missions.Add(mission);
            missionGained?.Invoke(mission);
        }
    }
    public void RemoveMission(IMission mission)
    {
        Missions.Remove(mission);
    }
}

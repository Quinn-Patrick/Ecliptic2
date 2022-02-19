using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cargo Mission", menuName = "Missions/Cargo Mission")]
public class CargoMissionData : ScriptableObject
{
    public string missionName;
    public string description;
    public bool isRequired;

    public string cargoID;
}
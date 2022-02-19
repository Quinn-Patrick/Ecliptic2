using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMission
{
    public MissionType GetMissionType();
    public void CompleteMission();
    public void AcquireMission();
    public string GetMissionProgress();
    public string GetMissionName();
    public string GetMissionDescription();
    public bool IsRequired();
    public bool IsComplete();
}

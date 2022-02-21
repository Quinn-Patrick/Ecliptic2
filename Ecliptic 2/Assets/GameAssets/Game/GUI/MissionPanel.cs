using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _panelText;
    private IMission _mission;
    private void Update()
    {
        if (_mission == null) return;
        _panelText.text = _mission.GetMissionProgress();
    }
    public void SetMission(IMission mission)
    {
        _mission = mission;
    }
}

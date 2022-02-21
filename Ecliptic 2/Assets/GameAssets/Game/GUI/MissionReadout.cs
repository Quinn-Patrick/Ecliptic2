using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionReadout : MonoBehaviour
{
    [SerializeField] private GameObject _panelPrefab;
    [SerializeField] private Canvas _canvas;
    private int _missionCount = 0;
    private void Start()
    {
        MissionCore.Instance.missionGained += GainMission;
    }
    private void GainMission(IMission mission)
    {
        GameObject newPanel = Instantiate(_panelPrefab);
        MissionPanel newPanelComponent = newPanel.GetComponent<MissionPanel>();
        RectTransform panelTransform = newPanel.GetComponent<RectTransform>();
        if (panelTransform == null || newPanelComponent == null) return;
        _missionCount++;

        panelTransform.SetParent(_canvas.gameObject.transform);
        panelTransform.anchoredPosition = new Vector3(0f, -24f * _missionCount + 12f, 0f);

        newPanelComponent.SetMission(mission);
    }
}

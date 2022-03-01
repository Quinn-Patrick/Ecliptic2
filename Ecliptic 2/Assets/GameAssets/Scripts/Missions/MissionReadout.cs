using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EclipticTwo.Core;
using EclipticTwo.Missions;

namespace EclipticTwo.Gui
{
    public class MissionReadout : MonoBehaviour
    {
        [SerializeField] private GameObject _panelPrefab;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private float _panelThickness;
        private int _missionCount = 0;
        private void OnEnable()
        {
            MissionCore.Instance.MissionGained += GainMission;
        }
        private void OnDisable()
        {
            MissionCore.Instance.MissionGained -= GainMission;
        }
        private void GainMission(IMission mission)
        {
            GameObject newPanel = Instantiate(_panelPrefab);
            MissionPanel newPanelComponent = newPanel.GetComponent<MissionPanel>();
            RectTransform panelTransform = newPanel.GetComponent<RectTransform>();
            if (panelTransform == null || newPanelComponent == null) return;
            _missionCount++;

            panelTransform.SetParent(_canvas.gameObject.transform);
            panelTransform.anchoredPosition = new Vector3(0f, -_panelThickness * _missionCount + (_panelThickness), 0f);

            newPanelComponent.SetMission(mission);
        }
    }
}
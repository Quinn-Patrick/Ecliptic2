using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EclipticTwo.Missions;
using UnityEngine.UI;

namespace EclipticTwo.Gui
{
    public class MissionPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _panelText;
        [SerializeField] Image _extraImage;
        [SerializeField] Canvas _canvas;
        private IMission _mission;
        private void Update()
        {
            transform.localScale = _canvas.transform.localScale;
            if (_mission == null) return;
            _panelText.text = _mission.GetMissionProgress();
            if (!_mission.IsRequired())
            {
                _extraImage.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                _extraImage.color = new Color(1f, 1f, 1f, 0f);
            }
        }
        public void SetMission(IMission mission)
        {
            _mission = mission;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using EclipticTwo.Missions;

namespace EclipticTwo.Gui
{
    public class MissionDetailPanel : MonoBehaviour, IPauseScreenElement
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private int _index;
        [SerializeField] private Image _image;
        private void Update()
        {
            List<IMission> missionList = MissionCore.Instance.Missions;
            if (_index >= missionList.Count) return;
            _text.text = $"{missionList[_index].GetMissionProgress()}\n{missionList[_index].GetMissionDescription()}";
        }
        public void Hide()
        {
            _image.color = new Color(1, 1, 1, 0);
            _text.alpha = 0;
        }

        public void Show()
        {
            _image.color = new Color(1, 1, 1, 1);
            _text.alpha = 1;
        }
    }
}
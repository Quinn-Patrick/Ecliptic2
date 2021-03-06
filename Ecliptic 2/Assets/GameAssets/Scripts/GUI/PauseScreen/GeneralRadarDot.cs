using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Gui
{
    public class GeneralRadarDot : RadarElement
    {
        private RectTransform _map;
        private void Start()
        {
            GameObject radarObject = GameObject.FindWithTag("MapBackground");
            if (radarObject == null) return;
            _radar = radarObject.GetComponent<Radar>();
            _map = _radar.GetComponent<RectTransform>();
            if (_transform == null || _map == null || _radar == null) return;
            _transform.SetParent(_map);
            /*GameObject radarChildObject = GameObject.FindWithTag("GeneralRadarDots");
            RectTransform parent = radarChildObject.GetComponent<RectTransform>();
            if (parent == null) return;
            _transform.SetParent(parent);*/
        }
    }
}
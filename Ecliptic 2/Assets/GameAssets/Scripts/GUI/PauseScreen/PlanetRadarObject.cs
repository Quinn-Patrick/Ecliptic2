using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Gui
{
    public class PlanetRadarObject : RadarElement
    {
        private new void Update()
        {
            base.Update();
            if (_transform == null || _object == null) return;
            _transform.sizeDelta = new Vector2(_object.transform.localScale.x * _radar.Scale, _object.transform.localScale.y * _radar.Scale);
        }
    }
}
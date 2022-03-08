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
            _transform.sizeDelta = new Vector2(_object.transform.localScale.x * _radar.Scale * 1.7f, _object.transform.localScale.y * _radar.Scale * 1.7f);
        }
    }
}
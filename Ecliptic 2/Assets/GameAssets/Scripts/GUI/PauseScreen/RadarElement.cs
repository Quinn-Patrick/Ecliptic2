using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EclipticTwo.Gui
{
    public abstract class RadarElement : MonoBehaviour
    {
        [SerializeField] protected Radar _radar;
        [SerializeField] protected Transform _object;
        protected RectTransform _transform;

        protected void Awake()
        {
            _transform = GetComponent<RectTransform>();
            if (_transform == null) return;
        }

        protected void Update()
        {
            if (_transform == null) return;
            if (_object == null)
            {
                Destroy(this);
                return;
            }
            if (_object.gameObject.activeSelf && _object != null && _radar != null)
            {
                _transform.anchoredPosition = new Vector3((_object.position.x + _radar.Center.x) * _radar.Scale, (_object.position.y + _radar.Center.y) * _radar.Scale, 0f);
            }
            else
            {
                _transform.anchoredPosition = new Vector3(-999999, -999999, 0);
            }
        }
        public void SetObject(Transform obj)
        {
            _object = obj;
        }

        public void SetSize(float size)
        {
            _transform.sizeDelta = new Vector2(size, size);
        }
    }
}
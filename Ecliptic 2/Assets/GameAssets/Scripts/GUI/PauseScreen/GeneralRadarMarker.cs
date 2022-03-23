using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EclipticTwo.Gui
{
    public class GeneralRadarMarker : MonoBehaviour
    {
        [SerializeField] private GameObject _baseObject;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private float _size;
        private GameObject _tract;

        private void OnEnable()
        {
            if (_tract == null)
            {
                _tract = Instantiate(_baseObject);
            }
            Image renderer = _tract.GetComponent<Image>();
            RadarElement element = _tract.GetComponent<RadarElement>();
            if (renderer == null || element == null) return;
            renderer.sprite = _sprite;
            element.SetObject(transform);
            element.SetSize(_size);
        }
    }
}
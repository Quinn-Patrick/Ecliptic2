using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private DynamicEntity _player;
        private IInputReader _input;
        private void Awake()
        {
            _input = GetComponent<IInputReader>();
        }
        private void Update()
        {
            if (_player == null) return;
            float shake = ScreenShake.Instance.GetShake();
            transform.position = new Vector3(_player.transform.position.x + Random.Range(-shake, shake), _player.transform.position.y + Random.Range(-shake, shake), GetZoomLevel());
        }
        private float GetZoomLevel()
        {
            if (_input == null) return -14f;
            int zoomFactor;
            if (_input.GetZoom())
            {
                zoomFactor = 1;
            }
            else
            {
                zoomFactor = 0;
            }
            return -14 - (zoomFactor * 28);
        }
    }
}
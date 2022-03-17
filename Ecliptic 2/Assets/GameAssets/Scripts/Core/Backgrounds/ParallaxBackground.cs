using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Backgrounds
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private Vector2 _parallaxEffectMultiplier;
        [SerializeField] private bool _tileHorizontal;
        [SerializeField] private bool _tileVertical;
        [SerializeField] private Camera _camera;

        private Transform _cameraTransform;
        private Vector3 _lastCameraPosition;
        private float _textureUnitSizeX;
        private float _textureUnitSizeY;
        void Start()
        {
            _cameraTransform = _camera.transform;
            _lastCameraPosition = _cameraTransform.position;
            Sprite sprite = GetComponent<SpriteRenderer>().sprite;
            Texture2D texture = sprite.texture;
            _textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
            _textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
        }

        private void LateUpdate()
        {
            Vector3 deltaMovement = _cameraTransform.position - _lastCameraPosition;
            transform.position += new Vector3(deltaMovement.x * _parallaxEffectMultiplier.x, deltaMovement.y * _parallaxEffectMultiplier.y);
            _lastCameraPosition = _cameraTransform.position;

            if (_tileHorizontal)
            {
                if(Mathf.Abs(_cameraTransform.position.x - transform.position.x) >= _textureUnitSizeX)
                {
                    float offsetPostionX = (_cameraTransform.position.x - transform.position.x) % _textureUnitSizeX;
                    transform.position = new Vector3(_cameraTransform.position.x + offsetPostionX, transform.position.y);
                }
            }

            if (_tileVertical)
            {
                if (Mathf.Abs(_cameraTransform.position.y - transform.position.y) >= _textureUnitSizeY)
                {
                    float offsetPositionY = (_cameraTransform.position.y - transform.position.y) % _textureUnitSizeY;
                    transform.position = new Vector3(transform.position.x, _cameraTransform.position.y + offsetPositionY);
                }
            }
        }
    }
}
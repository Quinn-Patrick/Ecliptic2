using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Asteroids
{
    public class RandomAsteroidShape : MonoBehaviour
    {
        private SpriteRenderer _sprite;
        [SerializeField] private List<Sprite> _spriteList = new List<Sprite>();

        private void Start()
        {
            if (_sprite == null || _spriteList.Count == 0) return;

            _sprite.sprite = _spriteList[Random.Range(0, _spriteList.Count - 1)];
        }
    }
}
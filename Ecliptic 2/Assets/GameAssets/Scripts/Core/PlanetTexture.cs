using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class PlanetTexture : MonoBehaviour
    {
        [SerializeField] private Transform _planetSurface;
        [SerializeField] private SpriteRenderer _self;

        private void Start()
        {
            _self.size = new Vector2(_planetSurface.localScale.x, _planetSurface.localScale.y);
            _planetSurface.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
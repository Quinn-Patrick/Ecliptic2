using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EclipticTwo.Core;

namespace EclipticTwo.Cargo
{
    public class CargoStation : MonoBehaviour, ITriggerObject
    {
        [SerializeField] private List<CargoCollectible> _cargo = new List<CargoCollectible>();
        [SerializeField] private TextMeshPro _progressIndicator;
        private int _cargoCount = 0;
        private int _cargoTarget;
        private SpriteRenderer _sprite;

        public delegate void CompletionHandler(CargoStation cs);
        public event CompletionHandler Complete;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _cargoTarget = _cargo.Count;

            if (_sprite == null) return;
            foreach(CargoCollectible cc in _cargo)
            {
                SpriteRenderer sprite = cc.GetComponent<SpriteRenderer>();
                if (sprite == null) continue;
                sprite.color = _sprite.color;
            }
        }
        public void PlayerEnter(Player player)
        {
            CargoGrabber grabber = player.gameObject.GetComponent<CargoGrabber>();
            if (grabber == null) return;
            if (_cargo.Contains(grabber.GetCurrentCargo()))
            {
                grabber.UnloadCargo();
                _cargoCount++;
                if (_cargoCount >= _cargoTarget)
                {
                    Complete?.Invoke(this);
                }
            }
        }
        private void Update()
        {
            _progressIndicator.text = $"{_cargoCount} / {_cargoTarget}";
        }

        public void PlayerExit(Player player) { }

        public void PlayerStay(Player player) { }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class DeathZone : MonoBehaviour, ITriggerObject
    {
        private List<HealthSystem> _targetedSystems = new List<HealthSystem>();
        [SerializeField] private int _damage;
        [SerializeField] private float _damageFrequency;
        private float _time;
        public void PlayerEnter(Player player)
        {
            HealthSystem newHealthSystem = player.GetHealthSystem();
            if (newHealthSystem == null) return;
            Debug.Log($"Health system {newHealthSystem} added.");
            _targetedSystems.Add(newHealthSystem);
        }

        public void PlayerExit(Player player)
        {
            HealthSystem oldHealthSystem = player.GetHealthSystem();
            if (oldHealthSystem == null) return;
            _targetedSystems.Remove(oldHealthSystem);
            Debug.Log($"Health system {oldHealthSystem} removed.");
        }

        public void PlayerStay(Player player){}

        private void FixedUpdate()
        {
            _time += Time.fixedDeltaTime;
            if (_time >= _damageFrequency)
            {
                foreach (HealthSystem h in _targetedSystems)
                {
                    h.InflictFixedDamage(_damage);
                }
                _time = 0;
            }
        }
    }
}
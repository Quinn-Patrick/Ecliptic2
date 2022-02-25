using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using EclipticTwo.Cargo;

namespace EclipticTwo.Respawn
{
    public class RespawnManager : MonoBehaviour
    {
        [SerializeField] private CheckpointChecker _checker;
        [SerializeField] private Player _player;
        [SerializeField] private HealthSystem _health;
        [SerializeField] private Fuel _fuelTank;
        [SerializeField] private CargoGrabber _cargo;
        [SerializeField] private CargoRope _rope;
        [SerializeField] private IInputReader _input;
        private bool _isDead;
        private bool _canRespawn = true;
        private float _respawnTimer;
        [SerializeField] private float _respawnTime;

        private void Awake()
        {
            _health.Dead += KillPlayer;
            _input = gameObject.GetComponent<IInputReader>();
        }
        private void FixedUpdate()
        {
            if (_isDead)
            {
                _respawnTimer += Time.fixedDeltaTime;
            }
            RespawnInput();
            if (_respawnTimer > _respawnTime)
            {
                Respawn();
            }
            
        }

        private void RespawnInput()
        {
            if ( _input == null) return;
            if (_input.GetRetry())
            {
                if (_canRespawn)
                {
                    _canRespawn = false;
                    Respawn();
                    return;
                }
            }
            _canRespawn = true;
            
        }
        private void KillPlayer()
        {
            _isDead = true;
            if (_rope == null) return;
            _rope.gameObject.SetActive(false);
        }

        private void Respawn()
        {
            _player.transform.localScale = Vector2.one;
            _player.transform.position = _checker.GetCheckpointLocation();
            _player.transform.eulerAngles = new Vector3(0f, 0f, _checker.GetCheckpointRotation());
            _health.RestoreHealth(float.MaxValue);
            _fuelTank.RestoreFuel();
            _cargo.ReturnCargo();
            _respawnTimer = 0f;
            _isDead = false;

            Rigidbody2D playerBody = _player.GetComponent<Rigidbody2D>();
            if (playerBody == null) return;
            playerBody.velocity = Vector2.zero;
        }
    }
}
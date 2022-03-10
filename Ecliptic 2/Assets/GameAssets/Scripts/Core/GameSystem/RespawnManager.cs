using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using EclipticTwo.Cargo;
using EclipticTwo.TimingAndScoring;

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
        [SerializeField] private Rigidbody2D _body;

        [SerializeField] private float _respawnTime;

        private bool _isDead;
        private bool _canRespawn = true;
        private float _respawnTimer;
        
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
            _body.velocity = Vector2.zero;
            _player.gameObject.SetActive(false);

            if (_rope == null) return;
            _rope.gameObject.SetActive(false);
        }
        private void Respawn()
        {
            Score.Instance.ResetChain();
            _player.gameObject.SetActive(true);
            _respawnTimer = 0f;
            _isDead = false;
            ResetPlayerCharacteristics();
        }
        private void ResetPlayerCharacteristics()
        {
            _player.transform.localScale = Vector2.one;
            _player.transform.position = _checker.GetCheckpointLocation();
            _player.transform.eulerAngles = new Vector3(0f, 0f, _checker.GetCheckpointRotation());
            _health.RestoreHealth(float.MaxValue);
            _fuelTank.RestoreFuel();
            _cargo.ReturnCargo();
            _player.ZeroAcceleration();
            _body.velocity = Vector2.zero;
        }
    }
}
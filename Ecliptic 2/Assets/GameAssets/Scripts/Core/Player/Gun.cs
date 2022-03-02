using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Guns
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private DynamicEntity _owner;
        private IInputReader _input;
        private bool _canShoot;

        public delegate void ShotHandler();
        public event ShotHandler shotFired;
        private void Awake()
        {
            _input = GetComponent<IInputReader>();
        }
        private void FixedUpdate()
        {
            if (_input == null) return;
            if (_input.GetAction())
            {
                if (_canShoot)
                {
                    _canShoot = false;
                    GameObject shot = ObjectPooler.Instance.SpawnFromPool("shots");
                    Shot shotComp = shot.GetComponent<Shot>();
                    if (shotComp == null)
                    {
                        ObjectPooler.Instance.ReturnToPool("shots", shot);
                        return;
                    }
                    shotFired?.Invoke();
                    
                    shotComp.InitializeShot(_owner.transform.position, _owner.transform.eulerAngles.z, 16f, 1f);
                    Rigidbody2D shotBody = shot.GetComponent<Rigidbody2D>();
                    if (shotBody == null) return;
                    Rigidbody2D ownerBody = _owner.GetComponent<Rigidbody2D>();
                    if (ownerBody == null) return;
                    
                    shotBody.velocity = ownerBody.velocity;
                }
            }
            else
            {
                _canShoot = true;
            }
        }
    }
}
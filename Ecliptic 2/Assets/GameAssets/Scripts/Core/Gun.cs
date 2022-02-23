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
                    shotComp.InitializeShot(_owner.transform.position, _owner.transform.eulerAngles.z, 16f, 1f);
                }
            }
            else
            {
                _canShoot = true;
            }
        }
    }
}
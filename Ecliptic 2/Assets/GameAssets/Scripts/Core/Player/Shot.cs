using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;
using EclipticTwo.Core;

namespace EclipticTwo.Guns
{
    public class Shot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private float _duration;
        [SerializeField] private LayerMask mask;
        private float _range;
        private Vector2 _origin;
        

        public void InitializeShot(Vector2 origin, float angle, float range, float duration)
        {
            _range = range;
            gameObject.transform.position = origin;
            _origin = origin;
            gameObject.transform.eulerAngles = new Vector3(0f, 0f, angle);
            _duration = duration;

            StartCoroutine(EvaluateHit());

            _sprite.size = new Vector2(_range, 0.16f);
        }

        private IEnumerator EvaluateHit()
        {
            Vector2 vectorAngle = new Vector2(cos(radians(gameObject.transform.eulerAngles.z)), sin(radians(gameObject.transform.eulerAngles.z)));
            RaycastHit2D rayHit = Physics2D.Raycast(_origin, vectorAngle, _range, mask);

            int range = 16;
            for (int i = 0; i < range; i++)
            {
                rayHit = Physics2D.Raycast(_origin, vectorAngle, _range, mask);
                if (rayHit.collider != null)
                {
                    RegisterHit(rayHit);
                    if (IsTargetDestroyable(rayHit))
                    {
                        break;
                    }
                }
                yield return null;
            }
        }

        private void RegisterHit(RaycastHit2D rayHit)
        {
            _range = Vector2.Distance(_origin, rayHit.point);
            
        }

        private bool IsTargetDestroyable(RaycastHit2D rayHit)
        {
            IDestroyable target = rayHit.collider.gameObject.GetComponent<IDestroyable>();
            if (target != null)
            {
                target.Defeated();
                return true;
            }
            return false;
        }

        private void FixedUpdate()
        {
            _origin = gameObject.transform.position;

            _sprite.size -= new Vector2(0f, Time.fixedDeltaTime / _duration);
            if (_sprite.size.y < float.Epsilon)
            {
                ObjectPooler.Instance.ReturnToPool("shots", this.gameObject);
            }
        }
        public float GetRange()
        {
            return _range;
        }
    }
}
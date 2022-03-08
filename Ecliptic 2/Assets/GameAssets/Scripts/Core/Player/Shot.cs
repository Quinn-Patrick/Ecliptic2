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
        private float _range;
        [SerializeField] private LayerMask mask;

        public void InitializeShot(Vector2 origin, float angle, float range, float duration)
        {
            _range = range;
            gameObject.transform.position = origin;
            gameObject.transform.eulerAngles = new Vector3(0f, 0f, angle);
            _duration = duration;

            StartCoroutine(EvaluateHit(origin, angle, range));

            _sprite.size = new Vector2(_range, 0.16f);
        }

        private IEnumerator EvaluateHit(Vector2 origin, float angle, float range)
        {
            Vector2 vectorAngle = new Vector2(cos(radians(angle)), sin(radians(angle)));
            RaycastHit2D rayHit = Physics2D.Raycast(origin, vectorAngle, range, mask);
            for (int i = 0; i < 16; i++)
            {
                rayHit = Physics2D.Raycast(origin, vectorAngle, range, mask);
                if (rayHit.collider != null) break;
                yield return null;
            }
            if (rayHit.collider != null)
            {
                _range = Vector2.Distance(origin, rayHit.point);
                IDestroyable target = rayHit.collider.gameObject.GetComponent<IDestroyable>();
                if (target != null) target.Defeated();
            }
        }

        private void FixedUpdate()
        {
            _sprite.size -= new Vector2(0f, Time.fixedDeltaTime / _duration);
            if (_sprite.size.y < float.Epsilon)
            {
                ObjectPooler.Instance.ReturnToPool("shots", this.gameObject);
            }
        }
    }
}
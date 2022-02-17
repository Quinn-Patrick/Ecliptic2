using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private BoxCollider2D _hitbox;
    [SerializeField] private float _duration;
    private float age;

    public void InitializeShot(Vector2 origin, float angle, float range, float duration)
    {
        age = 0f;
        gameObject.transform.position = origin;
        gameObject.transform.eulerAngles = new Vector3(0f, 0f, angle);

        _sprite.size = new Vector2(range, 0.16f);
        _hitbox.enabled = true;
        _hitbox.offset = new Vector2(range / 2, 0f);
        _hitbox.size = new Vector2(range, 0.16f);
        _duration = duration;
    }

    private void FixedUpdate()
    {
        if (age > float.Epsilon) _hitbox.enabled = false;
        _sprite.size -= new Vector2(0f, Time.fixedDeltaTime / _duration);
        if (_sprite.size.y < float.Epsilon)
        {
            ObjectPooler.Instance.ReturnToPool("shots", this.gameObject);
        }
        age += Time.fixedDeltaTime;
    }
}

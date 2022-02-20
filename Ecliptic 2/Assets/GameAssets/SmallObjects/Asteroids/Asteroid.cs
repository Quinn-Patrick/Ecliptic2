using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : GravitatingBody, IDestroyable
{
    [SerializeField] private float _radius;
    private readonly GameObject[] _subAsteroids = new GameObject[2];
    [SerializeField] private bool _splits;
    private float age;

    public delegate void DestroyHandler(Asteroid a);
    public event DestroyHandler Destroyed;

    private new void Start()
    {
        age = 0;
        base.Start();
        _transform.localScale = new Vector3(_radius, _radius, 0f);
        _body.mass = 1000 * _radius * _radius;
        if (!_splits) return;
        if (_radius > 0.126)
        {
            for (int i = 0; i < _subAsteroids.Length; i++)
            {
                _subAsteroids[i] = Instantiate(this.gameObject);
                _subAsteroids[i].GetComponent<Asteroid>().SetRadius(_radius / 2);
                _subAsteroids[i].SetActive(false);
            }
        }
        else
        {
            _splits = false;
        }
    }
    private void OnEnable()
    {
        age = 0;
        if (_radius < 0.125)
        {
            _splits = false;
            _radius = 0.125f;
        }
    }

    private new void FixedUpdate()
    {
        base.FixedUpdate();
        age += Time.fixedDeltaTime;
    }

    public void SetRadius(float rad)
    {
        _radius = rad;
    }

    public GameObject[] GetSubAsteroids()
    {
        if (!_splits) return null;
        return _subAsteroids;
    }

    public void Defeated()
    {
        
        if (age < 0.1f) return;
        Destroyed?.Invoke(this);
        if (!_splits)
        {
            Destroy(this.gameObject);
            return;
        }
        _subAsteroids[0].transform.position = _transform.position + new Vector3(_radius / 2, _radius / 2, 0);
        _subAsteroids[0].SetActive(true);
        Rigidbody2D _subAstBody = _subAsteroids[0].GetComponent<Rigidbody2D>();
        _subAstBody.velocity = _body.velocity;
        ApplyPerpendicularForce(_subAstBody, 1);

        _subAsteroids[1].transform.position = _transform.position - new Vector3(_radius / 2, _radius / 2, 0);
        _subAsteroids[1].SetActive(true);
        _subAstBody = _subAsteroids[0].GetComponent<Rigidbody2D>();
        _subAstBody.velocity = _body.velocity;
        ApplyPerpendicularForce(_subAstBody, -1);
        this.gameObject.SetActive(false);
        
        Destroy(this.gameObject);
    }

    private void ApplyPerpendicularForce(Rigidbody2D asteroid, float multiplier)
    {
        Vector2 directionVector = new Vector2(asteroid.velocity.y * multiplier * -1, asteroid.velocity.x * multiplier).normalized;
        asteroid.AddForce(directionVector * 250);
    }
}

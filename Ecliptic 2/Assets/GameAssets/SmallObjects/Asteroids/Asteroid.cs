using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : GravitatingBody, IDestroyable
{
    [SerializeField] private float _radius;
    private GameObject[] _subAsteroids = new GameObject[2];
    [SerializeField] private bool _splits;
    private new void Start()
    {
        base.Start();
        _transform.localScale = new Vector3(_radius, _radius, 0f);
        _body.mass = 1000 * _radius * _radius;
        if (!_splits) return;
        if (_radius >= 0.125)
        {
            for (int i = 0; i < _subAsteroids.Length; i++)
            {
                _subAsteroids[i] = Instantiate(this.gameObject);
                _subAsteroids[i].GetComponent<Asteroid>().SetRadius(_radius / 3);
                _subAsteroids[i].SetActive(false);
            }
        }
    }

    public void SetRadius(float rad)
    {
        _radius = rad;
    }

    public void Defeated()
    {
        if (!_splits)
        {
            Destroy(this.gameObject);
            return;
        }
        _subAsteroids[0].transform.position = _transform.position + new Vector3(_radius/2, _radius/2, 0);
        _subAsteroids[0].SetActive(true);
        _subAsteroids[1].transform.position = _transform.position - new Vector3(_radius / 2, _radius / 2, 0);
        _subAsteroids[1].SetActive(true);
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}

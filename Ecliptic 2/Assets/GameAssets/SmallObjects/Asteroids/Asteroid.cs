using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : GravitatingBody
{
    [SerializeField] private float _radius;
    private new void Start()
    {
        base.Start();
        _transform.localScale = new Vector3(_radius, _radius, 0f);
    }
}

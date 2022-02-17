using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassiveBody : MonoBehaviour
{
    [SerializeField] private float _mass;
    private float _radius;
    private void Awake()
    {
        _radius = this.transform.localScale.x;
    }
    private void Start()
    {
        Game.planets.Add(this);
    }
    public float GetMass()
    {
        return _mass;
    }
    public float GetRadius()
    {
        return _radius;
    }
}



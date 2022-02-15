using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassiveBody : MonoBehaviour
{
    [SerializeField] private float _mass;
    private void Start()
    {
        Game.planets.Add(this);
    }
    public float GetMass()
    {
        return _mass;
    }
}



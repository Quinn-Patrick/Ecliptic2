using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Burst;

public class GravitatingBody : DynamicEntity
{
    private void Start()
    {
        Game.gravitators.Add(this);
    }
}


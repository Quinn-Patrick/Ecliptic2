using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _transform;
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
}

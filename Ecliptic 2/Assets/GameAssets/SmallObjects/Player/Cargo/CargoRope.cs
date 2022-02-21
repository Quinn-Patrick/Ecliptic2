using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoRope : MonoBehaviour
{
    [SerializeField] private GameObject _payload;
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void SetPayloadPosition(Vector2 position)
    {
        _payload.transform.position = position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private DynamicEntity _player;
    private void Update()
    {
        if (_player == null) return;
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -14f);
    }
}

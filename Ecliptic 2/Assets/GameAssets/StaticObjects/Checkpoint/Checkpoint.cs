using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour, ITriggerObject
{
    [SerializeField] private Sprite _inactiveSprite;
    [SerializeField] private Sprite _activeSprite;
    private SpriteRenderer _render;
    private bool _isActive = false;

    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
    }
    public void PlayerEnter(Player player)
    {
        _isActive = true;
        CheckpointChecker playerChecker = player.gameObject.GetComponent<CheckpointChecker>();
        if (playerChecker == null) return;
        playerChecker.SetCheckpoint(this);
    }

    public void PlayerExit(Player player){}

    public void PlayerStay(Player player){}

    private void Update()
    {
        if (_render == null) return;
        if (_isActive)
        {
            _render.sprite = _activeSprite;
            return;
        }
        _render.sprite = _inactiveSprite;
    }
}

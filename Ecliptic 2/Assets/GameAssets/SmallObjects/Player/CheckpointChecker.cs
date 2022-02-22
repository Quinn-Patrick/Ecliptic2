using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointChecker : MonoBehaviour
{
    private Checkpoint _currentCheckpoint;
    private Vector2 _checkpointLocation;
    public void SetCheckpoint(Checkpoint newCheckpoint)
    {
        _currentCheckpoint = newCheckpoint;
        _checkpointLocation = _currentCheckpoint.transform.localPosition - new Vector3(0.25f, 0f, 0f);
    }
}

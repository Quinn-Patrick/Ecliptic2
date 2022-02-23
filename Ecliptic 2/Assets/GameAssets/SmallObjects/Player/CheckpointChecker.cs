using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointChecker : MonoBehaviour
{
    private Checkpoint _currentCheckpoint;
    private Vector2 _checkpointLocation;
    private float _checkpointRotation;
    public void SetCheckpoint(Checkpoint newCheckpoint)
    {
        _currentCheckpoint = newCheckpoint;
        _checkpointLocation = _currentCheckpoint.transform.position - new Vector3(0.25f, 0f, 0f);
        _checkpointRotation = _currentCheckpoint.transform.eulerAngles.z + 90f;
    }
    public Vector2 GetCheckpointLocation()
    {
        return _checkpointLocation;
    }
    public float GetCheckpointRotation()
    {
        return _checkpointRotation;
    }
}
